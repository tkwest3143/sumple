using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DBAccess;
using Npgsql;
using System.Data;

namespace WpfApp1.Model
{
    class MealDB
    {
        private string sql;
        private Meal meal = new Meal();

        /*
         * コンストラクタ
         *  @param name：登録するための名前
         *  @param kcal：一日に目標とするカロリー
         */

        public MealDB(string name, int kcal)
        {
            //sql = "insert into kcaltable(name,date,kcalDay) values (:p,:p_d,:p_k)";
            sql = Properties.SQLSettings.Default.CalorieInsert;
            NpgsqlConnection conn = new DBConnect().SqlConnect();

            using (conn)
            {
                conn.Open();
                var command = new NpgsqlCommand(@sql, conn);

                DateTime date = DateTime.Now;

                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = name });
                command.Parameters.Add(new NpgsqlParameter("p_d", DbType.DateTime) { Value = date });
                command.Parameters.Add(new NpgsqlParameter("p_k", DbType.Int16) { Value = kcal });
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    meal.Name = (string)dr["name"];
                    meal.Date = (DateTime)dr["date"];
                    meal.KcalDay = (Int16)dr["kcalDay"];
                }
            }
        }
        public MealDB(string name)
        {
            sql = "select name, date, kcalday from  kcaltable  where name=:p";

            NpgsqlConnection conn = new DBConnect().SqlConnect();

            using (conn)
            {
                conn.Open();
                var command = new NpgsqlCommand(@sql, conn);



                command.Parameters.Add(new NpgsqlParameter("p", DbType.String) { Value = name });


                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    meal.Name = (string)dr["name"];
                    meal.Date = (DateTime)dr["date"];
                    meal.KcalDay = (int)dr["kcalday"];
                }
            }
        }
            /*
             * Mealインスタンスを返すメソッド
             */
            public Meal GetMeal()
            {
                return this.meal;
            }
        }
} 

