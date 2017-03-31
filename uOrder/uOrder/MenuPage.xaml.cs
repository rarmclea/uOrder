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
            ConfirmDialog cd = new ConfirmDialog("Are you ready to place your order?", "Place Order");
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                gst = 0.0;
                subtotal = 0.0;
                total = 0.0;
                sub_label.Content = "Subtotal: $" + subtotal.ToString("F");
                gst_label.Content = "GST: $" + gst.ToString("F");
                tot_label.Content = "Total: $" + total.ToString("F");
                new MessageDialog("Your order has been sent to the kitchen. You can view ordered items under 'View Receipt' or order more items under 'Menu'").ShowDialog();
            }
        }

        //Share
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
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Wings", "biryani, salt & pepper, honey garlic, hot - 13 ½", 13.5, false, false, "Biryani", "Salt & Pepper", "Honey Garlic", "Hot"));
        }
        private void lw_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Lettuce Wraps", "fresh veggies, cashews, chow mein noodles, ginger soy glaze - 13 ¾", 13.75, false, false, true, "Add chicken 5", null,null,5,0,0));
        }
        private void dcnsp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Double Cheese Nachos Share Platter", "19 ¾", 19.75, false, false, true, "Add beef 5", "Add pulled chicken 5",null,5,5,0));
        }
        private void dcn12_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Double Cheese Nachos for One or Two", "13 ¾", 13.75, false, false, true, "Add beef 5", "Add pulled chicken 5",null,5,5,0));
        }

        //Pizzas

        private void ri_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Rustic Italian", "prosciutto & pancetta, caramelized onions, pulled short rib - 16 ¾", 16.75, false, false));
        }

        private void m_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Margherita", "fresh basil, bocconcini, rustic tomato sauce, olive oil - 13 ¾", 13.75, true, false));
        }

        //Soups and Salads

        private void bcs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Broccoli Cheese Soup", "7 ¾", 7.75, false, false));
        }

        private void fs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Feauture Soup", "7 ¾", 7.75, false, false, "Chicken Noodle", "Mushroom Soup", "Minestrone", null));
        }

        private void sms_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Starter Market Salad", "artisan greens, fresh veggies, edamame, toasted pumpkin seeds, red wine vinaigrette - 7 ¾", 7.75, true, false));
        }

        private void scs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Starter Caesar Salad", "7 ¾", 7.75, false, false));
        }

        private void cs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Caesar Salad", "garlic ciabatta baguette - 9 ¾", 9.75, false, false));
        }

        private void kqslv_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Kale + Quinoa Salad + Lemon Vinaigrette", "7 ¾", 7.75, true, false));
        }

        private void acs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Asian Chopped Salad", " marinated chicken, crisp veggies, sesame dressing, frash cilantro + toasted sesame seeds - 13 ½", 13.50, false, false));
        }

        private void ss_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Steak Salad", "fresh greens, quebec goat cheese, grape tomatoes, spicy vinaigrette with a hint of clamato, \n goat cheese crostini - 19 ¾", 19.75, false, false));
        }

        private void sacs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Salmon + Avocado Cobb Salad", "fresh lois lake steelhead, crisp iceberg lettuce, bacon, cage-free boiled egg, feta, peppercorn ranch \n sundried tomato dressing - 18 ¾", 18.75, false, true));
        }

        private void sgts_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Seared Ginger Tuna Salad", "rare albacore tuna, edamame beans, avocado, daikon, cashews, cucumber ponzu emulsion - 19 ¾", 19.75, false, true));
        }

        //Steaks

        private void s_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Sirloin", "7 oz certified angus beef (cab®) - 25 ¾", 25.75, false, false, true, "Add madagascar peppercorn brandy sauce 3½", null,null,3.50,0,0));
        }

        private void hgs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Honey Garlic Sirloin", "9 oz, our unforgettable marinated sirloin - 29 ½", 29.50, false, false));
        }

        private void ms_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Mushroom Sirloin", "7 oz cab® sirloin, creamy madeira sauce + pan roasted cremini mushrooms - 29", 29.00, false, false));
        }

        private void ny_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "New York", "10 oz - 34", 34.00, false, false));
        }

        private void pny_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Peppercorn New York", "10 oz with madagascar peppercorn brandy sauce - 36 ½", 36.50, false, false));
        }

        private void sp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Sirloin + Pawns", "7 oz cab® sirloin + grilled garlic butter prawns - 33", 33.00, false, false));
        }

        //Mains

        private void mds_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Mustard + Dill Salmon", "fresh lois lake steelhead, green beans + mushroom salsa + baby potatoes - 26", 26.00, false, true));
        }

        private void lllhs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Lois Lake Lamon Herb Salmon", "fresh lois lake steelhead, ancient grains, lemon herb sauce + fresh seasonal vegetables - 26", 26.00, false, true));
        }

        private void cmc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chipotle Mango Chicken", "sweet + smoky dry rub, lemon quinoa, seasonal vegetables, fresh avocado + \n salsa fresca - 23", 23.00, false, false));
        }

        private void orfc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Oven Roasted Free-Run Chicken", "seasoned flour, herbed goat cheese, lemon herb sauce, fresh seasonal vegetables, \n ancient grains - 23 ½", 23.50, false, false));
        }

        private void sbbrh_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Slow-Roasted Baby Back Ribs (Half Rack)", "fall off the bone tender, your choice of potato + fresh seasonal vegetables - 23 ½", 23.50, false, false));
        }

        private void sbbrf_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Slow-Roasted Baby Back Ribs (Full Rack)", "fall off the bone tender, your choice of potato + fresh seasonal vegetables - 29 ¾", 29.75, false, false));
        }

        private void cr_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken + Ribs", "half rack of ribs, spice rubbed chicken, choice of potato + fresh seasonal vegetables - 25 ¾", 25.75, false, false, true, "Add a second chicken breast 5", null,null,5,0,0));
        }

        //Pasta and Rice

        private void cmr_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Madeira Rigatoni", "pan roasted chicken, creamy mushroom + madeira wine sauce, fresh rosemary, \n lemon butter - 18 ¾", 18.75, false, false));
        }

        private void ha_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Herb Alfredo", "grana padano, penne, asiago cream, chives - 13 ¾", 13.75, true, false, true, "Add chicken 5", null,null,5,0,0));
        }

        private void pl_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Prawn Linguine", "+ tempura prawns, sriracha aioli + sweet chili sauce - 13 ¾", 13.75, false, false));
        }

        private void ce_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Enchiladas", "9 ¾", 9.75, false, false));
        }

        private void gtrb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Ginger Teriyaki Rice Bowl", "fresh asian veggies, chipotle yogurt - 12 ¾", 12.75, true, false, true, "Add chicken 5", "Add steak 6", null,5,6,0));
        }

        private void rtcb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Red Thai Curry Bowl", "fresh baked flatbread, three dips - 14 ½", 14.50, false, false, true, "Add chicken 5", null, null,5,0,0));
        }

        private void bv_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Beef Vindaloo", "11 ¾", 11.75, false, false));
        }

        //Burgers

        private void bcb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Blackened Chicken Burger", "crisp pancetta bacon, american cheddar, roasted garlic mayo - 16", 16.00, false, false));
        }

        private void pvb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Portobello Veggie Burger", "marinated full mushroom cap, aged white cheddar, + fresh herbs - 14 ¾", 14.75, true, false));
        }

        private void tb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "The Burger", " hand-formed chuck + brisket patty, red relish, pickled mustard seed mayo - 14 ¾", 14.75, false, false, true, "Add bacon 1½", "Add aged white cheddar 1½", "Add sautéed mushroom 1½",1.50,1.50,1.50));
        }

        private void lbb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Lettuce Bun Burger", "our hand-formed burger wrapped in fresh iceburg lettuce - 15 ¾", 15.75, false, false));
        }

        private void lb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Loaded Burger", "aged white cheddar, mozzarella, sautéed mushrooms, bacon + bbq sauce - 17 ¾", 17.75, false, false));
        }

        //Handhelds
        private void st_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Street Tacos", "two chicken tacos, served food truck style + side fresh market salad - 13 ¾", 13.75, false, false));
        }

        private void ft_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Fish Tacos", "chipotle lime haddock, soft corn taco shells, valentina hot sauce + \n side fresh market salad - 15 ¾", 15.75, false, false));
        }

        private void gcw_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Greek Chicken Wrap", "marinated chicken, tomatoes, kalamata olives, capers, tzatziki, crumbled feta cheese - 15 ¾", 15.75, false, false));
        }

        private void sfcw_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Southern Fried Chicken Sandwich", "cabbage-slaw, cheddar cheese, quick pickle - 15 ¾", 15.75, false, false));
        }

        private void bd_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Beef Dip", "house-roasted beef, pretzel bun, sautéed mushrooms, horseradish aioli, swiss cheese, \n au jus - 17 ¾", 17.75, false, false));
        }

        private void dstc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Double Stacked Turkey Club", "roasted turkey, crisp bacon, fresh lettuce, tomato, mayo, cheddar, \n toasted multi - grain - 14 ¾", 14.75, false, false));
        }

        private void st_s_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Steak Sandwich", "cab® sirloin, open faced with sautéed mushrooms, caramelized + crispy onions, \n fresh arugula, garlic ciabatta - 18 ½", 18.50, false, false));
        }

        private void lc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Lunch Combo", "Choose any two of the following: broccoli cheese or feature soup, side caesar or \n side market salad, half turkey club or half beef dip - 12 ¾", 12.75, false, false));
        }

        private void ctf_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Tenders + Fries", "classic, buffalo or tangy thai - 14", 14.00, false, false));
        }

        //Desserts

        private void scpc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Salted Caramel + Pecan Cheesecake", "caramel scented cheesecake with fresh blackberries + orange segments - 8 ¾", 8.75, false, false));
        }

        private void mscpc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Mini Salted Caramel + Pecan Cheesecake", "4 ½", 4.50, false, false));
        }

        private void dcc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Dark Chocolate Cake", "warm callebaut chocolate sauce, french vanilla ice cream + shaved chocolate curls - 8", 8.00, false, false));
        }

        private void wcb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "White Chocolate Brownie", "warm chocolate sauce, french vanilla ice cream + real whipped cream - 8 ¾", 8.75, false, false));
        }

        private void bob_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Bite Of Brownie", "4 ½", 4.5, false, false));
        }

        private void stp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Sticky Toffee Pudding", "warm, with toasted almonds, buttery caramel sauce + french vanilla ice cream - 8 ¾", 8.75, false, false));
        }

        private void mstp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Mini Sticky Toffee Pudding", "4 ½", 4.50, false, false));
        }

        private void tt_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Tasting Trio", "mini versions of our white chocolate brownie, sticky toffee pudding + salted caramel + \n pecan cheesecake, served with french vanilla ice cream - 11 ¾", 11.75, false, false));
        }

        //Drinks Menu

        //Kids Menu

        private void kp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Kids' Penne", "with asiago cream - 9 ¾", 9.75, true, false));
        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Chicken Bites", "served with your choice of fries, salad or veggies + dip - 9 ¾", 9.75, false, false, "Fries", "Salad", "Veggies & Dip", null));
        }

        private void jc_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Jr Cheeseburger", "with cheddar cheese + ketchup, served with your choice of fries, salad or veggies + \n dip - 9 ¾", 9.75, false, false, "Fries", "Salad", "Veggies & Dip", null));
        }

        private void gcs_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Grilled Cheese Sandwich", "white or multi-grain bread, served with your choice of fries, salad or veggies + dip - 9 ¾", 9.75, true, false, "Fries", "Salad", "Veggies & Dip", null));
        }

        private void cp_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Cheese Pizza", "served with veggies + dip - 9 ¾", 9.75, true, false));
        }

        private void kgcd_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            page_viewer.Children.Add(new DetailedOrderPage(this, "Kids' Grilled Chicken Dinner", "with jasmine rice + veggies + dip - 9 ¾", 9.75, false, false));
        }

        private void not_available_Click(object sender, RoutedEventArgs e)
        {
            AutoClosingMessageBox.Show("This item is currently unavailable. We apologize for the inconvenience.", "Item Not Available", 1500);
        }

    }
}
