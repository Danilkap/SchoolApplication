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
    /// Логика взаимодействия для RedLessonPage.xaml
    /// </summary>
    public partial class RedLessonPage : Page
    {
        public RedLessonPage()
        {
            InitializeComponent();

            DgrRedLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnRedLesson_Click(object sender, RoutedEventArgs e)
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
                    int num = Convert.ToInt32(TxbLessonId.Text);
                    var lesRow = DbConnect.entObj.Lesson.Where(w => w.LessonId == num).FirstOrDefault();
                    lesRow.LessonName = TxbName.Text;
                    lesRow.TeacherId = Convert.ToInt32(TxbTeacher.Text);

                    DbConnect.entObj.SaveChanges();
                    DbConnect.entObj.News.ToList();

                    MessageBox.Show("Изменено",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                    DgrRedLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var lessonRemoving = DgrRedLessons.SelectedItems.Cast<Lesson>().ToList();
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

                    DgrRedLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgrRedLessons.ItemsSource = DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrRedLessons.Items.Count + "/" + DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            DgrRedLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
        }
    }
}
