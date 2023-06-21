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
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnRedProduct_Click(object sender, RoutedEventArgs e)
        {
           
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
    }
}
