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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public AddStudentPage()
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
            else if (TxbName.Text == null | TxbName.Text.Trim() == "" |
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
                        Image = ImgStudent.Source.ToString()
                    };

                    DbConnect.entObj.User.Add(userObj);
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
                ImgStudent.Source = new BitmapImage(imageUri);
            }
        }
    }
}
