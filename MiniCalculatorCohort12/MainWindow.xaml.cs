using MiniCalculatorCohort12.Models;
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

namespace MiniCalculatorCohort12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(inpA.Text);
            double b = double.Parse(inpB.Text);

            Results.Text = calc.getAddition(a, b).ToString();
        }

        private void Substraction_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(inpA.Text);
            double b = double.Parse(inpB.Text);

            Results.Text = calc.getSubstraction(a,b).ToString();
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(inpA.Text);
            double b = double.Parse(inpB.Text);

            Results.Text = calc.getMultiplication(a,b).ToString();  
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(inpA.Text);
            double b = double.Parse(inpB.Text);

            Results.Text = calc.getDivision(a,b).ToString();
        }

        private void Modulus_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(inpA.Text);
            double b = double.Parse(inpB.Text);

            Results.Text = calc.getModulus(a,b).ToString();
        }
    }
}
