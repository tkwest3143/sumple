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
    class AccountGet
    {
        private string sql = "select * from userinfo where name=:p ";
        NpgsqlDataReader dataReader;
        Account _account=new Account();

        public Account GetAccountInfo(string username) {
            NpgsqlConnection conn = new DBConnect().SqlConnect();
            using (conn)
            {
                conn.Open();
                var command = new NpgsqlCommand(@sql, conn);

                //sql文にユーザー名とパスワードを設定
                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = username });
               

                dataReader = command.ExecuteReader();

                Console.WriteLine(dataReader.HasRows);
                while (dataReader.Read())
                {
                    //SELECTした情報からアカウント情報を設定
                    _account.Username = (string)dataReader["name"];
                    _account.Password = (string)dataReader["password"];
                    _account.Born = (DateTime)dataReader["born"];
                    _account.Height = (int)dataReader["height"];
                    _account.Weight = (int)dataReader["weight"];
                    _account.Bodyfat = (int)dataReader["bodyfat"];

                    Console.WriteLine(dataReader.ToString());
                    
                }

                //接続を切る
                conn.Close();
                return _account;
            }
        }
    }
}
