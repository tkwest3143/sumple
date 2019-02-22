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
    /// ScheduleMainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ScheduleMainPage : Page
    {
        //今日の日付
        private DateTime today = System.DateTime.Today;
        //今の時間
        private TimeSpan _time = DateTime.Now.TimeOfDay;
        //スケジュールを格納するためのリスト
        private List<Schedule> _scheduleList;
        //画面遷移のためのuriの設定
        private List<Uri> _uri_List = new List<Uri>
        {
            new Uri("Screen/PastScheduleShowPage.xaml",UriKind.Relative),
            new Uri("Screen/ScheduleAddPage.xaml",UriKind.Relative),
        };
        
        public ScheduleMainPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            scheduleDB schedule = new scheduleDB(Properties.Settings.Default.Username, today);
            schedule.selectSchedule(1);
            _scheduleList =schedule.getSchedule();
            this.TodayShowLabel.Content = today;

            foreach(Schedule i in this._scheduleList)
            {
                ScheduleList.Items.Add(i.time+":"+i.text);
            }
        }

        private void ScheduleShowButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)SelectDatePicker.SelectedDate;
            Properties.Settings.Default.selectDate = date;
            this.NavigationService.Navigate(_uri_List[0]);
        }

        private void ScheduleAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_uri_List[1]);
        }
    }
}
