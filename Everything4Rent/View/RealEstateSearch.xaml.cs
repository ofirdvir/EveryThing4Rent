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
    /// Interaction logic for RealEstateSearch.xaml
    /// </summary>
    public partial class RealEstateSearch : Window

    {
        string _type;
        string _action;
        string _category;
        DateTime? _startDate;
        DateTime? _EndDate;
        Controller Controller;
        public RealEstateSearch(string type, string action, string category, DateTime? DateStart, DateTime? DateEnd, Controller conteroller)
        {
            InitializeComponent();
            _type = type;
            _category = category;
            _action = action;
            _startDate = DateStart;
            _EndDate = DateEnd;
            Controller = conteroller;

            if (action == "Rent")
                txtCost.Visibility = Visibility.Visible;
            if (action == "Trade")
                txtPatioalCost.Visibility = Visibility.Visible;
            if (action == "Donation")
                txtDeposit.Visibility = Visibility.Visible;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!checkIfValid())
                return;
            //List<string> AllRealEstateItems = Controller.GetQueryResults(_type, _action, _category, _startDate, _EndDate, Controller.CurrentUser);
            List<string> ans = new List<string>();
            List<string> realEstateItemId = new List<string>();
            List<string> specificPackgeTable = new List<string>();
            List<string> itemsToShow = new List<string>();
            List<string> answer = new List<string>();
            //type
            int size1;

            int.TryParse(size.Text, out size1);
            string RealEstateQuery = "SELECT item_id FROM Item_RealEstate WHERE type ='" + type.Text + "' AND city = '" + city.Text + "'" + " AND [size] <= " + size1 + "";


            realEstateItemId = Controller.getIdListforSerach(RealEstateQuery);

            string specificPackageTable = "";
            string specificPackagePrice = "";
            switch (_action[0])
            {
                case 'R':
                    specificPackageTable = "Rent_package";
                    specificPackagePrice = "price";
                    break;
                case 'T':
                    specificPackageTable = "Trade_package";
                    specificPackagePrice = "partial_price";
                    break;
                default:
                    specificPackageTable = "Donation_package";
                    specificPackagePrice = "deposit";
                    break;
            }
            int cost = 0;
            List<string> packageToItem = new List<string>();
            Int32.TryParse(priceAllCatecories.Text, out cost);
            string specificPackgeQuery = "SELECT package_id FROM " + specificPackageTable + " WHERE " + cost + ">=" + specificPackagePrice + " AND isPackage = 0";
            specificPackgeTable = Controller.getIdListforSerach(specificPackgeQuery);
            foreach (string package in specificPackgeTable)
            {
                int packageID = 0;
                int.TryParse(package, out packageID);
                string query = "SELECT item_id FROM Package WHERE Package_id= " + packageID;



                packageToItem.Add(Controller.getId(query));
            }

            for (int q = 0; q < packageToItem.Count; q++)
            {
                for (int k = 0; k < realEstateItemId.Count; k++)
                {
                    if (packageToItem[q] == realEstateItemId[k])
                        answer.Add(realEstateItemId[k]);
                }
            }
            for (int j = 0; j < realEstateItemId.Count; j++)
            {

                string itemName = "SELECT item_name FROM Items WHERE Item_id =" + realEstateItemId[j] + " AND user_id Not like " + Controller.currentUserId + "";
                itemsToShow.Add(Controller.getId(itemName));
                // FinalvihicleItemId.Add(Controller.getId(itemName));

            }

            DefaultSearchResults w2 = new DefaultSearchResults(itemsToShow, _action, Controller);

            w2.Show();

            /// itemsToShow;
        }

        private bool checkIfValid()
        {
            int x;
            if (!int.TryParse(priceAllCatecories.Text, out x))
            {
                MessageBox.Show("Please Insert Valid Price", "Error");
                return false;
            }

            if(String.IsNullOrEmpty(city.Text))
            {
                MessageBox.Show("Please Insert Valid City", "Error");
                return false;
            }
            int y;
            if (!int.TryParse(size.Text, out y))
            {
                MessageBox.Show("Please Insert Valid Size", "Error");
                return false;
            }
            if (String.IsNullOrEmpty(type.Text))
            {
                MessageBox.Show("Please Insert Valid Type", "Error");
                return false;
            }
            return true;
        }

        private void city_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
