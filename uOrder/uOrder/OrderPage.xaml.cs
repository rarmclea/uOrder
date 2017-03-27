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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : UserControl
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you ready to place your order?", "Place Order", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MessageBox.Show("Your order has been sent to the kitchen. You can view ordered items under 'View Receipt' or order more items under 'Menu'", "Place Order");
        }
    }
}

