using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoInsertInDatabaseOnRussian
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DataTable dataTable = GetData("SELECT name FROM sys.databases");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string temp = dataTable.Rows[i][0].ToString();
                if (temp == "master" || temp == "tempdb" || temp == "model" || temp == "msdb" || temp == "ReportServer" || temp == "ReportServerTempDB") { }
                else listDatabases.Items.Add(temp);
            }
            listDatabases.Enabled = true;
        }

        private void ListDatabases_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private async void GoInsertData_Click(object sender, EventArgs e)
        {
            string connectionString = $@"Data Source=localhost;Initial Catalog={listDatabases.SelectedItem};Integrated Security=True";

            string gender = genderUnset.Checked ? "unset" : gender = genderMan.Checked ? "man" : "woman";
            string count = countRecords.Value.ToString();

            JArray jsonObject;
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync("https://api.randomdatatools.ru/?count=" + count + "&gender=" + gender + "&unescaped=false");
                jsonObject = JArray.Parse(jsonString);
            }

            string cmd = GetCommandToInsert(jsonObject);

            if (insertInCB.Checked || insertInAll.Checked)
            {
                Clipboard.SetText(cmd);
                if (insertInCB.Checked)
                    MessageBox.Show("Работа с данными была успешно проведена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (insertInAll.Checked || insertInDB.Checked)
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Если соединение произвелось успешно, то заполняем базу данных
                        if (!connectionTask.IsFaulted)
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                command.CommandText = cmd;
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Работа с данными была успешно проведена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private string GetCommandToInsert(JArray jsonObject)
        {
            string namesTable = string.Empty;
            string valuesTable = string.Empty;

            for(int i = 0; i < dataGrid.RowCount; i++)
                if (dataGrid.Rows[i].Cells[2].Value != null)
                    namesTable += $"[{dataGrid.Rows[i].Cells[0].Value}], ";
            namesTable = namesTable.Remove(namesTable.Length - 2, 2);

            for (int i = 0; i < int.Parse(countRecords.Value.ToString()); i++)
            {
                valuesTable += "(";
                for (int j = 0; j < dataGrid.RowCount; j++)
                {
                    string value = dataGrid.Rows[j].Cells[2].Value == null ? "skip" : dataGrid.Rows[j].Cells[2].Value.ToString();

                    switch (value)
                    {
                        case "null": valuesTable += $"null, "; break;
                        case "Логин": valuesTable += $"'{jsonObject[i]["Login"].Value<string>()}', "; break;
                        case "Пароль": valuesTable += $"'{jsonObject[i]["Password"].Value<string>()}', "; break;
                        case "Фамилия":; valuesTable += $"'{jsonObject[i]["LastName"].Value<string>()}', "; break;
                        case "Имя": valuesTable += $"'{jsonObject[i]["FirstName"].Value<string>()}', "; break;
                        case "Отчество": valuesTable += $"'{jsonObject[i]["FatherName"].Value<string>()}', "; break;
                        case "Дата рождения": valuesTable += $"'{jsonObject[i]["DateOfBirth"].Value<string>()}', "; break;

                        // -- работа с полом человека
                        case "Пол (в первую букву)":
                            if (genderUnset.Checked)
                            {
                                string gnd = jsonObject[i]["Gender"].Value<string>();
                                valuesTable += $"'{gnd.Remove(1, Math.Abs(gnd.Length - 1))}', ";
                            }
                            else
                                valuesTable += genderMan.Checked ? "'М', " : "'Ж', ";
                            break;

                        case "Пол (полностью)":
                            if (genderUnset.Checked)
                                valuesTable += $"'{jsonObject[i]["Gender"].Value<string>()}', ";
                            else
                                valuesTable += genderMan.Checked ? "'Мужчина', " : "'Женщина', ";
                            break;
                        // -- 

                        case "Номер телефона": string num = jsonObject[i]["Phone"].Value<string>(); 
                            valuesTable += $"'{num.Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "")}', "; break;
                        case "Электронная почта": valuesTable += $"'{jsonObject[i]["Email"].Value<string>()}', "; break;
                        case "Домашний адрес": valuesTable += $"'{jsonObject[i]["Address"].Value<string>()}', "; break;
                        case "Код паспорта": valuesTable += $"'{jsonObject[i]["PassportCode"].Value<string>().Replace("-", "")}', "; break;
                        case "Серия паспорта": valuesTable += $"'{jsonObject[i]["PasportSerial"].Value<string>()}', "; break;
                        case "Номер паспорта": valuesTable += $"'{jsonObject[i]["PassportNumber"].Value<string>()}', "; break;
                        case "Серия и номер паспорта": valuesTable += $"'{jsonObject[i]["PasportNum"].Value<string>().Replace(" ", "")}', "; break;
                        case "Кем выдан": valuesTable += $"'{jsonObject[i]["PasportOtd"].Value<string>()}', "; break;
                        case "Дата выдачи паспорта": valuesTable += $"'{jsonObject[i]["PasportDate"].Value<string>()}', "; break;
                        case "Страна": valuesTable += $"'{jsonObject[i]["Country"].Value<string>()}', "; break;
                        case "Регион": valuesTable += $"'{jsonObject[i]["Region"].Value<string>()}', "; break;
                        case "Город": valuesTable += $"'{jsonObject[i]["City"].Value<string>()}', "; break;
                        case "Специальность": valuesTable += $"'{jsonObject[i]["EduSpecialty"].Value<string>()}', "; break;
                        case "Название специальности": valuesTable += $"'{jsonObject[i]["EduProgram"].Value<string>()}', "; break;
                        case "Название ОУ": valuesTable += $"'{jsonObject[i]["EduName"].Value<string>()}', "; break;
                        case "my insert": valuesTable += $"'{dataGrid.Rows[j].Cells[3].Value}', "; break;     
                        default: break;
                    }
                }

                valuesTable = valuesTable.Remove(valuesTable.Length - 2, 2);
                valuesTable += "), ";
                valuesTable += Environment.NewLine;
            }
            valuesTable = valuesTable.Remove(valuesTable.Length - 4, 4);

            string cmd = $"INSERT INTO {listTables.SelectedItem} ({namesTable})\nVALUES\n{valuesTable}";

            return cmd;
        }

        private void listTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
            countRecords.Enabled = true;
            dataGrid.Enabled = true;
            goInsertData.Enabled = true;
        }

        private void FillDataGrid()
        {
            dataGrid.Rows.Clear();
            DataTable dataTable = GetData($"EXEC sp_columns '{listTables.SelectedItem}'");
            dataGrid.RowCount = dataTable.Rows.Count;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGrid.Rows[i].Cells[0].Value = dataTable.Rows[i][3];
                dataGrid.Rows[i].Cells[1].Value = dataTable.Rows[i][5] + " (" + dataTable.Rows[i][6] + ")";
                dataGrid.Rows[i].Cells[1].Value += dataTable.Rows[i][17].ToString() == "NO" ? " not null" : " null";

                if (dataGrid.Rows[i].Cells[1].Value.ToString().Contains("identity"))
                    dataGrid.Rows[i].Cells[2].ReadOnly = true;
                else
                    dataGrid.Rows[i].Cells[2].Value = AutoInsert.Items[0];
            }
        }

        private DataTable GetData (string cmd)
        {
            string connectionString = listDatabases.SelectedIndex != -1 ? $@"Data Source=localhost;Initial Catalog={listDatabases.SelectedItem};Integrated Security=True" : $@"Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            DataTable dataTable = new DataTable();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            dataTable.Load(DataRead);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            listTables.Items.Clear();
            DataTable dataTable = GetData("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string temp = dataTable.Rows[i][2].ToString();
                if (temp == "sysdiagrams") { }
                else listTables.Items.Add(temp);
            }
            listTables.Enabled = true;

            if (listTables.SelectedIndex == -1)
            {
                goInsertData.Enabled = false;
                countRecords.Enabled = false;
                dataGrid.Enabled = false;
                dataGrid.Rows.Clear();
            }
        }
    }
}