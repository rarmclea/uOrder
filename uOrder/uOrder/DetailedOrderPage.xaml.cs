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
        double addPrice;
        double addPrice2;
        double addPrice3;
        String dropItem = null;
        bool refillable = false;


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

        public DetailedOrderPage(MenuPage menu, String itemTitle, String itemDetails, double price, bool veg, bool wise, bool check, String itemCheckField, String itemCheckField2, String itemCheckField3, double addPrice, double addPrice2, double addPrice3)
        {
            InitializeComponent();
            this.details.Text = itemDetails;
            this.title.Content = itemTitle;
            this._menu = menu;
            this.price = price;
            this.item = itemTitle;
            this.addPrice = addPrice;
            this.addPrice2 = addPrice2;
            this.addPrice3 = addPrice3;

            if (veg)
                iconveg.Visibility = Visibility.Visible;
            if (wise)
                iconoceanwise.Visibility = Visibility.Visible;
            if (check)
            {
                checkbox.Visibility = Visibility.Visible;
                checkbox.Content = itemCheckField;
                if (itemCheckField2 != null)
                {
                    checkbox2.Visibility = Visibility.Visible;
                    checkbox2.Content = itemCheckField2;
                }
                if (itemCheckField3 != null)
                {
                    checkbox3.Visibility = Visibility.Visible;
                    checkbox3.Content = itemCheckField3;
                }

            }
        }

        public DetailedOrderPage(MenuPage menu, String itemTitle, String itemDetails, double price, bool veg, bool wise, String drop1, String drop2, String drop3, String drop4)
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

            dropDown.Visibility = Visibility.Visible;
            firstItem.Content = drop1;
            if (drop2 != null)
            {
                secondItem.Visibility = Visibility.Visible;
                secondItem.Content = drop2;
            }
            if (drop3 != null)
            {
                thirdItem.Visibility = Visibility.Visible;
                thirdItem.Content = drop3;
            }
            if (drop4 != null)
            {
                fourthItem.Visibility = Visibility.Visible;
                fourthItem.Content = drop4;
            }
        }


        public void setAsRefillable()
        {
            refillable = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dropDown.Visibility == Visibility.Visible && dropDown.Text == "-- Select --")
                new MessageDialog("Please specify the type of item you wish to order").ShowDialog();
            else
            {
                _menu.order_stack.Children.Remove(_menu.empty);
                _menu.order_stack.Children.Remove(_menu.empty2);

                TextBlock one = new TextBlock();
                one.Text = item;
                one.FontSize = 22;
                String details = "";
                String addOns = null;
                String addOns2 = null;
                String addOns3 = null;

                double currentPrice = price;
                if ((bool)checkbox.IsChecked)
                {
                    addOns = (String)this.checkbox.Content;
                    currentPrice += addPrice;
                }
                if ((bool)checkbox2.IsChecked)
                {
                    addOns2 = (String)this.checkbox2.Content;
                    currentPrice += addPrice2;
                }
                if ((bool)checkbox3.IsChecked)
                {
                    addOns3 = (String)this.checkbox3.Content;
                    currentPrice += addPrice3;
                }
                dropItem = dropDown.Text;
                if (dropItem.Equals("-- Select --"))
                    dropItem = null;
                OrderItem oi = new OrderItem(_menu, item, details, price, addOns, addOns2, addOns3, addPrice, addPrice2, addPrice3, dropItem);
                if (refillable)
                    oi.setAsRefillable();
                _menu.order_stack.Children.Add(oi);

                _menu.subtotal += currentPrice;
                _menu.gst = Math.Truncate((_menu.subtotal * 0.05) * 100) / 100;
                _menu.total = _menu.subtotal + _menu.gst;
                _menu.sub_label.Content = "Subtotal: $" + _menu.subtotal.ToString("F");
                _menu.gst_label.Content = "GST: $" + _menu.gst.ToString("F");
                _menu.tot_label.Content = "Total: $" + _menu.total.ToString("F");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _menu.page_viewer.Children.Remove(this);
            _menu.menu.Visibility = Visibility.Visible;
            _menu.downArrowCover.Visibility = Visibility.Visible;

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

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkbox_Checked2(object sender, RoutedEventArgs e)
        {

        }

        private void checkbox_Checked3(object sender, RoutedEventArgs e)
        {

        }

        private void StartOver_Click(object snder, RoutedEventArgs e)
        {
            if ((bool)checkbox.IsChecked)
            {
                checkbox.IsChecked = false;

            }
            if ((bool)checkbox2.IsChecked)
            {
                checkbox2.IsChecked = false;
            }
            if ((bool)checkbox3.IsChecked)
            {
                checkbox3.IsChecked = false;
            }
            if (dropItem != "-- Select --")
                dropDown.Text = "-- Select --";
        }
    }
}
