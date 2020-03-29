using System;
using StockManagement.DataAccessLayer;
using System.Windows.Controls;
using System.Collections;
using System.Collections.ObjectModel;

namespace StockManagement.User_Control
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class CustomerDataGrid : UserControl
    {
        private ICustomerDataAccessLayer _icust;
        public CustomerDataGrid()
        {
            InitializeComponent();
        }

        private void CustomerdataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            CustomerdataGrid.ItemsSource = GetCustomerList();
           
        }
        private ObservableCollection<CustomerDataObjects> GetCustomerList()
        {
            _icust = new CustomerDataAccessLayer();
            var list=_icust.GetCustomers();
            return new ObservableCollection<CustomerDataObjects>(list);
        }
        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var Cust_List = new CustomerDataObjects();
            Cust_List.Customer_ID = Convert.ToInt32(txt_ID.Text);
            Cust_List.FirstName = txt_FirstName.Text.ToString();
            Cust_List.LastName = txt_LastName.Text.ToString();
            Cust_List.Address = txt_Address.Text.ToString();
            Cust_List.Customer_Type = txt_CType.Text.ToString();

            _icust = new CustomerDataAccessLayer();

            _icust.UpdateCustomer(Cust_List); CustomerdataGrid.ItemsSource = GetCustomerList();
            Clear();


        }

        private void Clear()
        {
            txt_Address.Clear();
            txt_CType.Clear();
            txt_FirstName.Clear();
            txt_ID.Clear();
            txt_LastName.Clear();
        }

        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void CustomerdataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }
    }   
}


