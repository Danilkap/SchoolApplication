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
using SchoolApplication.AppFiles;

namespace SchoolApplication
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {          
            if (DbConnect.entObj.User.Count(x => x.Login == TxbLogin.Text) > 0)
            {
               FrameApp.frmObj.Navigate( new Student.StudentMenuPage()); 

            }else
             {
               MessageBox.Show("Данные введены неверно!",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
             }

            if (TxbLogin.Text == "fff" || PsbPassword.Password == "123")
            {
                FrameApp.frmObj.Navigate(new Admin.AdminMenuPage());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
