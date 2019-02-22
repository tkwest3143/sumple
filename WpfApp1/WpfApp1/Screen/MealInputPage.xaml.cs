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
    /// MealInputPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MealInputPage : Page
    {
        public MealInputPage()
        {
            InitializeComponent();
        }

        private void InputCompButton_Click(object sender, RoutedEventArgs e)
        {
            double strengthMultipl;
            string strength = this.StrengthBox.Text;

            if (strength.Equals("小"))
            {
                strengthMultipl = 1.0;
            }
            else if (strength.Equals("中"))
            {
                strengthMultipl = 1.3;
            }
            else
            {
                strengthMultipl = 1.5;
            }

            MetabolismCalc mc = new MetabolismCalc(strengthMultipl,int.Parse(this.WeightGoalBox.Text));

            MealDB dB = new MealDB(Properties.Settings.Default.Username, mc.getDayKcal());

            
            Uri uri = new Uri("Screen/MealMainPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
