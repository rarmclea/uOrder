using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for DetailedOrderPage.xaml
    /// </summary>
    public partial class DetailedOrderPage : UserControl
    {
        double price;
        string item;
        MenuPage _menu;
        public DetailedOrderPage(MenuPage menu, String itemTitle, String itemDetails, double price, bool veg, bool wise)
        {
            InitializeComponent();
            this.details.Text = itemDetails;
            this.title.Content = itemTitle;
            this._menu = menu;
            this.price = price;
            this.item = itemTitle;
            if (veg)
                iconveg.Visibility = Visibility.Visible;
            if (wise)
                iconoceanwise.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock one = new TextBlock();
            one.Text = item;
            one.FontSize = 22;
            String details = "";
            if (notes.Text != "Enter preferences or allergies here")
                details = notes.Text;
            OrderItem oi = new OrderItem(_menu, item, details, price);
            _menu.order_stack.Children.Add(oi);
            _menu.subtotal += price;
            _menu.gst = Math.Truncate((_menu.subtotal * 0.05)*100) / 100;
            _menu.total = _menu.subtotal + _menu.gst;
            _menu.sub_label.Content = "Subtotal: $" + _menu.subtotal.ToString("F");
            _menu.gst_label.Content = "GST: $" + _menu.gst;
            _menu.tot_label.Content = "Total: $" + _menu.total;
            AutoClosingMessageBox.Show("Added item to order", "Item Added", 500);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _menu.menu.Visibility = Visibility.Visible;
            _menu.page_viewer.Children.Remove(this);
        }

        private void notes_GotFocus(object sender, RoutedEventArgs e)
        {
            notes.Clear();
            _menu.kb.Visibility = Visibility.Visible;
            _menu.kb_background.Visibility = Visibility.Visible;
         
        }

        private void notes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (notes.Text == "")
                notes.Text = "Enter preferences or allergies here";
            _menu.kb.Visibility = Visibility.Collapsed;
            _menu.kb_background.Visibility = Visibility.Collapsed;
        }
    }
}
