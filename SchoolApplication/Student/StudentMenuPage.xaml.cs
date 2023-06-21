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

namespace SchoolApplication.Student
{
    /// <summary>
    /// Логика взаимодействия для StudentMenuPage.xaml
    /// </summary>
    public partial class StudentMenuPage : Page
    {
        public object Left { get; internal set; }
        public object Top { get; internal set; }

        public StudentMenuPage()
        {
            InitializeComponent();
        }

        private void BtnListOfLesson_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Student.ListOfLessonPage());
        }

        private void BtnSchoolNews_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Student.SchoolNewsPage());
        }

        private void BtnTeasherStaff_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Student.TeachingStaffPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
