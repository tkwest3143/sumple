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
    class TraningResultSelect
    {
        private string username=Properties.Settings.Default.Username;
        private string sql;
        NpgsqlDataReader dataReader;
        private List<Traning> traningList = new List<Traning>
        {

        };

        public TraningResultSelect(string big3_name)
        {
            this.sql = "select weight,date,name,useweight,rep from "+big3_name+" where name=:p";

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
                    Traning traning = new Traning();
                    traning.MaxWeight = (int)dataReader["weight"];
                    traning.Date = (DateTime)dataReader["date"];
                    traning.UseWeight = (int)dataReader["useweight"];
                    traning.Rep = (int)dataReader["rep"];
                    Console.WriteLine(dataReader.ToString());
                    Console.WriteLine("Username : {0}", dataReader["name"]);
                    traningList.Add(traning);
                }
            }
        }
        public List<Traning> getTraningList()
        {
            return this.traningList;
        }
    }
}
