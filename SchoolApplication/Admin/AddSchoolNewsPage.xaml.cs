using Microsoft.Win32;
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
    /// Логика взаимодействия для AddSchoolNewsPage.xaml
    /// </summary>
    public partial class AddSchoolNewsPage : Page
    {
        public AddSchoolNewsPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
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
                    News newsObj = new News()
                    {
                        NameNews = TxbName.Text,
                        Date = Convert.ToDateTime(TxbDate.Text),
                        Text = TxbText.Text,
                        Image = ImgNews.Source.ToString()
                    };

                    DbConnect.entObj.News.Add(newsObj);
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

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.jpeg;*png;*tif|All files|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                Uri imageUri = new Uri(openFileDialog.FileName);
                ImgNews.Source = new BitmapImage(imageUri);
            }
        }
    }
}
