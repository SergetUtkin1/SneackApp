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

namespace SneackApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public PageEdit(pupils mpupil)
        {
            InitializeComponent();
            SexCB.SelectedIndex = 0;
            /*SexCB.SelectedValue = "pupil_id";
            SexCB.DisplayMemberPath = "Sex";*/
            var sexList = new List<string>() { "Мужык", "Баба"};
            SexCB.ItemsSource = sexList;

            PupilObj.Pupil_id = mpupil.pupil_id;

            FioTB.Text = mpupil.FIO;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<pupils> mpupils = ConnectToDb.connObj.pupils.Where(x => x.pupil_id == PupilObj.Pupil_id).AsEnumerable().
                Select(x => {

                    if (string.IsNullOrWhiteSpace(FioTB.Text))
                    {
                        x.FIO = "";
                    }
                    else
                    {
                        x.FIO = FioTB.Text;
                    }

                    x.Sex = (string)SexCB.SelectedValue;

                    return x;
                });

                foreach (pupils el in mpupils)
                {
                    ConnectToDb.connObj.Entry(el).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectToDb.connObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
            
        }
    }
}
