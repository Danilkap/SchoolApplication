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
    /// Логика взаимодействия для AddLessonPage.xaml
    /// </summary>
    public partial class AddLessonPage : Page
    {
        public AddLessonPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Lesson.Count(x => x.LessonName == TxbName.Text) > 0)
            {
                MessageBox.Show("Такое пользователь уже есть!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
            else if (TxbName.Text == null | TxbName.Text.Trim() == "" |
                     TxbDate.Text == null | TxbDate.Text.Trim() == "" |
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
                        Date = Convert.ToDateTime(TxbDate.Text),
                        TeacherId = Convert.ToInt32(TxbTeacher.Text)
                    };

                    DbConnect.entObj.Lesson.Add(lessonObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Блюдо создано",
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
