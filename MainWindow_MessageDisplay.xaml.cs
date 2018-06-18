

Create a simple WPF application that consists of a simple form with three controls:
A text box for entering messages
A label where the message is copied to
A copy button that when is clicked the message in the textbox is copied to the label
Make sure that label font size is 14 and its text is aligned in the center with a red background color. The button has yellow background color. Anchor the textbox to Top.


 



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

namespace Message_Display
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

        private void copyClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Content = txtMessage.Text;
        }
    }
}
