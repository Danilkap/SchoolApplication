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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
