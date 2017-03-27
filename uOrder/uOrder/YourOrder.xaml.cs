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
    /// Interaction logic for YourOrder.xaml
    /// </summary>
    public partial class YourOrder : UserControl
    {
        public YourOrder()
        {
            InitializeComponent();
            FillData();

            
        }

        void FillData()
        {
            Grid _items = new Grid();
            order_stack.Children.Add(_items);
            _items.Width = 1000;
            _items.Height = 1000;
            _items.HorizontalAlignment = HorizontalAlignment.Stretch;
            _items.VerticalAlignment = VerticalAlignment.Stretch;
            _items.ShowGridLines = true;
            _items.Background = Brushes.Black;


        }
            
          
    }
}
