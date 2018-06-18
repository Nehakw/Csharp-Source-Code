An organization is hosting a fundraiser to collect donations. A portion of each donation is used to cover the operating expenses of the organization; the rest of the donation goes to the charity. Create an application that allows the organization to keep track of the total amount of money raised. The application should deduct 17% of each donation for operating costs; the remaining 83% is given to the charity. The application should display the amount of each donation after the 17% operating expenses are deducted; it also should display the total amount raised for the charity (that is, the total amount donated less all operating costs) for all donations up to that point.

Donation 3800
(After Expense) $3,154.00
Make Donation
(Total Raised) $4,399
3800
Donation 

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

namespace Fund_Raiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public decimal GrossDonation = 0;

       public decimal CalculateDonation(ref decimal donatedAmount)
        {
            const double percent = 0.83;
            return Convert.ToDecimal(percent) * donatedAmount;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void donationSubmitClick(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal totalDonation = Convert.ToDecimal(txtDonation.Text);
                txtDonation.Text = string.Format("{0:C}", totalDonation);
                decimal afterCosts = CalculateDonation(ref totalDonation);
                txtAfterExp.Text = string.Format("{0:C}", afterCosts);
                GrossDonation += afterCosts;
                txtTotal.Text = string.Format("{0:C}", GrossDonation);

            }
            catch (FormatException fEx)
            {
                txtTotal.Text = fEx.Message;
            }
            catch (Exception ex)
            {
                txtTotal.Text = ex.Message;
            }
        }

        private void newDonationSubmitClick(object sender, RoutedEventArgs e)
        {
            txtDonation.Text = string.Empty;
            txtAfterExp.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
