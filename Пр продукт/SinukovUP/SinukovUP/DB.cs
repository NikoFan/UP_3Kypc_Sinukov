using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SinukovUP
{
    internal class DB
    {

        private const string url = "data source=.\\MSSQLSERVER2022;" +
"Database=UPdatabase;" +
"User Id=sa;" +
"Password=123;" +
"TrustServerCertificate=True;";

        private ulong getId(string tableName)
        {
            ulong id = 1;
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM {tableName};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        id++;

                    }
                    dr.Close();
                }
                conn.Close();
            }
            return id;
        }

        // Проверка данных на дубликаты в таблице
        private bool checkDuplicate(string[] information)
        {

            string phoneNumber = information[0],
                login = information[2],
                password = information[3],
                table = information[4];
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM {table};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // Если были совпадения
                        if (login.Trim() == ("" + dr["Логин"]).Trim() ||
                            password.Trim() == ("" + dr["Пароль"]).Trim() ||
                            phoneNumber.Trim() == ("" + dr["Телефон"]).Trim())
                        {
                            new Helps().createInformationMessageBox("Данные заняты другим пользователем!");
                            return false;
                        }


                    }
                    dr.Close();
                }
                conn.Close();
            }
            return true;
        }


        // Регистрация пользователя в бд
        public bool addNewAccount(string[] regInformation)
        {
            if (!checkDuplicate(regInformation))
                return false;
            ulong id = getId(regInformation[4]);
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                INSERT INTO {regInformation[4]}
                VALUES({id}, N'{regInformation[0]}', N'{regInformation[1]}', N'{regInformation[2]}', N'{regInformation[3]}', N'{regInformation[4]}')");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Запись информации в КЕШ
                new MemoryWork().setUserID(id);
                new MemoryWork().setUserROLE(regInformation[4]);
                // Возврат результата
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        // Авторизация пользвоателя
        public bool SignInAccount(string[] authInformation)
        {
            string login = authInformation[0],
                password = authInformation[1],
                table = authInformation[2];
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM {table};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(login.Trim() == ("" + dr["Логин"]).Trim());
                        Console.WriteLine(login.Trim());
                        Console.WriteLine(("" + dr["Логин"]).Trim());
                        Console.WriteLine("" + dr[$"ID {table}а"]);
                        // Если были совпадения
                        if (login.Trim() == ("" + dr["Логин"]).Trim() &
                            password.Trim() == ("" + dr["Пароль"]).Trim() &
                            table.Trim() == ("" + dr["Роль"]).Trim())
                        {
                            new Helps().createInformationMessageBox("Пользователь авторизован!");

                            new MemoryWork().setUserID(Convert.ToUInt64("" + dr[$"ID {table}а"]));
                            Console.WriteLine("-- "+"" + dr[$"ID {table}а"]);
                            new MemoryWork().setUserROLE(table);
                            return true;
                        }


                    }
                    dr.Close();
                }
                conn.Close();
            }
            return false;

        }


        // Возврат информации про пользователя
        public Dictionary<string, string> returnuserAccountInformation()
        {
            Dictionary<string, string> returnInformation = new Dictionary<string, string>()
            {
                {"ФИО",""}, {"Логин",""}, {"Телефон",""}, {"Роль",""},
            };

            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT ФИО, Логин, Телефон, Роль
                    FROM {new MemoryWork().getUserROLE()}
                    where [ID {new MemoryWork().getUserROLE()}а] = {new MemoryWork().getUserID()};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnInformation["ФИО"] = ("" + dr["ФИО"]).Trim();
                        returnInformation["Логин"] = ("" + dr["Логин"]).Trim();
                        returnInformation["Телефон"] = ("" + dr["Телефон"]).Trim();
                        returnInformation["Роль"] = ("" + dr["Роль"]).Trim();


                    }
                    dr.Close();
                }
                conn.Close();
            }

            return returnInformation;
        }

        // Регистрация новой заявки
        public bool regNewApplication(Dictionary<string, string> regInfo)
        {
            ulong id = getId("Заявка");
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                INSERT INTO Заявка
                VALUES({id}, '{regInfo["Дата добавления"]}', '{regInfo["Тип техники"]}', '{regInfo["Модель техники"]}', '{regInfo["Описание"]}', '{regInfo["Статус"]}', null, null, null, {new MemoryWork().getUserID()})");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (Exception)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }


        // Возврат всех заявок
        public Dictionary<string, Dictionary<string, string>> returnAllApplicationsInfo()
        {
            Dictionary<string, Dictionary<string, string>> appInformation = new Dictionary<string, Dictionary<string, string>>();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM Заявка;
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>()
                        {
                            {"Дата добавления", (""+dr["Дата добавления"]).Trim().Split(' ')[0]},
                            {"Тип техники", (""+dr["Тип техники"]).Trim()},
                            {"Модель техники", (""+dr["Модель техники"]).Trim()},
                            {"Статус", (""+dr["Статус"]).Trim()},
                            {"Дата окончания", "Дата окончания: " + (""+dr["Дата окончания"]).Trim()},
                        };

                        appInformation[("" + dr["ID Заявки"]).Trim()] = dict;

                    }
                    dr.Close();
                }
                conn.Close();
            }
            return appInformation;
        }



        // Возврат информации про заявки пользователя
        public Dictionary<string, Dictionary<string, string>> returnApplicationsInfo()
        {
            Dictionary<string, Dictionary<string, string>> appInformation = new Dictionary<string, Dictionary<string, string>>();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM Заявка
                    WHERE [ID Заказчика] = {new MemoryWork().getUserID()};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>()
                        {
                            {"Дата добавления", (""+dr["Дата добавления"]).Trim().Split(' ')[0]},
                            {"Тип техники", (""+dr["Тип техники"]).Trim()},
                            {"Модель техники", (""+dr["Модель техники"]).Trim()},
                            {"Статус", (""+dr["Статус"]).Trim()},
                            {"Дата окончания", "Дата окончания: " + (""+dr["Дата окончания"]).Trim()},
                        };

                        appInformation[("" + dr["ID Заявки"]).Trim()] = dict;

                    }
                    dr.Close();
                }
                conn.Close();
            }
            return appInformation;
        }

        // Возврат информации про заявки пользователя
        public Dictionary<string, string> returnSecondApplicationsInfo(string id)
        {
            Dictionary<string, string> appInformation = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM Заявка
                    WHERE [ID Заказчика] = {new MemoryWork().getUserID()}
                        AND [ID Заявки] = {id};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        appInformation["Описание"] = ("" + dr["Описание"]).Trim();
                        appInformation["Комментарий"] = getComment(("" + dr["ID Заявки"]).Trim(), ("" + dr["ID Мастера"]).Trim());

                    }
                    dr.Close();
                }
                conn.Close();
            }

            return appInformation;
        }


        // Возврат информации про ответственного за заявки пользователя
        public string returnMasterApplicationsInfo(string id)
        {
            Dictionary<string, string> masterInformation = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT [ID Мастера]
                    FROM Заявка
                    Where [ID Заявки] = {id};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                         return returnFIOmaster(("" + dr["ID Мастера"]).Trim());



                    }
                    dr.Close();
                }
                conn.Close();
            }

            return "Не назначен";
        }

        private string returnFIOmaster(string masterID)
        {
            Console.WriteLine(masterID);
            try
            {
                using (SqlConnection conn = new SqlConnection(url))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $@"
                    SELECT ФИО
                    FROM Мастер
                    Where [ID Мастера] = {masterID};
                    ";

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            return ("" + dr["ФИО"]).Trim();



                        }
                        dr.Close();
                    }
                    conn.Close();
                }
                return "Не назначен";
            }
            catch(Exception ex)
            {
                return "Не назначен";
            }
            

            
        }

        // Возврат всех мастеров
        public Dictionary<string, string> returnMastersDict()
        {
            Dictionary<string, string> masters = new Dictionary<string, string> ();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT [ID Мастера], ФИО
                    FROM Мастер;
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(("" + dr["ID Мастера"]).Trim() + " - " + ("" + dr["ФИО"]).Trim());
                        masters[("" + dr["ID Мастера"]).Trim()] = ("" + dr["ФИО"]).Trim();

                    }
                    dr.Close();
                }
                conn.Close();
            }

            return masters;
        }

        // Получение текста комментария
        public string getComment()
        {
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT Сообщение
                    FROM Комментарий
                    WHERE [ID Мастера] = {new MemoryWork().getUserID()} AND [ID Заявки] = {new MemoryWork().getAppID()};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        return ("" + dr["Сообщение"]).Trim();

                    }
                    dr.Close();
                }
                conn.Close();
            }

            return "";
        }

        // Добавление комментария к заявке
        public bool addNewComment(string message)
        {
            ulong id = getId("Комментарий");
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                INSERT INTO Комментарий
                VALUES({id}, '{message}', {new MemoryWork().getUserID()}, {new MemoryWork().getAppID()})");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (IOException)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }


        // Проверка что комментарий к заявке есть
        public bool IsCommentBe()
        {
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $@"
                    SELECT *
                    FROM Комментарий
                    WHERE [ID Мастера] = {new MemoryWork().getUserID()} AND [ID Заявки] = {new MemoryWork().getAppID()};
                    ";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        return true;

                    }
                    dr.Close();
                }
                conn.Close();
            }
            return false;
        }




        // ОБновление комментария
        public bool updateComment(string message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                UPDATE Комментарий
                SET [Сообщение] = '{message}'
where [ID Заявки] = {new MemoryWork().getAppID()} and [ID Мастера] = {new MemoryWork().getUserID()}");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (IOException)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }


        // ОБновление статуса заявки
        public bool updateOnlyWorkParts(string WorkPart)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                UPDATE Заявка
                SET [Статус] = '{WorkPart}'
where [ID Заявки] = {new MemoryWork().getAppID()}");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (IOException)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }



        // ОБновление времени готовности заказа и статуса
        public bool updateWorkParts(string WorkPart)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                UPDATE Заявка
                SET [Статус] = '{WorkPart}',
                    [Дата окончания] = '{new Helps().takeTime()}'
where [ID Заявки] = {new MemoryWork().getAppID()}");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (IOException)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }



        // ОБновление мастера
        public bool updateMasterID(string masterID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                UPDATE Заявка
                SET [ID Мастера] = {masterID}
where [ID Заявки] = {new MemoryWork().getAppID()}");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (IOException)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }


        // ОБновление описания
        public bool updateProblemD(string message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(url))
                {

                    connection.Open();
                    SqlCommand commandToAddInformationFromTable = new SqlCommand($@"
                UPDATE Заявка
                SET Описание = '{message}'
where [ID Заявки] = {new MemoryWork().getAppID()}
    AND [ID Заказчика] = {new MemoryWork().getUserID()}");
                    commandToAddInformationFromTable.Connection = connection;
                    commandToAddInformationFromTable.ExecuteNonQuery();
                }
                // Возврат результата
                return true;
            }
            catch (Exception)
            {
                new Helps().createInformationMessageBox("Ошибка на сервере! Ожидайте исправления!");
                return false;
            }
        }

        // Получение комментария
        private string getComment(string idApp, string idMaster)
        {
            Console.WriteLine("ID master: " + idMaster);
            try
            {
                using (SqlConnection conn = new SqlConnection(url))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $@"
                    SELECT *
                    FROM Комментарий
                    WHERE [ID Мастера] = {idMaster}
                        AND [ID Заявки] = {idApp};
                    ";

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            return ("" + dr["Сообщение"]).Trim();

                        }
                        dr.Close();
                    }
                    conn.Close();
                }
                return "Комментарий еще не добавлен!";
            }
            catch (Exception)
            {
                Console.WriteLine("end: ");
                return "Комментарий еще не добавлен!";
            }
            
        }
    }
}
