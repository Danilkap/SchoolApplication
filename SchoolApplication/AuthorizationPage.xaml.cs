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

namespace SchoolApplication
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userObj = DbConnect.entObj.User.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
            if (userObj == null)
            {
                 MessageBox.Show("Такой пользователь не найден.",
                                 "Уведомление",
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information);

            }
            else
            {
               switch (userObj.RoleId)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте, пользователь " + userObj.UserName,
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new Student.StudentMenuPage());
                        break;

                    case 2:
                        MessageBox.Show("Здравствуйте, администратор " + userObj.UserName,
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        FrameApp.frmObj.Navigate(new Admin.AdminMenuPage());
                        break;
                }
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
