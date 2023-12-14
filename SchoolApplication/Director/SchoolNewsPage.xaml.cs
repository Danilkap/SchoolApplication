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

namespace SchoolApplication.Director
{
    /// <summary>
    /// Логика взаимодействия для SchoolNewsPage.xaml
    /// </summary>
    public partial class SchoolNewsPage : Page
    {
        public SchoolNewsPage()
        {
            InitializeComponent();

            DgrNews.ItemsSource = DbConnect.entObj.News.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgrNews.ItemsSource = DbConnect.entObj.News.Where(x => x.NameNews.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrNews.Items.Count + "/" + DbConnect.entObj.News.Where(x => x.NameNews.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
