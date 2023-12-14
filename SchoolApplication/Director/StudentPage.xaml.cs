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

namespace SchoolApplication.Director
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        private List<User> allItems;
        public StudentPage()
        {
            InitializeComponent();

            DgrStudent.ItemsSource = DbConnect.entObj.User.ToList();
            allItems = DbConnect.entObj.User.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgrStudent.ItemsSource = DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrStudent.Items.Count + "/" + DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as Class;
            var items = (select != null) ? allItems.Where(x => x.ClassId == select.ClassId) : allItems;
            DgrStudent.ItemsSource = items;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.Class.ToList();
                CmbFilter.DisplayMemberPath = "ClassName";
                CmbFilter.SelectedIndex = 0;

                DgrStudent.ItemsSource = DbConnect.entObj.User.Take(100).ToList();
                ResultTxb.Text = DgrStudent.Items.Count + "/" + DbConnect.entObj.User.Count().ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message,
                    "Упс, что-то пошло не так!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }
    }
}
