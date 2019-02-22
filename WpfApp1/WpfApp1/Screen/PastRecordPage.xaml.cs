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
    /// PastRecordPage.xaml の相互作用ロジック
    /// </summary>
    public partial class PastRecordPage : Page
    {
        //トレーニングのデータをそれぞれのリストに格納
        List<Traning> benchList=new TraningResultSelect("benchpress").getTraningList();
        List<Traning> squatList = new TraningResultSelect("squat").getTraningList();
        List<Traning> deadList = new TraningResultSelect("deadlift").getTraningList();
        List<Traning> big3List = new List<Traning>  { };

        //トレーニング記録のパラメータ
        private int benchUse;
        private int benchRep;
        private int benchMax;
        private int squatUse;
        private int squatRep;
        private int squatMax;
        private int deadUse;
        private int deadRep;
        private int deadMax;

        public PastRecordPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            benchMax = benchList[benchList.Count-1].MaxWeight;
            benchRep= benchList[benchList.Count-1].Rep;
            benchUse = benchList[benchList.Count-1].UseWeight;

            squatMax = squatList[squatList.Count - 1].MaxWeight;
            squatRep = squatList[squatList.Count - 1].Rep;
            squatUse = squatList[squatList.Count - 1].UseWeight;

            deadMax = deadList[deadList.Count - 1].MaxWeight;
            deadRep = deadList[deadList.Count - 1].Rep;
            deadUse = deadList[deadList.Count - 1].UseWeight;

            int maxBig3 = (benchMax + squatMax + deadMax);

            
           


            string bench = benchMax + "kg  (" + benchUse + "kg *" + benchRep + "rep)";
            string squat = squatMax + "kg  (" + squatUse + "kg *" + squatRep + "rep)";
            string dead = deadMax + "kg  (" + deadUse + "kg *" + deadRep + "rep)";
            string big3 = "合計重量は"+maxBig3+"kg";

            RecordBenchpress.Content = bench;
            RecordSquat.Content = squat;
            RecordDeadlift.Content = dead;

            RecordBig3.Content = big3;

            //ここからグラフ表示(例としてsinグラフの表示をしている)
            var windowsFormsHost = (WindowsFormsHost)ChartGrid.Children[0];
            var chart = (Chart)windowsFormsHost.Child;

            chart.ChartAreas.Add("ChartArea1");

            Series seriesSin = new Series();
            seriesSin.ChartType = SeriesChartType.Line;
            seriesSin.MarkerStyle = MarkerStyle.Circle;

            foreach (Traning i in this.benchList)
            {
                seriesSin.Points.AddXY(i.Date, i.MaxWeight);
            }
            
            chart.Series.Add(seriesSin);


        }
    }
}
