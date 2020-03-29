using StockManagement.DataAccessLayer;
using System.Windows;

namespace StockManagement
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private ICustomerDataAccessLayer _icust;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var Cust_List = new LoginData();
            Cust_List.Username = txtName.Text;
            Cust_List.UserPassword = txtPassword.Password.ToString();

            _icust = new CustomerDataAccessLayer();
            var IsValid = _icust.IsValid(Cust_List);
            if (IsValid > 0)
            {
                Stock_Main s = new Stock_Main();
                s.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or password");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
