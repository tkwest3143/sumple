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

namespace WpfApp1.Screen
{
    /// <summary>
    /// RegisterComp.xaml の相互作用ロジック
    /// </summary>
    public partial class RegisterComp : Page
    {
        public RegisterComp()
        {
            InitializeComponent();
        }

        private void LoginMoveButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Screen/LoginPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
