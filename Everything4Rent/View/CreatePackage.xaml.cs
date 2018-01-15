using Everything4Rent.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Everything4Rent
{
    /// <summary>
    /// Interaction logic for CreatePackage.xaml
    /// </summary>
    public partial class CreatePackage : Window
    {

        Controller controller;
        string _policy;
        string _trash;
        string _deadline;
        public List<string> UsersItem { get; set; }

        public List<string> SelectedItemsForPackage { get; set; }
        public List<string> ChosenFieldsForPackage { get; set; }
        public string ConnectionString { get; private set; }

        string _action;
        string _name;
        public CreatePackage(Controller controller, string action, string policy, string trash, string deadline,string name)
        {
            this.controller = controller;
            _action = action;
            _policy = policy;
            _trash = trash;
            _name = name;
            _deadline = deadline;

            InitializeComponent();
         
            initializeItems();
          
            Tile.Text = "Package of " + action + " Items";
       
        }

        public bool checkIfToOpen()
        {
            if (UsersItem.Count < 2)
            {
                MessageBox.Show("Sorry, you don't have enough items for this kind of packge :(", "Error");
                return false;

            }
            return true;
        }

        private void initializeItems()
        {
            ChosenFieldsForPackage = new List<string>();
            SelectedItemsForPackage = new List<string>();
            UsersItem = new List<string>();

            if (_action == "Rent")
            {
                txtCost.Visibility = Visibility.Visible;
            }
            else if (_action == "Donation")
            {
                txtDeposit.Visibility = Visibility.Visible;
            }
            else if (_action == "Exchange")
            {
                txtPatioalCost.Visibility = Visibility.Visible;
            }

            //gets the current users item list from controller!
            //  UsersItem = controller._allUsersInDB[controller.currentUserId].ItemsofUser;

            ///adds the item to combo box
            ///
            UsersItem = getUserItems(_action);
         
            for (int i = 0; i < UsersItem.Count; i++)
                Items.Items.Add(UsersItem[i].ToString());
            
        }

        private List<string> getUserItems(string action)
        {
            return this.controller.getUserItems(action);
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {

            if (Items.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose item");
                return;
            }

       


            ChosenFieldsForPackage.Add(Items.SelectedValue.ToString());
                int i = 0;
                while (i < UsersItem.Count)
                {
                    if (UsersItem[i].ToString() == Items.SelectedValue.ToString())
                    {
                        SelectedItemsForPackage.Add(UsersItem[i].ToString());

                        //refresh combobox
                        UsersItem.Remove(UsersItem[i]);
                        Items.Items.Clear();
                        for (int j = 0; j < UsersItem.Count; j++)
                            Items.Items.Add(UsersItem[j].ToString());
                        break;
                    }
                    i++;
                }
                ChosenItemsForPackage.ItemsSource = null;
                ChosenItemsForPackage.ItemsSource = ChosenFieldsForPackage;
            }
          
      
        private void CreatePackage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n;
                if (txtStartDate.Text == "")
                {
                    MessageBox.Show("Please insert start date", "Error");
                    return;
                }
                else if (txtEndDate.Text == "")
                {
                    MessageBox.Show("Please insert end date", "Error");
                    return;
                }
                else if (!int.TryParse(priceAllCatecories.Text, out n))
                {
                    MessageBox.Show("Price/deposite not valid", "Error");
                    return;
                }

                if (SelectedItemsForPackage.Count > 1)
                {
                    controller.AddPackageToUser(SelectedItemsForPackage);
                    string itemsId = controller.getItemsID(SelectedItemsForPackage);
                    writeToPackageTable(itemsId);

                    MessageBox.Show("Package Added succefully!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Choose at least 2 items for package!");
                  
                }

                int result = txtStartDate.SelectedDate.Value.Date.CompareTo(txtEndDate.SelectedDate.Value.Date);
                {
                    if (result == 1)
                    {
                        MessageBox.Show("Please end date after start date", "Error");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Please choose item", "Error");
                return;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PackacgeMain win2 = new PackacgeMain(controller);

            win2.Show();
            Close();
        }
        private string getPackageId()
        {
            return controller.getPackageId();
        }

        private void writeToPackageTable(string itemsid)
        {
            int PackageId;
            if (Int32.TryParse(getPackageId(), out PackageId))
                PackageId++;
            string _StartDate = txtStartDate.SelectedDate.Value.Date.ToShortDateString();
            string _EndDate = txtEndDate.SelectedDate.Value.Date.ToShortDateString();
            string _duration = txDuration.Text;


            string query = string.Format("Insert Into Package\nValues({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}')",
                PackageId,
                itemsid,
                 _deadline,
                _policy,
                _StartDate,
                _EndDate,
                _duration,
                _trash,
                _action,
                controller.currentUserId,
                _name

                );

            writeToDB(query);

            switch (_action)
            {
                case "Donation":
                    writeToSpecificPackageTable("Donation_package", PackageId, priceAllCatecories.Text);
                    break;
                case "Rent":
                    writeToSpecificPackageTable("Renting_package", PackageId, priceAllCatecories.Text);
                    break;
                case "Exchange":
                    writeToSpecificPackageTable("Trade_package", PackageId, priceAllCatecories.Text);
                    break;
                default:
                    writeToSpecificPackageTable("Renting_package", PackageId, priceAllCatecories.Text);
                    break;
            }


        }
        private void writeToSpecificPackageTable(string TableName, int PackageId, string cost)
        {
            string query = string.Format("Insert Into " + TableName + "\nValues({0},{1},{2})",
            PackageId,
             cost,
             1

            );
            writeToDB(query);
        }
        private void writeToDB(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(controller.ConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
    }
}
    
