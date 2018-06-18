Project 2: A simple Employee-Pay Calculator (WPF Application)

Develop a WPF application that has a button to calculate an employee’s weekly pay, given the number of hours worked. An employee should have a first name, last name, age, and hourly consulting rate. You should be able to create an employee object and provide the hours worked to calculate the weekly pay. The application assumes a standard workweek of 40 hours. Any hours worked over 40 hours in a week are considered overtime and earn time and a half. Salary for time and a half is calculated by multiplying the employee’s hourly wage by 1.5 and multiplying the result of that calculation by the number of overtime hours worked. This value is then added to the user’s earnings for the regular 40 hours of work to calculate the total earnings for that week.


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

namespace Payroll_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Employee
        {
            public string fName, lName;
            public int age;
            public double weeklyHours;
            public decimal hoursWage, totalSalary;
            public const int hourLimit = 40;

            public void GetName(string fiName, string liName)   
            {
                fName = fiName;
                lName = liName;
            }
            public void GetAge(int empAge)
            {
                age = empAge;
            }
            public decimal CalculateWage(double weekHours, decimal wageOfhour)
            {
                weeklyHours = weekHours;
                hoursWage = wageOfhour;
                
                if (weekHours <= hourLimit)
                {
                    totalSalary = (decimal)weekHours * wageOfhour;
                }
                else
                {
                    totalSalary = hourLimit * wageOfhour;
                    totalSalary += totalSalary + (decimal)(weekHours - hourLimit) * (1.5M * wageOfhour);
                }
                return totalSalary;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void calculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.GetName(Convert.ToString(txtFirst.Text), Convert.ToString(txtLast.Text));
                emp.GetAge(Convert.ToInt32(txtAge.Text));
                decimal gross = emp.CalculateWage(Convert.ToDouble(txtWeekly.Text), Convert.ToDecimal(txtWage.Text));
                String result = Convert.ToString(gross);
                txtGross.Text = String.Format("{0:C}", result);

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirst.Text, "^[a-zA-Z]"))
                {
                    txtResult.Text = ("Name not in correct format!");
                    txtGross.Text = "";
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtLast.Text, "^[a-zA-Z]"))
                {
                    txtResult.Text = ("Name not in correct format!");
                    txtGross.Text = "";
                }
            }
            catch (FormatException fEx)
            {
                txtResult.Text = fEx.Message;
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}



