using Microsoft.Data.Sqlite;
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
    /// Логика взаимодействия для RedSchoolNewsPage.xaml
    /// </summary>
    public partial class RedSchoolNewsPage : Page
    {
        public RedSchoolNewsPage()
        {
            InitializeComponent();
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRedProduct_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.News.Count(x => x.NameNews == TxbName.Text) > 0)
            {
                MessageBox.Show("Такое пользователь уже есть!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                return;
            }
            else if (TxbDate.Text == null | TxbDate.Text.Trim() == "" |
                     TxbName.Text == null | TxbName.Text.Trim() == "" |
                     TxbText.Text == null | TxbText.Text.Trim() == "")
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
                  int num = Convert.ToInt32(TxbNewsId.Text);
                  var dRow = DbConnect.entObj.News.Where(w => w.NewsId == num).FirstOrDefault();
                    News newsObj = new News()
                    {
                        NameNews = TxbName.Text,
                        Date = Convert.ToDateTime(TxbDate.Text),
                        Text = TxbText.Text,
                        Image = ImgNews.Source.ToString()
                    };

                    DbConnect.entObj.News.Remove(newsObj);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
