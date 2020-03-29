using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;

namespace StockManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string Conn_string = ConfigurationManager.ConnectionStrings["Stock_string"].ConnectionString;
            SqlParameter param;
            int usercount;
            try
            {
                using (SqlConnection conn = new SqlConnection(Conn_string))
                {
                    SqlCommand comm = new SqlCommand("SP_Login3", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    
                    param = comm.Parameters.AddWithValue("@Username", txtName.Text);
                    param = comm.Parameters.AddWithValue("@Password", txtPassword.Password);
                    
                    //Open the connection   
                    conn.Open();
                    //inner exception
                    try
                    {
                        usercount = (Int32)comm.ExecuteScalar();
                        if(usercount>0)
                        {
                            Stock_Main s = new Stock_Main();
                            s.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username or Password is incorrect");
                        }
                    }
                    catch(Exception ec)
                    {
                        MessageBox.Show(ec.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                 }
                
            }
            //Catch outer Exception
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
