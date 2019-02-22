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
    class Register
    {
        public Register(Account account)
        {

            NpgsqlConnection conn = new DBConnect().SqlConnect();
            NpgsqlCommand command;
            using (conn)
            {
                conn.Open();
                
                string sql;
            if (account.Password == "")
            {
                sql = "update userinfo set weight=:p_weight,height=:p_height,bodyfat=:p_bodyfat where name=:p";
                command = new NpgsqlCommand(@sql, conn);
                //sql文に入力するパラメータを設定
                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = account.Username });
                command.Parameters.Add(new NpgsqlParameter("p_height", DbType.Int16) { Value = account.Height });
                command.Parameters.Add(new NpgsqlParameter("p_weight", DbType.Int16) { Value = account.Weight });
                command.Parameters.Add(new NpgsqlParameter("p_bodyfat", DbType.Int16) { Value = account.Bodyfat });

                }
                else
            {
                sql = "insert into userinfo(name,weight,height,born,password,bodyfat) values (:p,:p_weight,:p_height,:p_born,:p_pass,:p_bodyfat) ";
                command = new NpgsqlCommand(@sql, conn);
               
                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = account.Username });
                command.Parameters.Add(new NpgsqlParameter("p_pass", DbType.String) { Value = account.Password });
                command.Parameters.Add(new NpgsqlParameter("p_born", DbType.DateTime) { Value = account.Born });
                command.Parameters.Add(new NpgsqlParameter("p_height", DbType.Int16) { Value = account.Height });
                command.Parameters.Add(new NpgsqlParameter("p_weight", DbType.Int16) { Value = account.Weight });
                command.Parameters.Add(new NpgsqlParameter("p_bodyfat", DbType.Int16) { Value = account.Bodyfat });

            }



                Console.WriteLine(sql);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                Console.WriteLine(dataReader.HasRows);
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.ToString());
                    Console.WriteLine("Username : {0}", dataReader["name"]);
                }
                conn.Close();
            }
        }
        
        

        
    }
}
