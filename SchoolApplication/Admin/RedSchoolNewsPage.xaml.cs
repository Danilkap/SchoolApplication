using Microsoft.Data.Sqlite;
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
    /// Логика взаимодействия для RedSchoolNewsPage.xaml
    /// </summary>
    public partial class RedSchoolNewsPage : Page
    {

        public RedSchoolNewsPage()
        {
            InitializeComponent();

            DgrRedNews.ItemsSource = DbConnect.entObj.News.ToList();
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnRedNews_Click(object sender, RoutedEventArgs e)
        {
            if (TxbNewsId.Text == null | TxbNewsId.Text.Trim() == "" |
                    TxbDate.Text == null | TxbDate.Text.Trim() == "" |
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
                    var newsRow = DbConnect.entObj.News.Where(w => w.NewsId == num).FirstOrDefault();
                    newsRow.NameNews = TxbName.Text;
                    newsRow.Date = Convert.ToDateTime(TxbDate.Text);
                    newsRow.Text = TxbText.Text;
                    newsRow.Image = ImgNews.Source.ToString();

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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var newsRemoving = DgrRedNews.SelectedItems.Cast<News>().ToList();
            try
            {
                string message = "Вы хотите удалить выбраную новость?";
                var result = MessageBox.Show(message,
                                            "Уведомление",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.News.RemoveRange(newsRemoving);
                    DbConnect.entObj.SaveChanges();

                    DgrRedNews.ItemsSource = DbConnect.entObj.News.ToList();
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
                DgrRedNews.ItemsSource = DbConnect.entObj.News.Where(x => x.NameNews.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrRedNews.Items.Count + "/" + DbConnect.entObj.News.Where(x => x.NameNews.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
