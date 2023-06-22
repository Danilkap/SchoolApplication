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
        public RedStudentPage()
        {
            InitializeComponent();
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
    }
}
