using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1.Screen
{
    /// <summary>
    /// PastScheduleShowPage.xaml の相互作用ロジック
    /// </summary>
    public partial class PastScheduleShowPage : Page
    {
        private DateTime date;
        private string name;
        private List<Schedule> SL = new List<Schedule> { };
        public PastScheduleShowPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            date = Properties.Settings.Default.selectDate;
            name = Properties.Settings.Default.Username;

            SelectDateLabel.Content = date;
            scheduleDB dB = new scheduleDB(name, date);

            dB.selectSchedule(1);
            SL=dB.getSchedule();

            foreach (Schedule i in this.SL)
            {
                SelectScheduleList.Items.Add(i.time + ":" + i.text);
            }
        }
    }
}
