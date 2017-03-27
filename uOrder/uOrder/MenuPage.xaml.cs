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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : UserControl
    {
        public double subtotal = 0.0;
        public double gst = 0.0;
        public double total = 0.0;
        ReceiptPage _receipt;
        public MenuPage(ReceiptPage receipt)
        {
            InitializeComponent();
            _receipt = receipt;
        }

       

        private void order_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you ready to place your order?", "Place Order", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderItem[] array = new OrderItem[order_stack.Children.Count];
                order_stack.Children.CopyTo(array, 0);
                for (int i = 0; i < array.Length; i++)
                    _receipt.receipt_stack.Children.Add(new ReceiptItem(array[i].title, array[i].details, array[i].price, array[i].refillable));
                order_stack.Children.Clear();
                _receipt.gst += this.gst;
                _receipt.subtotal += this.subtotal;
                _receipt.total += this.total;
                _receipt.sub_label.Content = "Subtotal: $" + _receipt.subtotal.ToString("F");
                _receipt.gst_label.Content = "GST: $" + _receipt.gst.ToString("F");
                _receipt.tot_label.Content = "Total: $" + _receipt.total.ToString("F");
                gst += 0.0;
                subtotal += 0.0;
                total += 0.0;
                sub_label.Content = "Subtotal: $" + subtotal.ToString("F");
                gst_label.Content = "GST: $" + gst.ToString("F");
                tot_label.Content = "Total: $" + total.ToString("F");
                AutoClosingMessageBox.Show("Your order has been sent to the kitchen. You can view ordered items under 'View Receipt' or order more items under 'Menu'", "Place Order", 2500);
            }
        }
        private void tpiaj_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Tuna Poke in a Jar", "avocado, fresh tomatoes, nori crisps, ginger, spring onions + ponzu - 9 ¾", 9.75, false, true));
           
        }
        private void kfc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Korean Fried Cauliflower", "spicy gochujang pepper sauce, jalapeno lime dip - 9 ¾", 9.75, false, false));
        }
        private void c_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Calamari", "+ tempura prawns, sriracha aioli + sweet chili sauce - 13 ¾", 13.75, false, false));
        }
        private void b_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Bruschetta", "9 ¾", 9.75, true, false));
        }
        private void ps_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Pot-Stickers", "12 ¾", 12.75, false, false));
        }
        private void mb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Med-Bread", "fresh baked flatbread, three dips - 9 ¾", 9.75, true, false));
        }
        private void dr_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Dry Ribs", "11 ¾", 11.75, false,false));
        }
        private void sc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Sushi Cones", "tempura prawns, fresh avocado, nori + ponzu - 14 ¼", 14.25, false, false));

        }
        private void icf_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Indo Chicken Flatbread", "served open faced, pulled chicken, refried beans, shredded cheese,  \n crispy lentils on curry naan. - 9 ¾", 9.75, false, false));
        }
        private void md_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Mosaic Dip", "goat cheese, mushrooms, fresh baked flatbread - 14 ¾", 14.75, true, false));
        }
        private void scc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Sweet Chili Chicken", "12 ¾", 12.75, false, false));
        }
        private void cw_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Wings", "biryani, salt & pepper, honey garlic, hot - 13 ½", 13.5, false, false));
        }
        private void lw_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Lettuce Wraps", "fresh veggies, cashews, chow mein noodles, ginger soy glaze - 13 ¾ \n add chicken - 5", 13.75, false, false));
        }
        private void dcnsp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Double Cheese Nachos Share Platter", "19 ¾ \n add beef - 5 \n add pulled chicken - 5", 19.75, false, false));
        }
        private void dcn12_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Double Cheese Nachos for One or Two", "13 ¾ \n add beef - 5 \n add pulled chicken - 5", 13.75, false, false));
        }

        private void not_available_Click(object sender, RoutedEventArgs e)
        {
            AutoClosingMessageBox.Show("This item is currently unavailable. We apologize for the inconvenience.", "Item Not Available", 1500);
        }
    }
}
