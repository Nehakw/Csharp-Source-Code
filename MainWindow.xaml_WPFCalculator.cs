Project 3: A Calculator Project (WPF Application) 

The purpose of this project is twofold.  First is to be familiarized with how classes and objects work in C#. Second is to follow best practices in object-oriented modeling by separating project model into two parts, the GUI and the business logic.

The project is to develop a simple calculator similar to what you find on your Windows platform. However, we simplify the problem by limiting operands to one digit numbers and operators to the four functions add, subtract, multiply, and divide. You should also have function keys for “On”, “Off”, and “Clear”.

A typical use-case scenario for adding 2 and 3 will do the following steps:
Turn on the calculator
Press the “2” button – 2 appears in the display
Press the “+” button
Press the “3” button – 3 appears in the display
Press the “=” button – 5 appears in the display
Press the “C” button – clears the calculator
Or
Press the “Off” button – turns off the calculator.

As was noticed, an infix notation was used. Infix notation means you enter an operand, say 2, then the operator, +, then the other operand, say 3, and then press = to obtain the result. The calculator will compute with single digit whole numbers. 

In order to make future changes and maintenance easier, calculator model is initially divided into two classes:

The interface (buttons and display) that you use to run the calculator
The “engine” that actually performs the calculations


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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator cal = new Calculator();

        double val1 = 0.0;
        double val2 = 0.0;
        string operation = " ";

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnZero(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) ;
            txtResult.Text = val1.ToString();
        }

        private void btnOne(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 1;
            txtResult.Text = val1.ToString();
        }

        private void btnTwo(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 2;
            txtResult.Text = val1.ToString();
        }

        private void btnThree(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 3;
            txtResult.Text = val1.ToString();
        }

        private void btnFour(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 4;
            txtResult.Text = val1.ToString();
        }

        private void btnFive(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 5;
            txtResult.Text = val1.ToString();
        }

        private void btnSix(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 6;
            txtResult.Text = val1.ToString();
        }

        private void btnSeven(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 7;
            txtResult.Text = val1.ToString();
        }

        private void btnEight(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 8;
            txtResult.Text = val1.ToString();
        }

        private void btnNine(object sender, RoutedEventArgs e)
        {
            val1 = (val1 * 10) + 9;
            txtResult.Text = val1.ToString();
        }

        private void btnOn(object sender, RoutedEventArgs e)
        {
            txtResult.IsEnabled = true;
            txtResult.Text = "0";
        }

        private void btnOff(object sender, RoutedEventArgs e)
        {
            txtResult.Text = string.Empty;
            val1 = 0;
            val2 = 0;
            operation = "";
        }

        private void btnEquals(object sender, RoutedEventArgs e)
        {
            try
            {
                switch(operation)
                {
                  case "+":
                     txtResult.Text = (cal.Add(val2, val1)).ToString();
                     break;
                  case "/":
                     txtResult.Text = (cal.Divide(val2, val1)).ToString();
                     break;
                  case "*":
                     txtResult.Text = (cal.Multiply(val2, val1)).ToString();
                     break;
                  case "-":
                     txtResult.Text = (cal.Subtract(val2, val1)).ToString();
                     break;
                }
                    operation = " ";
            }
            catch (FormatException fEx)
            {
                txtResult.Text = fEx.Message;
            }
            catch (DivideByZeroException dzEx)
            {
                txtResult.Text = dzEx.Message;
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            txtResult.Clear();
            val1 = 0;
            val2 = 0;
            operation = "";
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            val2 = val1;
            operation = "+";
            txtResult.Text = "";
            val1 = 0;
        }

        private void btnDivide(object sender, RoutedEventArgs e)
        {
            val2 = val1;
            operation = "/";
            txtResult.Text = "";
            val1 = 0;
        }

        private void btnMultiply(object sender, RoutedEventArgs e)
        {
            val2 = val1;
            operation = "*";
            txtResult.Text = "";
            val1 = 0;
        }

        private void btnSubtract(object sender, RoutedEventArgs e)
        {
            val2 = val1;
            operation = "-";
            txtResult.Text = "";
            val1 = 0;
        }
    }
}
