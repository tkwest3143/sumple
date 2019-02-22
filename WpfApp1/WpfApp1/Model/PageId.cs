using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
    /*
     * クラス名：画面URIクラス
     */ 
{
    class PageId
    {
        public  Uri RegisterMP= new Uri("Screen/RegisterMainPage.xaml",UriKind.Relative);
        public  Uri LoginMP =new Uri("Screen/LoginPage.xaml",UriKind.Relative);
        public  Uri TraningMP = new Uri("Screen/TraningMainPage.xaml",UriKind.Relative);
        public  Uri ScheduleMP = new Uri("Screen/ScheduleMainPage.xaml",UriKind.Relative);
        public  Uri MealMP = new Uri("Screen/MealMainPage.xaml",UriKind.Relative);
        public  Uri ConfigMP = new Uri("Screen/ConfigMainPage.xaml",UriKind.Relative);
        public  Uri ErrorP = new Uri("Screen/ErrorPage.xaml",UriKind.Relative);
        public  Uri RegisterCFP = new Uri("Screen/RegisterConfirm.xaml",UriKind.Relative);
        public  Uri RegisterCPP = new Uri("Screen/RegisterComp.xaml",UriKind.Relative);
        public  Uri PRecordP = new Uri("Screen/PastRecordPage.xaml",UriKind.Relative);
        public  Uri PScheduleP = new Uri("Screen/PastSchedulePage.xaml",UriKind.Relative);
        public  Uri PScheduleSP = new Uri("Screen/PastScheduleShowPage.xaml",UriKind.Relative);
        public  Uri ScheduleAP = new Uri("Screen/ScheduleAddPage.xaml",UriKind.Relative);
        public  Uri TraningIC = new Uri("Screen/TraningInputComp.xaml",UriKind.Relative);
    }
}
