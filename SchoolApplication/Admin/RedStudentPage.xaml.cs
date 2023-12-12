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
    /// Логика взаимодействия для RedStudentPage.xaml
    /// </summary>
    public partial class RedStudentPage : Page
    {
        private List<User> allItems;
        public RedStudentPage()
        {
            InitializeComponent();

            DgrRedStudent.ItemsSource = DbConnect.entObj.User.ToList();
            allItems = DbConnect.entObj.User.ToList();
        }

        private void BtnRedStudent_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null | TxbName.Text.Trim() == "" |
                    TxbDateOfBirth.Text == null | TxbDateOfBirth.Text.Trim() == "" |
                    TxbEmail.Text == null | TxbEmail.Text.Trim() == "" |
                    TxbLogin.Text == null | TxbLogin.Text.Trim() == "" |
                    TxbPassword.Text == null | TxbPassword.Text.Trim() == ""|
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
                    int num = Convert.ToInt32(TxbStudentId.Text);
                    var newsRow = DbConnect.entObj.User.Where(w => w.UserId == num).FirstOrDefault();
                    newsRow.UserName = TxbName.Text;
                    newsRow.DateOfBirth = Convert.ToDateTime(TxbDateOfBirth.Text);
                    newsRow.Email = TxbEmail.Text;
                    newsRow.Login = TxbLogin.Text;
                    newsRow.Password = TxbPassword.Text;
                    newsRow.ClassId = Convert.ToInt32(TxbClass.Text);

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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var studentRemoving = DgrRedStudent.SelectedItems.Cast<User>().ToList();
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

                    DgrRedStudent.ItemsSource = DbConnect.entObj.User.ToList();
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
                DgrRedStudent.ItemsSource = DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrRedStudent.Items.Count + "/" + DbConnect.entObj.User.Where(x => x.UserName.Contains(TxbSearch.Text)).Count().ToString();
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
            DgrRedStudent.ItemsSource = items;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.Class.ToList();
                CmbFilter.DisplayMemberPath = "ClassName";
                CmbFilter.SelectedIndex = 0;

                DgrRedStudent.ItemsSource = DbConnect.entObj.User.Take(100).ToList();
                ResultTxb.Text = DgrRedStudent.Items.Count + "/" + DbConnect.entObj.User.Count().ToString();
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
