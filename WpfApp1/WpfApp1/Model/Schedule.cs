using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Schedule
    {
        public string username { get; set; }
        public string text { get; set; }
        public DateTime day { get; set; }
        public TimeSpan time { get; set; }
        public string description { get; set; }
    }
}
