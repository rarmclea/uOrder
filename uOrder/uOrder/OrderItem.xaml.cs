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
    /// Interaction logic for OrderItem.xaml
    /// </summary>
    public partial class OrderItem : UserControl
    {
        public String title;
        public String details;
        public double price;
        public bool refillable = false;
        MenuPage _menu;
        public OrderItem(MenuPage menu, String title, String details, double price)
        {
            InitializeComponent();
            this.title = title;
            this.details = details;
            this.price = price;
            _menu = menu;
            this.item_title.Content = title;
            this.item_details.Text = details;
            this.item_price.Content = price.ToString("F");
        }

        public void setAsRefillable()
        {
            refillable = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new ConfirmDialog("Are you sure you want to remove this item?", "Remove item").ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _menu.order_stack.Children.Remove(this);
                _menu.subtotal -= price;
                _menu.gst = _menu.subtotal * 0.05;
                _menu.total = _menu.gst + _menu.subtotal;
                _menu.sub_label.Content = "Subtotal: $" + _menu.subtotal.ToString("F");
                _menu.gst_label.Content = "GST: $" + _menu.gst.ToString("F");
                _menu.tot_label.Content = "Total: $" + _menu.total.ToString("F");
            }

        }
    }
}
