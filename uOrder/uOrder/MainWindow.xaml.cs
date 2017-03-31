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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuPage _menu;
        ReceiptPage _receipt = new ReceiptPage();
        HelpPage _help = new HelpPage();
        SolidColorBrush darkRed = new SolidColorBrush(Color.FromRgb(79, 13, 13));
        SolidColorBrush white = new SolidColorBrush(Color.FromRgb(238, 230, 228));
        protected TouchPoint TouchStart;
        bool AlreadySwiped;


        public MainWindow()
        {

            InitializeComponent();

            /**
             ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("https://media-cdn.tripadvisor.com/media/photo-s/01/c4/40/ca/moxie-s-classic-grill.jpg", UriKind.Absolute));
            myBrush.Opacity = 2;
            page_viewer.Background = myBrush;
            */

            _menu = new MenuPage(_receipt);
            page_viewer.Children.Add(_menu);


        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            menu.BorderBrush = white;
            menu.Background = Brushes.DarkGray;
            help.BorderBrush = darkRed;
            help.Background = darkRed;
            receipt.BorderBrush = darkRed;
            receipt.Background = darkRed;
            call.BorderBrush = darkRed;
            page_viewer.Children.Clear();
            page_viewer.Children.Add(_menu);
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            menu.BorderBrush = darkRed;
            menu.Background = darkRed;
            help.BorderBrush = white;
            help.Background = Brushes.DarkGray;
            receipt.BorderBrush = darkRed;
            receipt.Background = darkRed;
            call.BorderBrush = darkRed;
            page_viewer.Children.Clear();
            page_viewer.Children.Add(_help);

        }

        private void receipt_Click(object sender, RoutedEventArgs e)
        {
            menu.BorderBrush = darkRed;
            menu.Background = darkRed;
            help.BorderBrush = darkRed;
            help.Background = darkRed;
            receipt.BorderBrush = white;
            receipt.Background = Brushes.DarkGray;
            call.BorderBrush = darkRed;
            page_viewer.Children.Clear();
            page_viewer.Children.Add(_receipt);
        }

        private void call_Click(object sender, RoutedEventArgs e)
        {
            Brush menu_brush = menu.BorderBrush;
            Brush help_brush = help.BorderBrush;
            Brush receipt_brush = receipt.BorderBrush;

            if (new ConfirmDialog("Do you want to call the waiter?", "Call Waiter").ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //service.Background = Brushes.DarkGray;
                border.Background = Brushes.DarkGray;
                border.BorderBrush = Brushes.YellowGreen;

                new MessageDialog("The waiter has been called. Please wait.").ShowDialog();

            }
            menu.BorderBrush = darkRed;
            help.BorderBrush = darkRed;
            receipt.BorderBrush = darkRed;
            call.BorderBrush = Brushes.Yellow;

            menu.BorderBrush = menu_brush;
            help.BorderBrush = help_brush;
            receipt.BorderBrush = receipt_brush;
            //call.BorderBrush = darkRed;


        }

        private void start_Click(object sender, RoutedEventArgs e)
        {

            start.Visibility = Visibility.Hidden;
            enter.Visibility = Visibility.Hidden;
            menu.BorderBrush = white;
            //the hit box is back because i had to to implement the home button, but it shouldn't be an issue on a touch screen 
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Visible;
            enter.Visibility = Visibility.Visible;
        }


        private void page_viewer_TouchDown(object sender, TouchEventArgs e)
        {
            TouchStart = e.GetTouchPoint(this);
        }

        private void page_viewer_TouchMove(object sender, TouchEventArgs e)
        {
            if (!AlreadySwiped)
            {
                var Touch = e.GetTouchPoint(this);

                //right now a swipe is 200 pixels 

                //Swipe Left

                if (TouchStart != null && Touch.Position.X > (TouchStart.Position.X + 900))
                {
                    start_Click(sender, e);
                    AlreadySwiped = true;
                }

            }

            e.Handled = true;

        }
    }
}