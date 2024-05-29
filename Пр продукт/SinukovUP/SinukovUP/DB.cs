using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
                        // Если были совпадения
                        if (login.Trim() == ("" + dr["Логин"]).Trim() &
                            password.Trim() == ("" + dr["Пароль"]).Trim())
                        {
                            new Helps().createInformationMessageBox("Пользователь авторизован!");
                            new MemoryWork().setUserID(Convert.ToUInt64("" + dr[$"ID {table}а"]));
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
    }
}
