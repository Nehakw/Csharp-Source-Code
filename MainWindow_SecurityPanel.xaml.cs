Lab 5: Security Panel Application (WPF application)
(use switch, display a date and time, and use PasswordBox’s  PasswordChar property)


A lab wants to install a security panel outside a laboratory room. Only authorized personnel may enter the lab, using their security codes. The following are valid security codes (also called access codes) and the groups of employees they represent:

Values			Groups

1645 or 1689		Technicians
8345			     Custodians
9998, 1006-1008 	Scientists

Once a security code is entered, access is either granted or denied. All access attempts are written to a window below the keypad. If access is granted, the date, time and group (scientists, custodians, etc.) are written to the window. If access is denied, the date, the time, and a message, “Access Denied,” are written to the window. Furthermore, the user can enter any one-digit access code to summon a security guard for assistance. The date, the time and a message, “Restricted Access,” then are written to the window to indicate that the request has been received.

Note: For security guard assistance, you are only allowed to type a single digit (0-9) and then hit # (enter).  So # key acts as enter key for all security codes.  ‘C’ key is used for erasing any digits typed in by mistake.


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

namespace Security_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void lstAccessCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clickOne(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 1;
        }
        private void clickTwo(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 2;
        }
        private void clickThree(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 3;
        }
        private void clickFour(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 4;
        }
        private void clickFive(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 5;
        }
        private void clickSix(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 6;
        }

        private void clickSeven(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 7;
        }

        private void clickEight(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 8;
        }

        private void clickNine(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 9;
        }

        private void clickZero(object sender, RoutedEventArgs e)
        {
            pswSecurityCode.Password += 0;
        }

        private void clickHash(object sender, RoutedEventArgs e)
        {
            try
            {
                int accessCode = 0;
                string accessMessage = "";
                accessCode = int.Parse(pswSecurityCode.Password);
                pswSecurityCode.Clear();

                switch (accessCode)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        accessMessage = "Restricted Access!";
                        break;
                    case 1645:
                    case 1689:
                        accessMessage = "Technicians";
                        break;
                    case 8345:
                        accessMessage = "Custodians";
                        break;
                    case 9998:
                    case 1006:
                    case 1007:
                    case 1008:
                        accessMessage = "Scientists";
                        break;
                    default:
                        accessMessage = "Access Denied!";
                        break;
                }
                lstAccessLog.Items.Add(DateTime.Now + " " + accessMessage);
            }
            catch(FormatException fEx)
            {
                lstAccessLog.Items.Add(fEx.Message);
            }
            catch(Exception ex)
            {
                lstAccessLog.Items.Add(ex.Message);
            }
        }

        private void clickClear(object sender, RoutedEventArgs e)
        {
            lstAccessLog.Items.Clear();
            pswSecurityCode.Clear();
        }
    }
}

