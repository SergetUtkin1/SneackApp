using SneackApp.AppData;
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
using System.Windows.Threading;

namespace SneackApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReview.xaml
    /// </summary>
    public partial class PageReview : Page
    {
        public PageReview()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var HistoryPupil = ConnectToDb.connObj.pupils.ToList();
            ListPupil.ItemsSource = HistoryPupil;
            ListPupil.ItemsSource = ConnectToDb.connObj.pupils.Where(x => x.FIO.StartsWith(TopTextBoxSearcher.Text) || x.Sex.StartsWith(TopTextBoxSearcher.Text)).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.setFrame.Navigate(new PageEdit((sender as Button).DataContext as pupils));
        }

        private void CheckSneakBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
