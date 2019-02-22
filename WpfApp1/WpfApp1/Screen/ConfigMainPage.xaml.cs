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
    /// ConfigMainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigMainPage : Page
    {
        private int weight;
        private int height;
        private int bodyfat;
        Account _account = new AccountGet().GetAccountInfo(Properties.Settings.Default.Username);
        public ConfigMainPage()
        {
            InitializeComponent();
        }

        private void ConfigChangeButton_Click(object sender, RoutedEventArgs e)
        {
            //入力されたテキストを取得
            string stringWeight = this.WeightConfig.Text;
            string stringHeight = this.HeightCongfig.Text;
            string stringBodyfat = this.BodyfatConfig.Text;

            //string型からint型へ変更
            weight = int.Parse(stringWeight);
            height = int.Parse(stringHeight);
            bodyfat = int.Parse(stringBodyfat);

            //アカウント情報に新しいパラメータを設定
            _account.Weight = weight;
            _account.Height = height;
            _account.Bodyfat = bodyfat;
            _account.Password = "";

            //設定変更処理
            new Register(_account);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            

            this.WeightConfig.Text=_account.Weight.ToString();
            this.HeightCongfig.Text = _account.Height.ToString();
            this.BodyfatConfig.Text = _account.Bodyfat.ToString();
            
        }
    }
}
