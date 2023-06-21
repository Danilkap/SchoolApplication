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
    /// Логика взаимодействия для EditSchoolNewsPage.xaml
    /// </summary>
    public partial class EditSchoolNewsPage : Page
    {
        public EditSchoolNewsPage()
        {
            InitializeComponent();

            DgrEditNews.ItemsSource = DbConnect.entObj.News.ToList();
          
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
       
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            DgrEditNews.ItemsSource = DbConnect.entObj.News.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.AddSchoolNewsPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var newsRemoving = DgrEditNews.SelectedItems.Cast<News>().ToList();
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

                    DgrEditNews.ItemsSource = DbConnect.entObj.News.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.RedSchoolNewsPage());
        }
    }
}
