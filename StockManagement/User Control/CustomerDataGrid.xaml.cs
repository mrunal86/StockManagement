using System;
using StockManagement.DataAccessLayer;
using System.Windows.Controls;
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
            Cust_List.FirstName = txt_FirstName.Text.ToString().Trim();
            Cust_List.LastName = txt_LastName.Text.ToString().Trim();
            Cust_List.Address = txt_Address.Text.ToString().Trim();
            Cust_List.Customer_Type = txt_CType.Text.ToString().Trim();
            _icust = new CustomerDataAccessLayer();
            _icust.UpdateCustomer(Cust_List);
            CustomerdataGrid.ItemsSource = GetCustomerList();
            Clear();
        }
        private void Clear()
        {
            txt_Address.Clear();
            txt_CType.Clear();
            txt_FirstName.Clear();
            txt_ID.Clear();
            txt_LastName.Clear();
            txt_ID.IsEnabled = true;
        }
        private void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var Cust_List = new CustomerDataObjects();
            Cust_List.Customer_ID = Convert.ToInt32(txt_ID.Text);
            _icust = new CustomerDataAccessLayer();
            _icust.DeleteCustomer(Cust_List);
            Clear();
            CustomerdataGrid.ItemsSource = GetCustomerList();
        }
        private void CustomerdataGrid_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if(CustomerdataGrid.SelectedItem!=null)
                {
                    if(CustomerdataGrid.SelectedItem is CustomerDataObjects)
                    {
                        var row = (CustomerDataObjects)CustomerdataGrid.SelectedItem;
                        if(row!=null)
                        {
                            var rowList = (CustomerDataObjects)CustomerdataGrid.SelectedItem;
                            txt_ID.Text = rowList.Customer_ID.ToString().Trim();
                            txt_FirstName.Text = rowList.FirstName.ToString().Trim();
                            txt_LastName.Text = rowList.LastName.ToString().Trim();
                            txt_Address.Text = rowList.Address.ToString().Trim();
                            txt_CType.Text = rowList.Customer_Type.ToString().Trim();

                        }
                    }
                }
            }
            catch(Exception)
            {

            }
        }
    }   
}



















// CustomerdataGrid.SelectionChanged -= new SelectionChangedEventHandler(CustomerdataGrid_Loaded);
