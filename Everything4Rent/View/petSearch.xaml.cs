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
using System.Windows.Shapes;

namespace Everything4Rent.View
{
    /// <summary>
    /// Interaction logic for petSearch.xaml
    /// </summary>
    public partial class petSearch : Window
    {
        string _type;
        string action;
        DateTime? startDate;
        DateTime? EndDate;
        Controller Controller;
        string _category;
        public petSearch(string type, string action, string category, DateTime? DateStart, DateTime? DateEnd, Controller conteroller)
        {
            InitializeComponent();
            _category = category;
            this._type = type;
            this.action = action;
            this.startDate = DateStart;
            this.EndDate = DateEnd;
            Controller = conteroller;

            if (action == "Rent")
                txtCost.Visibility = Visibility.Visible;
            if (action == "Exchange")
                txtPatioalCost.Visibility = Visibility.Visible;
            if (action == "Donation")
                txtDeposit.Visibility = Visibility.Visible;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!checkIfValid())
            {
                return;
            }
            List<string> AllPetItems = Controller.GetQueryResults(_type, this.action, _category, startDate, EndDate, Controller.CurrentUser);
            List<string> ans = new List<string>();
            List<string> petItemId = new List<string>();
            List<string> specificPackgeTable = new List<string>();
            List<string> itemsToShow = new List<string>();
            List<string> answer = new List<string>();
            //type

            string petQuery = "SELECT item_id FROM Item_Pet Where gender ='" + ((ComboBoxItem)Gender.SelectedValue).Content as string + "' AND type = '" + type.Text + "'";
            //string startDateQuery = "SELECT StartDate FROM Package WHERE item_id ='" + item_id[i] + "'";
            //   if (_type == "Package")
            //{
            string specificPackageTable = "";
            string specificPackagePrice = "";
            switch (action[0])
            {
                case 'R':
                    specificPackageTable = "Renting_package";
                    specificPackagePrice = "price";
                    break;
                case 'E':
                    specificPackageTable = "Trade_package";
                    specificPackagePrice = "partial_price";
                    break;
                default:
                    specificPackageTable = "Donation_package";
                    specificPackagePrice = "deposit";
                    break;
            }
            int cost = 0;
            Int32.TryParse(priceAllCatecories.Text, out cost);
            string specificPackgeQuery = "SELECT package_id FROM " + specificPackageTable + " WHERE " + cost + ">=" + specificPackagePrice + " AND isPackage = " + 0;
            specificPackgeTable = Controller.getIdListforSerach(specificPackgeQuery);
            petItemId = Controller.getIdListforSerach(petQuery);

            //string Age1 = "SELECT Item_id FROM Item_Pet WHERE age = "+ age.Text;

            // List<string> ages = Controller.getIdListforSerach(Age1);
            string Age1 = "SELECT age FROM Item_Pet WHERE Item_id = ";
            List<string> temp = new List<string>();
            List<string> packageToItem = new List<string>();

            foreach (string package in specificPackgeTable)
            {
                int packageID = 0;
                int.TryParse(package, out packageID);
                string query = "SELECT item_id FROM Package WHERE Package_id= " + packageID;
                packageToItem.Add(Controller.getId(query));
            }
            for (int m = 0; m < petItemId.Count; m++)
            {
                int age2 = 0;
                Age1 += petItemId[m];
                int.TryParse(Controller.getId(Age1), out age2);
                int ageXaml = 0;
                int.TryParse(age.Text, out ageXaml);
                if (age2 <= ageXaml)
                    temp.Add(petItemId[m]);
            }
            petItemId = temp;

            List<string> temp1 = new List<string>();
            for (int n = 0; n < packageToItem.Count; n++)
            {
                for (int u = 0; u < petItemId.Count; u++)
                {
                    if (petItemId[u] == packageToItem[n])
                        temp1.Add(petItemId[u]);
                }
            }

            petItemId = temp1;

            for (int j = 0; j < petItemId.Count; j++)
            {
                for (int i = 0; i < AllPetItems.Count; i++)
                {
                    string itemName = "SELECT item_name FROM Items WHERE Item_id =" + petItemId[j];
                    itemName = Controller.getId(itemName);
                    if (AllPetItems[i] == itemName)
                    {
                       
                        itemsToShow.Add(itemName);
                    }
                }

            }
            DefaultSearchResults w2 = new DefaultSearchResults(itemsToShow, action, Controller);

            w2.Show();

        }

        private bool checkIfValid()
        {
            int x;
            if (!int.TryParse(priceAllCatecories.Text, out x))
            {
                MessageBox.Show("Please Insert Valid Price", "Error");
                return false;
            }
            if(String.IsNullOrEmpty(type.Text))
            {
                MessageBox.Show("Please Insert Valid Type", "Error");
                return false;
            }
            if (String.IsNullOrEmpty(race.Text))
            {
                MessageBox.Show("Please Insert Valid Race", "Error");
                return false;
            }
            int y;
            if (!int.TryParse(age.Text, out y))
            {
                MessageBox.Show("Please Insert Valid Age", "Error");
                return false;
            }
            return true;
        }
    }
}
