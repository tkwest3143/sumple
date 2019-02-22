using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //登録のための情報を格納するクラス
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Bodyfat { get; set; }
        public DateTime Born { get; set; }
    }
}
