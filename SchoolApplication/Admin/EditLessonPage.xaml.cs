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
        
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.RedLessonPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var lessonRemoving = DgrEditLessons.SelectedItems.Cast<Lesson>().ToList();
            try
            {
                string message = "Вы хотите удалить выбранный предмет?";
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddLesson_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null | TxbName.Text.Trim() == "" |
                TxbTeacher.Text == null | TxbTeacher.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    Lesson lessonObj = new Lesson()
                    {
                        LessonName = TxbName.Text,
                        TeacherId = Convert.ToInt32(TxbTeacher.Text)
                    };

                    DbConnect.entObj.Lesson.Add(lessonObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Предмет создан",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    FrameApp.frmObj.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                    "Критический сбой работы приложения",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgrEditLessons.ItemsSource = DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrEditLessons.Items.Count + "/" + DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
