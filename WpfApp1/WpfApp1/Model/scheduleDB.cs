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
    class scheduleDB
    {
        //SQL文
        string sql;
        //コマンド
        private NpgsqlCommand command;
        //DB接続のためのコネクション
        NpgsqlConnection conn = new DBConnect().SqlConnect();
        //スケジュールの項目リストの初期化
        private List<Schedule> _scheduleList = new List<Schedule> { };
        //SQL文に条件をセットするためのパラメータのリストの初期化
        List<NpgsqlParameter> paramList=new List<NpgsqlParameter> { };
        
        //コンストラクタ：引数をSQL文の条件のためのリストにセット
        public scheduleDB(Schedule schedule)
        { 
            paramList = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_u", DbType.String){ Value = schedule.username },
                new NpgsqlParameter("p_t", DbType.String) { Value =schedule. text },
                new NpgsqlParameter("p_d", DbType.DateTime) { Value = schedule.day },
                new NpgsqlParameter("p_ti", DbType.Time) { Value = schedule.time }, 
                new NpgsqlParameter("p_de", DbType.String) { Value = schedule.description },
               
            };
        }
        public scheduleDB(string username,DateTime day)
        {
            paramList = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_u", DbType.String){ Value = username },
                new NpgsqlParameter("p_d", DbType.DateTime) { Value = day },
            };
        }

        
        //リストにDBから取得したものを格納
        public void addScheduleList(NpgsqlDataReader dataReader)
        {
            
            while (dataReader.Read())
            {
                Schedule schedule = new Schedule
                {
                    username = (string)dataReader["name"],
                    text = (string)dataReader["text"],
                    day = (DateTime)dataReader["day"],
                    time = (TimeSpan)dataReader["time"],
                };
                this._scheduleList.Add(schedule);
            }
            
        }

        //SELECT文を実行する
        public void selectSchedule(int frag)
        {
            using (conn)
            {
                conn.Open();
                
                if (frag == 1)
                {
                    //frag=1の時、設定した日付の条件で取得する
                    sql = "SELECT * FROM schedule where name=:p_u and day=:p_d";
                    command = new NpgsqlCommand(@sql, conn);

                    command.Parameters.Add(paramList[0]);
                    command.Parameters.Add(paramList[1]);
                }else if (frag == 2)
                {
                    //frag=2の時、設定した日付の条件で取得しない(名前のみ)
                    sql = "SELECT * FROM schedule where name=:p_u";
                    command = new NpgsqlCommand(@sql, conn);

                    command.Parameters.Add(paramList[0]);
                }
                NpgsqlDataReader _dr = command.ExecuteReader();
                Console.WriteLine(sql);
                addScheduleList(_dr);

                conn.Close();
            }
        }

        public void insertSchedule()
        {
            
            using (conn)
            {
                conn.Open();
                if (paramList.Count == 5)
                {
                    sql = "insert into schedule(name,text,day,time,description) values (:p_u,:p_t,:p_d,:p_ti,:p_de)";
                    command = new NpgsqlCommand(@sql, conn);
                    command.Parameters.Add(paramList[0]);
                    command.Parameters.Add(paramList[1]);
                    command.Parameters.Add(paramList[2]);
                    command.Parameters.Add(paramList[3]);
                    command.Parameters.Add(paramList[4]);
                }
                else if (paramList.Count == 4)
                {
                    sql = "insert into schedule(name,text,day,time) values (:p_u,:p_t,:p_d,:p_ti)";
                    command = new NpgsqlCommand(@sql, conn);
                    command.Parameters.Add(paramList[0]);
                    command.Parameters.Add(paramList[1]);
                    command.Parameters.Add(paramList[2]);
                    command.Parameters.Add(paramList[3]);
                }
                Console.WriteLine(sql);
                command.ExecuteReader();
                conn.Close();

            }
        }
        public List<Schedule> getSchedule()
        {
            return this._scheduleList;
        }
    }
}
