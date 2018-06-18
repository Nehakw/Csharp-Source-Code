Lab 6: Collections, ArrayList/List <T>, and the foreach statement (WPF Application)

A shipping company receives packages at its headquarters, which functions as its shipping hub. After receiving the packages the company ships them to a distribution center in one of the following states: Alabama, Florida, Georgia, Kentucky, Mississippi, North Carolina, South Carolina, Tennessee, West Virginia or Virginia. The company needs an application to track the packages that pass through its shipping hub. The application generates a package ID number for each package that arrives at the shipping hub, when the user clicks the application’s Scan New Button. Once a package has been scanned, the user should be able to enter the shipping address for the package. The user should be able to navigate through the list of scanned packages by using <BACK or NEXT> Buttons and by viewing a list of all packages destined for a particular state.

This Application is expected to work as described below:

Scanning a new package: 
Click the “Scan New” button. The application displays a package ID number, the current date and time in “Arrived at:” textbox, enables the TextBoxes and allows the user to enter the package information (address)
Adding a package to the list of packages: Click in the “Address” TextBox to transfer the focus of the application to that field, and enter data. Continue using Tab to transfer focus to each field and finish address entry (City, select state using ComboBox, etc.). Then click the “Add” button to add the package to the application’s ArrayList or List<>.
Removing, editing, and browsing packages: The application’s NEXT > and <BACK buttons allow the user to navigate the list of the packages. The REMOVE button allows the user to delete packages, and the EDIT button allows the user to update a particular package’s information.
Viewing all packages going to a state: The ComboBox on the right side of the application allows the user to select a state. When a state is selected, all of the package ID numbers of packages destined for that state are displayed in the ListBox

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
using System.Collections;

namespace Shipping_Hub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ArrayList packageList;
        private Package objPackage;
        private int position;
        private Random objRandom;
        private int packageID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            position = 0;
            objRandom = new Random();
            packageID = objRandom.Next(1, 100000);
            cmbState.Text = Convert.ToString(cmbState.Items[0]);
            packageList = new ArrayList();
        }

        private void onClick_Back(object sender, RoutedEventArgs e)
        {
            if (position > 0)
            {
                position--;
            }
            else
            {
                position = packageList.Count - 1;
            }

            LoadPackage();
        }

        private void onClick_New(object sender, RoutedEventArgs e)
        {
            packageID++;
            objPackage = new Package(packageID);

            ClearControls();

            txtID.Text = objPackage.PackageNumber.ToString();
            txtArrive.Text = objPackage.ArrivalTime.ToString();

            grpPackageDetails.IsEnabled = true;
            SetButtons(false);
            btnAdd.IsEnabled = true;
            btnNew.IsEnabled = false;
            txtAddress.Focus();
        }

        private void onClick_Add(object sender, RoutedEventArgs e)
        {
            SetPackage();
            packageList.Add(objPackage);

            grpPackageDetails.IsEnabled = false;
            SetButtons(true);

            btnAdd.IsEnabled = false;

            if (cmbState.Text == cmbByState.Text)
            {
                lstPackages.Items.Add(objPackage.PackageNumber);
            }
            cmbByState.Text = objPackage.State;
            btnNew.IsEnabled = true;
        }

        private void onClick_Remove(object sender, RoutedEventArgs e)
        {
            if (cmbState.Text == cmbByState.Text)
            {
                lstPackages.Items.Remove(objPackage.PackageNumber);
            }

            packageList.RemoveAt(position);

            if (packageList.Count > 0)
            {
                if (position > 0)
                {
                    position--;
                }

                LoadPackage();
            }
            else
            {
                ClearControls();
            }

            SetButtons(true);
        }

        private void onClick_Edit(object sender, RoutedEventArgs e)
        {
            if (btnEdit.Content.ToString() == "Edit")
            {
                grpPackageDetails.IsEnabled = true;
                SetButtons(false);
                btnEdit.IsEnabled = true;
                btnEdit.Content = "Update";
            }
            else
            {
                SetPackage();
                packageList.RemoveAt(position);
                packageList.Insert(position, objPackage);

                cmbByState.Text = objPackage.State;

                grpPackageDetails.IsEnabled = false;
                SetButtons(true);

                btnEdit.Content = "Edit";
            }
        }

        private void onClick_Next(object sender, RoutedEventArgs e)
        {
            if (position < packageList.Count - 1)
            {
                position++;
            }
            else
            {
                position = 0;
            }

            LoadPackage();
        }

        private void SetPackage()
        {
            objPackage.Address = txtAddress.Text;
            objPackage.City = txtCity.Text;
            objPackage.State = Convert.ToString(cmbState.SelectedItem);
            objPackage.Zip = Int32.Parse(txtZip.Text);
        }

        private void LoadPackage()
        {
            objPackage = (Package)packageList[position];
            txtAddress.Text = objPackage.Address;
            txtCity.Text = objPackage.City;
            cmbState.Text = objPackage.State;
            txtZip.Text = objPackage.Zip.ToString("00000");
            txtArrive.Text = objPackage.ArrivalTime.ToString();
            txtID.Text = objPackage.PackageNumber.ToString();
        }

        private void ClearControls()
        {
            txtAddress.Clear();
            txtCity.Clear();
            cmbState.SelectedItem = "";
            txtZip.Clear();
            txtArrive.Clear();
            txtID.Clear();
        }

        private void SetButtons(bool btnState)
        {
            btnRemove.IsEnabled = btnState;
            btnEdit.IsEnabled = btnState;
            btnNext.IsEnabled = btnState;
            btnBack.IsEnabled = btnState;

            if (packageList.Count < 1)
            {
                btnNext.IsEnabled = false;
                btnBack.IsEnabled = false;
            }

            if (packageList.Count == 0)
            {
                btnEdit.IsEnabled = false;
                btnRemove.IsEnabled = false;
            }
        }

        private void cmbByState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strState = Convert.ToString(cmbByState.SelectedItem);
            lstPackages.Items.Clear();

            foreach (Package objViewPackage in packageList)
            {
                if (objViewPackage.State == strState)
                {
                    lstPackages.Items.Add(objViewPackage.PackageNumber);
                }
            }
        }
    }
}

