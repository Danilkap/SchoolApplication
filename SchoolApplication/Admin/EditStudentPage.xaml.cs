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
    /// Логика взаимодействия для EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : Page
    {
        private List<User> allItems;
        public EditStudentPage()
        {
            InitializeComponent();

            DgrEditStudent.ItemsSource = DbConnect.entObj.User.ToList();
            allItems = DbConnect.entObj.User.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            DgrEditStudent.ItemsSource = DbConnect.entObj.User.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.RedStudentPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var studentRemoving = DgrEditStudent.SelectedItems.Cast<User>().ToList();
            try
            {
                string message = "Вы хотите удалить выбранного ученика?";
                var result = MessageBox.Show(message,
                                            "Уведомление",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.User.RemoveRange(studentRemoving);
                    DbConnect.entObj.SaveChanges();

                    DgrEditStudent.ItemsSource = DbConnect.entObj.User.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null | TxbName.Text.Trim() == "" |
               TxbDateOfBirth.Text == null | TxbDateOfBirth.Text.Trim() == "" |
               TxbEmail.Text == null | TxbEmail.Text.Trim() == "" |
               TxbLogin.Text == null | TxbLogin.Text.Trim() == "" |
               TxbPassword.Text == null | TxbPassword.Text.Trim() == "" |
               TxbClass.Text == null | TxbClass.Text.Trim() == "")
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
                    User userObj = new User()
                    {
                        UserName = TxbName.Text,
                        DateOfBirth = Convert.ToDateTime(TxbDateOfBirth.Text),
                        Email = TxbEmail.Text,
                        Login = TxbLogin.Text,
                        Password = TxbPassword.Text,
                        ClassId = Convert.ToInt32(TxbClass.Text),
                        RoleId = 1
                    };

                    DbConnect.entObj.User.Add(userObj);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Ученик добавлен",
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
                DgrEditStudent.ItemsSource = DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrEditStudent.Items.Count + "/" + DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Count().ToString();
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
            DgrEditStudent.ItemsSource = items;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.Class.ToList();
                CmbFilter.DisplayMemberPath = "ClassName";
                CmbFilter.SelectedIndex = 0;

                DgrEditStudent.ItemsSource = DbConnect.entObj.User.Take(100).ToList();
                ResultTxb.Text = DgrEditStudent.Items.Count + "/" + DbConnect.entObj.User.Count().ToString();
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
