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
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnViewStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.EditStudentPage());
        }

        private void BtnViewTeacher_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.EditTeachersPage());
        }

        private void BtnViewLesson_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.EditLessonSchedulePage());
        }

        private void BtnViewSchoolNews_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin.EditSchoolNewsPage());
        }
    }
}
