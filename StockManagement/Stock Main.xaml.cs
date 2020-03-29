using System;
using System.Configuration;
using System.Windows;

namespace StockManagement
{
    /// <summary>
    /// Interaction logic for Stock_Main.xaml
    /// </summary>
    public partial class Stock_Main : Window
    {
        public Stock_Main()
        {
            InitializeComponent();           
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //UserControl1.Child = new CustomerUserControl
            CustomerUserControl.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }



        public void stock_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stock got focus");
        }

        private void btndashaddb_vol_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}










/*private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
   {
        if(product.IsSelected)

       {
           Product prod = new Product();
           this.DataContext = prod;
       }
       else if (e.OriginalSource == stock)
       {

       }

   }*/
