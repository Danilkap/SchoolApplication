﻿using System;
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

namespace SchoolApplication.Student
{
    /// <summary>
    /// Логика взаимодействия для ListOfLessonPage.xaml
    /// </summary>
    public partial class ListOfLessonPage : Page
    {
        public ListOfLessonPage()
        {
            InitializeComponent();

            DgrLessons.ItemsSource = DbConnect.entObj.Lesson.ToList();
        }
     
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgrLessons.ItemsSource = DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Take(100).ToList();
                ResultTxb.Text = DgrLessons.Items.Count + "/" + DbConnect.entObj.Lesson.Where(x => x.LessonName.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
