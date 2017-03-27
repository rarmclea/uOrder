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
    /// Interaction logic for TunaPokeInAJar.xaml
    /// </summary>
    public partial class TunaPokeInAJar : UserControl
    {
        MenuPage _menu;
        float price = 9.75F;
        public TunaPokeInAJar(MenuPage _menu)
        {
            this._menu = _menu;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoClosingMessageBox.Show("Added to order.", "Item Added", 600);
            TextBlock text = new TextBlock();
            text.Text = "$" + price;
            TextBlock note = new TextBlock();
            note.Text = allergies.Text;
            TextBlock item = new TextBlock();
            item.Text = title.ContentStringFormat;
            _menu.order_stack.Children.Add(item);
            _menu.order_stack.Children.Add(note);
            _menu.order_stack.Children.Add(text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //_menu.menu.Visibility = Visibility.Hidden;
            _menu.menu.Visibility = Visibility.Visible;

        }
    }
}
