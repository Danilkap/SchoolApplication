using SchoolApplication.AppFiles;
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

namespace SchoolApplication.Admin
{
    /// <summary>
    /// Логика взаимодействия для EditTeachersPage.xaml
    /// </summary>
    public partial class EditTeachersPage : Page
    {
        public EditTeachersPage()
        {
            InitializeComponent();

            DgrEditTeachers.ItemsSource = DbConnect.entObj.Teacher.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            DgrEditTeachers.ItemsSource = DbConnect.entObj.Teacher.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.AddTeachersPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var teacherRemoving = DgrEditTeachers.SelectedItems.Cast<Teacher>().ToList();
            try
            {
                string message = "Вы хотите удалить выбранные блюда?";
                var result = MessageBox.Show(message,
                                            "Уведомление",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.Teacher.RemoveRange(teacherRemoving);
                    DbConnect.entObj.SaveChanges();

                    DgrEditTeachers.ItemsSource = DbConnect.entObj.Teacher.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
