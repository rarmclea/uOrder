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
        public String addOns = null;
        public String addOns2 = null;
        public String addOns3 = null;
        MenuPage _menu;
        public double addPrice;
        public double addPrice2;
        public double addPrice3;
        public String dropItem = null;

        public OrderItem(MenuPage menu, String title, String details, double price, String addOns, String addOns2, String addOns3, double addPrice, double addPrice2, double addPrice3, String dropItem)
        {
            InitializeComponent();
            this.title = title;
            this.details = details;
            this.price = price;
            _menu = menu;
            this.addOns = addOns;
            this.addOns2 = addOns2;
            this.addOns3 = addOns3;
            this.addPrice = addPrice;
            this.addPrice2 = addPrice2;
            this.addPrice3 = addPrice3;
            this.dropItem = dropItem;
            this.item_title.Content = title;

            if (addOns != null)
            {
                this.addOn_details.Visibility = Visibility.Visible;
            }
            if (addOns2 != null)
            {
                this.addOn_details2.Visibility = Visibility.Visible;
            }
            if (addOns3 != null)
            {
                this.addOn_details3.Visibility = Visibility.Visible;
            }
            if (dropItem != null)
            {
                this.drop_details.Visibility = Visibility.Visible;
            }
            this.addOn_details.Text = addOns;
            this.addOn_details2.Text = addOns2;
            this.addOn_details3.Text = addOns3;
            this.drop_details.Text = dropItem;
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
                _menu.subtotal = price - addPrice - addPrice2 - addPrice3;
                _menu.gst = _menu.subtotal * 0.05;
                _menu.total = _menu.gst + _menu.subtotal;
                _menu.sub_label.Content = "Subtotal: $" + _menu.subtotal.ToString("F");
                _menu.gst_label.Content = "GST: $" + _menu.gst.ToString("F");
                _menu.tot_label.Content = "Total: $" + _menu.total.ToString("F");
            }

        }
    }
}