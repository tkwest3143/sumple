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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization.Charting;
using WpfApp1.Model;

namespace WpfApp1.Screen
{
    /// <summary>
    /// MealMainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MealMainPage : Page
    {
        Uri uri = new Uri("Screen/MealInputPage.xaml", UriKind.Relative);
        public MealMainPage()
        {
            InitializeComponent();

            //ここからグラフ表示(例としてsinグラフの表示をしている)
            var windowsFormsHost = (WindowsFormsHost)chartGrid.Children[0];
            var chart = (Chart)windowsFormsHost.Child;

            chart.ChartAreas.Add("ChartArea1");

            Series seriesSin = new Series();
            seriesSin.ChartType = SeriesChartType.Line;
            seriesSin.MarkerStyle = MarkerStyle.Circle;

            for(double x = 0; x <= 2 * Math.PI; x = x + 0.1)
            {
                seriesSin.Points.AddXY(x, Math.Sin(x));
            }
            chart.Series.Add(seriesSin);
        }

       

        private void MealInputButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(uri);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MealDB dB = new MealDB(Properties.Settings.Default.Username);

            this.NowKcalLabel.Content = dB.GetMeal().KcalDay;
        }
    }
}
