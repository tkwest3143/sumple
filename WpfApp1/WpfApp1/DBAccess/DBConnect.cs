using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace WpfApp1.DBAccess
{
    class DBConnect
    {
      //コネクションを返すメソッド
       public NpgsqlConnection SqlConnect()
        {
          //データベースに接続
            var connString = @"Server=localhost;port=5432;User Id=postgres;Password=Password;Database=:DatabaseName";
            var conn = new NpgsqlConnection(connString);


            return conn;

        }
    }
}
