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
    /// Interaction logic for ReceiptItem.xaml
    /// </summary>
    public partial class ReceiptItem : UserControl
    {
        String title;
        String details;
        String addons;
        double price;
        public ReceiptItem(String title, String details, double price, String addons, bool refillable)
        {
            InitializeComponent();
            this.title = title;
            this.details = details;
            this.price = price;
            this.addons = addons;
            this.addons_details.Text = addons;
            this.item_title.Content = title;
            this.item_details.Text = details;
            this.item_price.Content = price.ToString("F");
            if (refillable)
                refill.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MessageDialog("Your refill is on its way").ShowDialog();

        }
    }
}
