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
    /// Логика взаимодействия для PageSneakTable.xaml
    /// </summary>
    public partial class PageSneakTable : Page
    {
        public PageSneakTable()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var AllData = ConnectToDb.connObj.sneackers.ToList();
            MyTable.ItemsSource = AllData;
        }
    }
}
