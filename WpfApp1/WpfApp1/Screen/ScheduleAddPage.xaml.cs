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
    /// ScheduleAddPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ScheduleAddPage : Page
    {
        public ScheduleAddPage()
        {
            InitializeComponent();
        }

        //スケジュール追加ボタンクリック時の操作
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string _inputTitle = this.InputTitle.Text;
            string _inputDescription = this.InputDescription.Text;
            DateTime _inputDay = DateTime.Parse(this.InputDay.Text);
            TimeSpan _inputTimeSpan = TimeSpan.Parse(this.InputHour.Text +":"+this.InputMinute.Text);

            Schedule schedule = new Schedule
            {
                username=Properties.Settings.Default.Username,
                text=_inputTitle,
                description=_inputDescription,
                day=_inputDay,
                time=_inputTimeSpan,
            };

            scheduleDB dB = new scheduleDB(schedule);
            dB.insertSchedule();

        }
    }
}
