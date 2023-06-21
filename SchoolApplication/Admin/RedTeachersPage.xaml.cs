﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для RedTeachersPage.xaml
    /// </summary>
    public partial class RedTeachersPage : Page
    {
        public RedTeachersPage()
        {
            InitializeComponent();
        }

        private void BtnRedTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == null | TxbName.Text.Trim() == ""|
                TxbDateOfBirth.Text == null | TxbDateOfBirth.Text.Trim() == "")
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
                    int num = Convert.ToInt32(TxbTeacherId.Text);
                    var teacRow = DbConnect.entObj.Teacher.Where(w => w.TeacherId == num).FirstOrDefault();
                    teacRow.TeacherName= TxbName.Text;
                    teacRow.DateOfBirth = Convert.ToDateTime(TxbDateOfBirth.Text);
                    teacRow.Image = ImgTeacher.Source.ToString();

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

        private void BtnRedImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.jpeg;*png;*tif|All files|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                Uri imageUri = new Uri(openFileDialog.FileName);
                ImgTeacher.Source = new BitmapImage(imageUri);
            }
        }
    }
}
