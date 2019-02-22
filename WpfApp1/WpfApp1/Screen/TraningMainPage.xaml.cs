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
    /// TraningMainPage.xaml の相互作用ロジック
    /// </summary>
    
    
    public partial class TraningMainPage : Page
    {

        private DateTime _day=System.DateTime.Today;//今日の日付
        private int _weight;//使用重量
        private int _rep;//回数
        private string _big3name;//種目名
        private List<Uri> _uriList = new List<Uri>//画面遷移のためのuri
        {
            new Uri("Screen/TraningInputComp.xaml",UriKind.Relative),
            new Uri("Screen/PastRecordPage.xaml",UriKind.Relative),
        };

        public TraningMainPage()
        {
            InitializeComponent();
        }

        private void RecordRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //入力値からパラメータを取得
            _day=(DateTime)this.TodayLabel.Content;
            _weight = int.Parse(this.UseWeightText.Text);
            _rep = int.Parse(this.RepText.Text);

            //テーブル名となる_big3nameをコンボボックス選択値によって分岐
            if (this.big3name.Text.Equals("ベンチプレス"))
            {
                _big3name = "benchpress";  
            }else if (big3name.Text.Equals("スクワット"))
            {
                _big3name = "squat";
            }
            else
            {
                _big3name = "deadlift";
            }
                
            
            //使用重量から最大重量を計算し、DBへ登録
            int maxWeight = new MaxWeight().getMaxWeight(_big3name,_weight,_rep);
            new TraningResultInsert(_big3name, maxWeight,_weight,_rep);

            //画面遷移
            this.NavigationService.Navigate(_uriList[0]);
        }

        private void PastRecordButton_Click(object sender, RoutedEventArgs e)
        {
            //画面遷移
            this.NavigationService.Navigate(_uriList[1]);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //今日の日付をラベルに設定
            this.TodayLabel.Content = _day;
        }

        
    }
}
