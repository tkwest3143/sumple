using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.DBAccess
{
    /*
     * funcId=1->traning
     *      2->schedule
     *      3->meal      
     */
    class getDataList
    {
        NpgsqlConnection conn;
        private List<Object> _sqlList;

        
        public getDataList(string sql,string name,int funcId)
        {
            conn = new DBConnect().SqlConnect();
            NpgsqlCommand command;
            if (funcId == 1)
            {
                //traningのコマンド
            }
            else if (funcId == 2)
            {
                //scheduleのコマンド
            }
            else if (funcId == 3)
            {
                //mealのコマンド
            }
            else
            {
                //エラー処理
            }
            using (conn)
            {
                conn.Open();

                command = new NpgsqlCommand(sql, conn);

                Console.WriteLine(sql);
                NpgsqlDataReader _dr = command.ExecuteReader();
                while (_dr.Read())
                {
                   
                }
            }
        }
    }
}
