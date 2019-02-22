using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DBAccess;

namespace WpfApp1.Model
{
    class LoginCheck
    {
        private string username;
        private string password;
        private string sql;
        private bool _isCheck = false;
        NpgsqlDataReader dataReader;
        public bool Check(Login login)
        {
            username = login.Username;
            password = login.Password;
            sql = "select name,password from userinfo where name=:p and password=:p_pass ";
            Console.Write(sql);

            NpgsqlConnection conn = new DBConnect().SqlConnect();
            using (conn)
            {
                conn.Open();
                var command = new NpgsqlCommand(@sql, conn);

                //sql文にユーザー名とパスワードを設定
                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = username });
                command.Parameters.Add(new NpgsqlParameter("p_pass", DbType.String) { Value = password });

                dataReader = command.ExecuteReader();
               
                Console.WriteLine(dataReader.HasRows);
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.ToString());
                    Console.WriteLine("Username : {0}", dataReader["name"]);
                }

                if (!dataReader.HasRows)
                {
                    _isCheck = false;
                }
                else
                {
                    _isCheck = true;
                    
                }

                conn.Close();
            }
            return _isCheck;
        }
    }
}
