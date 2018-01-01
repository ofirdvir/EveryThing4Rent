using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Shapes;

namespace Everything4Rent.View
{
    /// <summary>
    /// Interaction logic for ShowItem.xaml
    /// </summary>
    public partial class ShowItem : Window
    {
        Controller _controller;
        string itemName;
        string priceName;
        string action;
        string tableName;
        string packageID;
        public ShowItem(Controller controller, string name)
        {
            itemName = name;
            _controller = controller;
            InitializeComponent();
          
            Update();
        }


        private void Update()
        {
            txtName.Text = itemName;

            string name = "'" + itemName + "'";


            string query = "SELECT action FROM Items WHERE item_name = " + name;
             action = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        action=reader[0].ToString();
                    }

                    txtItemAction.Text = action;
                }
            }


             tableName="";
             priceName="";
            if(action== "Exchange")
            {
                ItemCost.Text = "Patial Price";
                tableName = "Trade_package";
                priceName = "partial_price";
            }
            if (action == "Donation")
            {
                ItemCost.Text = "Deposit";
                tableName = "Donation_package";
                priceName = "deposit";
            }
            if (action == "Rent")
            {
                tableName = "Renting_package";
                priceName = "price";

            }

            string itemID="";
            //get ITEMid
            query = "SELECT Item_id FROM Items WHERE item_name = " + name;
           
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        itemID = reader[0].ToString();
                    }

                    txtItemAction.Text = action;
                }
            }

            itemID = "'" + itemID + "'";
            //get packageID
             packageID="";
            query = "SELECT Package_id FROM Package WHERE item_id = " + itemID;

            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        packageID = reader[0].ToString();
                    }

                    txtItemAction.Text = action;
                }
            }


            //show time to cancel
            query = "SELECT time_to_cancel FROM Package WHERE package_id = " + packageID;
            string timeToCnacel = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        timeToCnacel = reader[0].ToString();
                    }

                    txtItemtimeToCancel.Text = timeToCnacel;
                }
            }


            //show time to policy
            query = "SELECT policy FROM Package WHERE package_id = " + packageID;
            string policy = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        policy = reader[0].ToString();
                    }

                    txtItemPolicy.Text = policy;
                }
            }


            //show time to startDate
            query = "SELECT StartDate FROM Package WHERE package_id = " + packageID;
            string startDate = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        startDate = reader[0].ToString();
                    }

                    txtStartDate.Text = startDate;
                }
            }

            //show time to endDate
            query = "SELECT EndDate FROM Package WHERE package_id = " + packageID;
            string endDate = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        endDate = reader[0].ToString();
                    }

                    txtEndDate.Text = endDate;
                }
            }
            //trashold

            query = "SELECT treshold FROM Package WHERE package_id = " + packageID;
            string treshold = "";
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        treshold = reader[0].ToString();
                    }


                    if(treshold!= "Treshold")
                          txtTreshold.Text = treshold;
                }
            }




            //from spedicic table
            // packageID = "'" + packageID + "'";

            string price = "";
            query = "SELECT "+priceName+ " FROM "+ tableName+" WHERE package_id = " + packageID;

            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        price = reader[0].ToString();
                    }

                    txtItemAction.Text = action;
                }
            }

            txtItemCost.Text = price;
            if(policy== "Conservative")
            {
                Treshold.Visibility = Visibility.Visible;
                txtTreshold.Visibility = Visibility.Visible;
                Tresholdbtn.Visibility = Visibility.Visible;
                Treshold1.Visibility = Visibility.Visible;
            }


           





        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Item_Operations win2 = new Item_Operations(_controller);
            win2.Show();
            Close();
        }

        private void txtItemCost_TextChanged(object sender, TextChangedEventArgs e)
        {
          
          


        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtItemCost.Text, out var n))
            {
                MessageBox.Show("Cost is not valid", "Error");
                return;
            }


            //update quary
            //  string query = "SELECT " + priceName + " FROM " + tableName + " WHERE package_id = " + packageID;
            string query = "UPDATE [" + tableName + "] SET [" + priceName + "] = " + txtItemCost.Text + " WHERE package_id = " + packageID;
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();

                }
            }



            MessageBox.Show("Item details updated!");
        }

        private void UpdateTimeToCancel_Click(object sender, RoutedEventArgs e)
        {

            //update quary
            //  string query = "SELECT " + priceName + " FROM " + tableName + " WHERE package_id = " + packageID;
            if ("Choose Deadline" == ((ComboBoxItem)deadline.SelectedItem).Content.ToString())
                return;

            
            string value ="'"+((ComboBoxItem)deadline.SelectedItem).Content.ToString()+"'";
            string query = "UPDATE Package SET [time_to_cancel] = " + value + " WHERE Package_id = " + packageID;
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();

                }
            }
            txtItemtimeToCancel.Text = ((ComboBoxItem)deadline.SelectedItem).Content.ToString();
            MessageBox.Show("Item details updated!");
        }



        private void ItemPolicybtn_Click(object sender, RoutedEventArgs e)
        {
            if (((ComboBoxItem)Policy.SelectedItem).Content.ToString() == "Choose Policy")
                return;

             string value = "'" + ((ComboBoxItem)Policy.SelectedItem).Content.ToString() + "'";
            string query = "UPDATE Package SET [policy] = " + value + " WHERE Package_id = " + packageID;
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();

                }
            }

            if (((ComboBoxItem)Policy.SelectedItem).Content.ToString() == "Conservative")
            {
                Treshold.Visibility = Visibility.Visible;
                txtTreshold.Visibility = Visibility.Visible;
                Tresholdbtn.Visibility = Visibility.Visible;
                Treshold1.Visibility = Visibility.Visible;
            }
            else
            {
                Treshold.Visibility = Visibility.Collapsed;
                txtTreshold.Visibility = Visibility.Collapsed;
                Tresholdbtn.Visibility = Visibility.Collapsed;
                Treshold1.Visibility = Visibility.Collapsed;
            }


            txtItemPolicy.Text = ((ComboBoxItem)Policy.SelectedItem).Content.ToString();
            MessageBox.Show("Item details updated!");
        }

        private void ItemstartDatebtn_Click(object sender, RoutedEventArgs e)
        {
            if(Treshold1.SelectedIndex==0|| Treshold1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Choose treshold!");
            }
            string value = "'" + ((ComboBoxItem)Treshold1.SelectedItem).Content.ToString() + "'";
            string query = "UPDATE Package SET [policy] = " + value + " WHERE Package_id = " + packageID;
            using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();

                }
            }

            txtTreshold.Text = ((ComboBoxItem)Treshold1.SelectedItem).Content.ToString();



        }
    }
}
