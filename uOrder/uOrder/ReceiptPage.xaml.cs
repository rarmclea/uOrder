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
            if (new ConfirmDialog("How would you like to pay for your order?", "Cash", "Credit").ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                new MessageDialog("Your server is on the way with the cheque").ShowDialog();
                pay.Content = "Payment Pending";
                pay.FontSize = 18;
            }
        }
    }
}
