﻿using Microsoft.Win32;
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
       
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
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
    }
}
