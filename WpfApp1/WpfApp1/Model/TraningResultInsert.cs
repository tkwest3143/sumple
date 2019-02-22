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
    class TraningResultInsert
    {
        private string username=Properties.Settings.Default.Username;
        private string sql;
        NpgsqlDataReader dataReader;

        public TraningResultInsert(string big3_name, int maxWeight,int weight,int rep)
        {
            this.sql = "insert into "+big3_name+"  (weight,date,name,useweight,rep) values (:p_weight,current_date,:p,:p_use,:p_rep)";

            NpgsqlConnection conn = new DBConnect().SqlConnect();
            using (conn)
            {
                conn.Open();
                var command = new NpgsqlCommand(@sql, conn);

                //sql文にユーザー名とパスワードを設定
                
                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = username });
                command.Parameters.Add(new NpgsqlParameter("p_weight", DbType.Int16) { Value = maxWeight });
                command.Parameters.Add(new NpgsqlParameter("p_use", DbType.Int16) { Value = weight });
                command.Parameters.Add(new NpgsqlParameter("p_rep", DbType.Int16) { Value = rep });


                dataReader = command.ExecuteReader();

                Console.WriteLine(dataReader.HasRows);
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.ToString());
                    Console.WriteLine("Username : {0}", dataReader["name"]);
                }
            }
        }
    }
}
