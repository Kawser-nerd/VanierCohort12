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

namespace week2cls1Student
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // we are going to do backend code at thes part.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            // if we click on the button, only this method block will active
            // or work

            Student student = new Student();// student object
            student.student_name = textBoxName.Text;

            student.student_id = int.Parse(textBoxId.Text);
            // what we get from textbox is always String. We need to put
            // a convertion to conver the value from String to int,
            student.student_address = textBoxAddress.Text;
            student.student_registration = int.Parse(regYear.Text);
            printInfo(student);// passsing the student object in the printInfo method
            // To print everything on MessageBox
        }

        private void printInfo(Student student)
        {
            string toPrint = "The name of the student: " +
                student.student_name + '\n' +
                "The id of the student: " +
                student.student_id.ToString() + "\n" +
                "The address of the student: " +
                student.student_address + "\n" +
                "The registration year: " +
                student.student_registration.ToString();
            MessageBox.Show(toPrint);
        }
    }
}
