using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace AutoInsertInDatabaseOnRussian
{
    public partial class MainWindow : Form
    {
        private Random gen = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            listDatabases.Items.Clear();
            DataTable dataTable = GetData("SELECT name FROM sys.databases");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string temp = dataTable.Rows[i][0].ToString();
                if (temp == "master" || temp == "tempdb" || temp == "model" || temp == "msdb" || temp == "ReportServer" || temp == "ReportServerTempDB") { }
                else listDatabases.Items.Add(temp);
            }
            listDatabases.Enabled = true;
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

        DateTime RandomDay(string text)
        {
            DateTime temp = new DateTime(2000, 1, 1);

            if (text.Contains(" "))
            {
                text = text.Replace(" ", ".");
                string[] nums = text.Trim().Split(new char[] { '.' });
                DateTime start = new DateTime(Convert.ToInt32(nums[2]), Convert.ToInt32(nums[1]), Convert.ToInt32(nums[0]));
                DateTime end = new DateTime(Convert.ToInt32(nums[5]), Convert.ToInt32(nums[4]), Convert.ToInt32(nums[3]));
                int range = (end - start).Days;
                temp = start.AddDays(gen.Next(range));
            }
            else
            {
                string[] nums = text.Trim().Split(new char[] { '.' });
                DateTime start = new DateTime(Convert.ToInt32(nums[2]), Convert.ToInt32(nums[1]), Convert.ToInt32(nums[0]));
                int range = (DateTime.Today - start).Days;
                temp = start.AddDays(gen.Next(range));
            }

            return temp;
        }

        int RandomIntNum(string text)
        {
            string[] nums = text.Trim().Split(new char[] { ' ' });
            int num1 = int.Parse(nums[0]);
            int num2 = int.Parse(nums[1]);

            int randomNum = gen.Next(num1, num2);

            return randomNum;
        }

        string RandomText(string ins)
        {
            char[] symbols = ins.Trim().ToCharArray();

            string text = string.Empty;
            foreach (char sym in symbols)
            {
                switch (sym)
                {
                    case 'l': text += (char)gen.Next(97, 123); break;
                    case 'L': text += (char)gen.Next(65, 91); break;
                    case 'б': text += (char)gen.Next(1072, 1104); break;
                    case 'Б': text += (char)gen.Next(1040, 1072); break;
                    case '0': text += gen.Next(0, 10); break;
                    default: text += sym; break;
                }
            }

            return text;
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
            // site: randomdatatools.ru/developers/

            string namesTable = string.Empty;
            string valuesTable = string.Empty;

            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid.Rows[i].Cells[2].Value.ToString() != "null")
                    namesTable += $"[{dataGrid.Rows[i].Cells[0].Value}], ";
            }

            namesTable = namesTable.Remove(namesTable.Length - 2, 2);

            string[,] array = new string[Convert.ToInt32(countRecords.Value), dataGrid.RowCount];
            for (int i = 0; i < countRecords.Value; i++)
            {
                Thread.Sleep(1);
                for (int j = 0; j < Convert.ToInt32(dataGrid.RowCount); j++)
                {
                    switch (dataGrid.Rows[j].Cells[2].Value.ToString())
                    {
                        case "Логин": array[i, j] = jsonObject[i]["Login"].Value<string>(); break;
                        case "Пароль": array[i, j] = jsonObject[i]["Password"].Value<string>(); break;
                        case "Фамилия":; array[i, j] = jsonObject[i]["LastName"].Value<string>(); break;
                        case "Имя": array[i, j] = jsonObject[i]["FirstName"].Value<string>(); break;
                        case "Отчество": array[i, j] = jsonObject[i]["FatherName"].Value<string>(); break;
                        case "Дата рождения": array[i, j] = jsonObject[i]["DateOfBirth"].Value<string>(); break;

                        // -- работа с полом человека
                        case "Пол (в первую букву)":
                            if (genderUnset.Checked)
                            {
                                string temp = jsonObject[i]["Gender"].Value<string>();
                                array[i, j] = temp.Remove(1, Math.Abs(temp.Length - 1));
                            }
                            else
                                array[i, j] = genderMan.Checked ? "М" : "Ж";
                            break;

                        case "Пол (полностью)":
                            if (genderUnset.Checked)
                                array[i, j] = jsonObject[i]["Gender"].Value<string>();
                            else
                                array[i, j] = genderMan.Checked ? "Мужчина" : "Женщина";
                            break;
                        // -- 

                        case "Номер телефона":
                            string num = jsonObject[i]["Phone"].Value<string>();
                            array[i, j] = num.Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", ""); break;
                        case "Электронная почта": array[i, j] = jsonObject[i]["Email"].Value<string>(); break;
                        case "Домашний адрес": array[i, j] = jsonObject[i]["Address"].Value<string>(); break;
                        case "Код паспорта": array[i, j] = jsonObject[i]["PasportCode"].Value<string>().Replace("-", ""); break;
                        case "Серия паспорта": array[i, j] = jsonObject[i]["PasportSerial"].Value<string>(); break;
                        case "Номер паспорта": array[i, j] = jsonObject[i]["PasportNumber"].Value<string>(); break;
                        case "Серия и номер паспорта": array[i, j] = jsonObject[i]["PasportNum"].Value<string>().Replace(" ", ""); break;
                        case "Кем выдан": array[i, j] = jsonObject[i]["PasportOtd"].Value<string>(); break;
                        case "Дата выдачи паспорта": array[i, j] = jsonObject[i]["PasportDate"].Value<string>(); break;
                        case "Страна": array[i, j] = jsonObject[i]["Country"].Value<string>(); break;
                        case "Регион": array[i, j] = jsonObject[i]["Region"].Value<string>(); break;
                        case "Город": array[i, j] = jsonObject[i]["City"].Value<string>(); break;
                        case "Специальность": array[i, j] = jsonObject[i]["EduSpecialty"].Value<string>(); break;
                        case "Направление": array[i, j] = jsonObject[i]["EduProgram"].Value<string>(); break;
                        case "Учебное заведение": array[i, j] = jsonObject[i]["EduName"].Value<string>(); break;
                        case "Серия/Номер диплома": array[i, j] = jsonObject[i]["EduDocNum"].Value<string>(); break;
                        case "Регистрационный номер": array[i, j] = jsonObject[i]["EduRegNumber"].Value<string>(); break;
                        case "Дата окончания обучения": array[i, j] = jsonObject[i]["EduYear"].Value<string>(); break;

                        // ИНН, СНИЛС, ОМС и др.
                        case "ИНН (для физ. лиц и ИП)": array[i, j] = jsonObject[i]["inn_fiz"].Value<string>(); break;
                        case "ИНН (для юр. лиц)": array[i, j] = jsonObject[i]["inn_ur"].Value<string>(); break;
                        case "СНИЛС": array[i, j] = jsonObject[i]["snils"].Value<string>(); break;
                        case "ОМС": array[i, j] = jsonObject[i]["oms"].Value<string>(); break;
                        case "ОГРН": array[i, j] = jsonObject[i]["ogrn"].Value<string>(); break;
                        case "КПП": array[i, j] = jsonObject[i]["kpp"].Value<string>(); break;

                        // Свои значения
                        case "empty": array[i, j] = string.Empty; break;
                        case "my insert": array[i, j] = dataGrid.Rows[j].Cells[3].Value.ToString(); break;
                        case "random number":
                            try
                            {
                                array[i, j] = RandomIntNum(dataGrid.Rows[j].Cells[3].Value.ToString()).ToString();
                            }
                            catch
                            {
                                array[i, j] = "404";
                            }
                            break;

                        case "random id record from table":
                            try
                            {
                                string nameTable = dataGrid.Rows[j].Cells[3].Value.ToString().Trim();
                                DataTable temp = GetData($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME LIKE '{nameTable}' AND CONSTRAINT_NAME LIKE 'PK%'");

                                if (!string.IsNullOrEmpty(temp.Rows[0][0].ToString()))
                                {
                                    string col = temp.Rows[0][0].ToString();
                                    temp = GetData($"SELECT {col} FROM {nameTable}");
                                    int abc = gen.Next(temp.Rows.Count);
                                    array[i, j] = temp.Rows[abc][0].ToString();
                                }
                            }
                            catch
                            {
                                array[i, j] = "0";
                            }
                            break;

                        case "unique id record from table":
                            try
                            {
                                string nameTable = dataGrid.Rows[j].Cells[3].Value.ToString().Trim();
                                DataTable temp = GetData($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME LIKE '{nameTable}' AND CONSTRAINT_NAME LIKE 'PK%'");

                                if (!string.IsNullOrEmpty(temp.Rows[0][0].ToString()))
                                {
                                    string col = temp.Rows[0][0].ToString();
                                    temp = GetData($"SELECT {col} FROM {nameTable}");
                                    array[i, j] = temp.Rows[i][0].ToString();
                                }
                            }
                            catch
                            {
                                array[i, j] = "";
                            }
                            break;

                        case "random text with format":
                            try
                            {
                                array[i, j] = RandomText(dataGrid.Rows[j].Cells[3].Value.ToString()).ToString();
                            }
                            catch
                            {
                                array[i, j] = "0";
                            }
                            break;

                        case "random date":
                            try
                            {
                                array[i, j] = RandomDay(dataGrid.Rows[j].Cells[3].Value.ToString().Trim()).ToString();
                            }
                            catch
                            {
                                array[i, j] = "0";
                            }
                            break;

                            //case "random num using format": LL0000-00ББ
                            //case "unique id record from table" Должности //(в сотрудники) 
                            // рандомная дата между x and y или между x и текущей датой
                    }
                }
            }

            for (int i = 0; i < countRecords.Value; i++)
            {
                valuesTable += "(";
                for (int j = 0; j < Convert.ToInt32(dataGrid.RowCount); j++)
                {
                    if (array[i, j] != null)
                        valuesTable += $"'{array[i, j]}', ";
                }
                valuesTable = valuesTable.Remove(valuesTable.Length - 2, 2);
                valuesTable += "),\n";
            }
            valuesTable = valuesTable.Remove(valuesTable.Length - 2, 2);

            string cmd = $"insert into [{listTables.SelectedItem}]({namesTable})\nvalues\n{valuesTable}";

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
                dataGrid.Rows[i].Cells[2].Value = AutoInsert.Items[0];

                if (dataGrid.Rows[i].Cells[1].Value.ToString().Contains("identity") || dataGrid.Rows[i].Cells[1].Value.ToString().Contains("uniqueidentifier"))
                    dataGrid.Rows[i].Cells[2].ReadOnly = true;
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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpMessage = "  >> null\nСтолбец не будет участвовать во вставке данных\n\n" +
                "  >> empty\nСтолбец заполниться следующими данными: '' (для личного заполнения данными)\n\n" +
                "  >> my insert\nСтолбец заполнится данными, стоящими ячейке справа\n\n" +
                "  >> random number\nСтолбец заполнится случайными числами от x до y. Числа записывать в ячейку справа через пробел\n\n" +
                "  >> random text with format\nСтолбец заполнится случайным текстом заданного формата. Формат: L - английская буква верхнего регистра, l - англ. буква нижнего регистра, Б - русская буква нижнего регистра, б - рус. буква нижнего регистра, 0 - случайное число, остальные символы будут прописываться так, как есть\n\n" +
                "  >> random id record from table\nВставка случайным номером первичного ключа. В ячейку записать название таблицы\n\n" +
                "  >> unique id record from table\nВставка последовательным номером первичного ключа. В ячейку записать название таблицы\n\n" +
                "  >> random date\nВставка случайной даты. В ячейку записать дату в формате ДД.ММ.ГГГГ. При записи в ячейку одной даты будет сгенерирована дата от вставленной до текущей, в случае двух дат через пробел - дата между ними";

            MessageBox.Show(helpMessage, "Помощь по вставке данных");
        }
    }
}