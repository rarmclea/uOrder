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

namespace uOrder
{
    /// <summary>
    /// Interaction logic for ReceiptPage.xaml
    /// </summary>
    public partial class ReceiptPage : UserControl
    {
        public double gst = 0.0;
        public double subtotal = 0.0;
        public double total = 0.0;
        public ReceiptPage()
        {
            InitializeComponent();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you ready to pay for your order?", "Pay Now", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                AutoClosingMessageBox.Show("The waiter is on the way with the cheque", "Pay Now",2000);
        }
    }
}
