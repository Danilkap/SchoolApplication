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
    /// Логика взаимодействия для EditLessonSchedulePage.xaml
    /// </summary>
    public partial class EditLessonSchedulePage : Page
    {
        public EditLessonSchedulePage()
        {
            InitializeComponent();

            DgrEditLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.AddLessonPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var lessonRemoving = DgrEditLessons.SelectedItems.Cast<Lesson>().ToList();
            try
            {
                string message = "Вы хотите удалить выбранные блюда?";
                var result = MessageBox.Show(message,
                                            "Уведомление",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.Lesson.RemoveRange(lessonRemoving);
                    DbConnect.entObj.SaveChanges();

                    DgrEditLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            DgrEditLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
        }
    }
}
