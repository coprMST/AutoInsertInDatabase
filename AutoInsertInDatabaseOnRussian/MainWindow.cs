using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Data;

namespace AutoInsertInDatabaseOnRussian
{
    public partial class MainWindow : Form
    {
        public readonly string standartConnectionString = @"Data Source=localhost;Initial Catalog=master;Integrated Security=True";
        public string abc1 = string.Empty, abc2 = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(standartConnectionString))
            {
                try
                {
                    // Открываем асинхронное соединение с базой данных
                    Task connectionTask = null;
                    try
                    {
                        connectionTask = connection.OpenAsync();
                        Task.WaitAll(connectionTask);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось установить соединение с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Если соединение произвелось успешно
                    if (!connectionTask.IsFaulted)
                    {
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT name FROM sys.databases;";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                while (reader.Read())
                                {
                                    string temp = reader.GetValue(0).ToString();
                                    if (temp == "master" || temp == "tempdb" || temp == "model" || temp == "msdb" || temp == "ReportServer" || temp == "ReportServerTempDB") { }
                                    else
                                        listDatabases.Items.Add(temp);
                                }
                        }
                    }
                    listDatabases.Enabled = true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListDatabases_SelectedValueChanged(object sender, EventArgs e)
        {
            listTables.Items.Clear();

            string connectionString = $@"Data Source=localhost;Initial Catalog={listDatabases.SelectedItem};Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Открываем асинхронное соединение с базой данных
                    Task connectionTask = null;
                    try
                    {
                        connectionTask = connection.OpenAsync();
                        Task.WaitAll(connectionTask);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось установить соединение с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Если соединение произвелось успешно
                    if (!connectionTask.IsFaulted)
                    {
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                while (reader.Read())
                                {
                                    string temp = reader.GetValue(2).ToString();
                                    if (temp == "sysdiagrams") { }
                                    else
                                        listTables.Items.Add(temp);
                                }
                        }
                    }
                    listTables.Enabled = true;
                    countRecords.Enabled = true;
                    checkList.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void GoInsertData_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source=localhost;Initial Catalog={listDatabases.SelectedItem};Integrated Security=True";

            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync("https://api.randomdatatools.ru/?count=" + countRecords.Value);
                JArray jsonObject = JArray.Parse(jsonString);

                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Открываем асинхронное соединение с базой данных
                        Task connectionTask = null;
                        try
                        {
                            connectionTask = connection.OpenAsync();
                            Task.WaitAll(connectionTask);
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось установить соединение с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Если соединение произвелось успешно, то заполняем базу данных
                        if (!connectionTask.IsFaulted)
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                CheckList(jsonObject);

                                string cmd = $"INSERT INTO {listTables.SelectedItem} ({abc1}) VALUES {abc2}";
                                command.CommandText = cmd;

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CheckList(JArray jsonObject)
        {
            abc1 = string.Empty;
            abc2 = string.Empty;

            CheckBox[] listRows = new CheckBox[15] { Login, Password, LastName, FirstName, FatherName, DateOfBirth, Gender, Phone, Email, Address, PasportSerial, PasportNumber, Country, Region, City };
            List<string> listChecked = new List<String>();

            foreach (CheckBox row in listRows)
                if (row.Checked)
                    abc1 += $"[{row.Text}], ";

            for (int i = 0; i < int.Parse(countRecords.Value.ToString()); i++)
            {
                abc2 += "(";

                foreach (CheckBox row in listRows)
                    if (row.Checked)
                    {
                        // Сокращение полных названий гендера до первой буквы
                        if (row.Name == "Gender")
                        {
                            string temp = jsonObject[i][$"{row.Name}"].Value<string>();
                            abc2 += $"'{temp.Remove(1, Math.Abs(1 - temp.Length))}', ";
                        }
                        else
                        {
                            abc2 += $"'{jsonObject[i][$"{row.Name}"].Value<string>()}', ";
                        }
                    }
                abc2 = abc2.Remove(abc2.Length - 2, 2);
                abc2 += "), ";
            }

            // Удаление последних ненужных знаков
            abc1 = abc1.Remove(abc1.Length - 2, 2);
            abc2 = abc2.Remove(abc2.Length - 2, 2);

            MessageBox.Show(abc2, abc1);
        }

        private void listTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();

            if (listTables.SelectedIndex != -1)
                FillDataGrid();
        }

        private void FillDataGrid()
        {
            ComboBox cb = new ComboBox();
            cb.Items.AddRange(new string[] { "Уругвай", "Эквадор" });


            DataTable dataTable = GetData($"EXEC sp_columns '{listTables.SelectedItem}'");

            int amountRows = dataTable.Rows.Count;
            dataGrid.RowCount = amountRows;

            for (int i = 0; i < amountRows; i++)
            {
                dataGrid.Rows[i].Cells[0].Value = dataTable.Rows[i][3];
                dataGrid.Rows[i].Cells[1].Value = dataTable.Rows[i][5] + " (" + dataTable.Rows[i][6] + ")";
                if (dataTable.Rows[i][17].ToString() == "NO")
                    dataGrid.Rows[i].Cells[1].Value += " null";
                else
                    dataGrid.Rows[i].Cells[1].Value += " not null";
                dataGrid.Rows[i].Cells[2].Value = AutoInsert.Items[0];
            }
        }

        private DataTable GetData (string cmd)
        {
            string connectionString = string.Empty;
            DataTable data = new DataTable();

            if (listDatabases.SelectedIndex != -1)
            {
                connectionString = $@"Data Source=localhost;Initial Catalog={listDatabases.SelectedItem};Integrated Security=True";
            }
            else
            {
                connectionString = $@"Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            }


            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Открываем асинхронное соединение с базой данных
                    Task connectionTask = null;
                    try
                    {
                        connectionTask = connection.OpenAsync();
                        Task.WaitAll(connectionTask);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось установить соединение с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Если соединение произвелось успешно
                    if (!connectionTask.IsFaulted)
                    {
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = cmd;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            SqlDataReader DataRead = null;
                            DataRead = reader;
                            data.Load(DataRead);
                        }
                    }
                    listTables.Enabled = true;
                    countRecords.Enabled = true;
                    checkList.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return data;
        }
    }
}
