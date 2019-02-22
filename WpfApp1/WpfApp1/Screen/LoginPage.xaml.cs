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
    /// LoginPage.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginPage : Page
    {
        
        private List<Uri> _uriList = new List<Uri>
        {
            new Uri("Screen/RegisterMainPage.xaml",UriKind.Relative),
            new Uri("Screen/TempPage.xaml",UriKind.Relative),
            new Uri("Screen/ErrorPage.xaml",UriKind.Relative),
        };
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_uriList[0]);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string _username=this.UsernameText.Text;
            string _password = this.PasswordText.Password;
            bool _isLogin = false;

            Login login = new Login();
            login.Username = _username;
            login.Password = _password;

            _isLogin = new LoginCheck().Check(login);

            if (_isLogin)
            {
                Properties.Settings.Default.Username = _username;
                Properties.Settings.Default.Save();
                this.NavigationService.Navigate(_uriList[1]);
            }
            else
            {
                this.NavigationService.Navigate(_uriList[2]);
                
            }
            
        }
    }
}
