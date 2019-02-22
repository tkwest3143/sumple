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
    /// TempPage.xaml の相互作用ロジック
    /// </summary>
   
    public partial class TempPage : Page
    {
        private NavigationService _navi;
        
        PageId PI = new PageId();
        public TempPage()
        {
            InitializeComponent();
            _navi = this.ContentFrame.NavigationService;
        }

        private void ContentFrame_Loaded(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(PI.TraningMP);
            TitleLabel.Content = "トレーニング";
            LoginNameLabel.Content = Properties.Settings.Default.Username;
        }

        private void TraningSideButton_Click(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(PI.TraningMP);
            TitleLabel.Content = "トレーニング";
        }

        private void ScheduleSideButton_Click(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(PI.ScheduleMP);
            TitleLabel.Content = "スケジュール";
        }

        private void MealSideButton_Click(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(PI.MealMP);
            TitleLabel.Content = "食事目標";
        }

        private void ConfigSideButton_Click(object sender, RoutedEventArgs e)
        {
            _navi.Navigate(PI.ConfigMP);
            TitleLabel.Content = "設定";
        }
    }
}
