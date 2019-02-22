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
using WpfApp1.Screen;
using WpfApp1.Model;

namespace WpfApp1.Screen
{
    /// <summary>
    /// RegisterMainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class RegisterMainPage : Page
    {
        private string _username;
        private string _passward;
        private DateTime _born;
        private int _height;
        private int _weight;
        private int _bodyfat;
        public RegisterMainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //入力テキストからパラメータを取得
            _username=this.InputUsernameLabel.Text;
            _passward = this.InputPassword.Password;

            //誕生日をDateTime型に型変換
            string year = this.InputBornYearLabel.Text;
            string month = this.InputBornMonthLabel.Text;
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            string day = this.InputBornDayLabel.Text;
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            string bornString = year + "/" + month + "/" + day;
            _born = DateTime.Parse(bornString);

            //string型のものをint型へと型変換
            _height = int.Parse(this.InputHeightLabel.Text);
            _weight = int.Parse(this.InputWeightLabel.Text);
            _bodyfat = int.Parse(this.InputBodyfatLabel.Text);

            //パラメータを格納
            Account account = new Account();
            account.Username = _username;
            account.Password = _passward;
            account.Born = _born;
            account.Height = _height;
            account.Weight = _weight;
            account.Bodyfat = _bodyfat;

            //登録処理
            new Register(account);

            //画面遷移
            Uri uri = new Uri("Screen/RegisterComp.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
