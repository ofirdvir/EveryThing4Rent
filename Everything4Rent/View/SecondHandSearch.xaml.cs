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
    /// Interaction logic for SexondHandSearch.xaml
    /// </summary>
    public partial class SecondHandSearch : Window
    {


        string type;
        string action;
        DateTime? startDate;
        DateTime? EndDate;
        Controller Controller;
        string _category;
        public SecondHandSearch(string type, string action, string category, DateTime? DateStart, DateTime? DateEnd, Controller conteroller)
        {
            InitializeComponent();
            this.type = type;
            this.action = action;
            this.startDate = DateStart;
            this.EndDate = DateEnd;
            _category = category;
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
            if (!checkIsValid())
                return;

            List<string> AllSecondHandItems = Controller.GetQueryResults(type, action, _category, startDate, EndDate, Controller.CurrentUser);
            List<string> ans = new List<string>();
            List<string> secondHandItemId = new List<string>();
            List<string> specificPackgeTable = new List<string>();
            List<string> itemsToShow = new List<string>();
            List<string> answer = new List<string>();
            //type

            string SecondHand = "SELECT item_id FROM Item_SecondHand Where quelity ='" + ((ComboBoxItem)typQuality.SelectedValue).Content as string + "' AND type = '" + ((ComboBoxItem)typType.SelectedValue).Content as string + "'";
            if (type == "Package" || type == "Items")
            {
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

                List<string> packageToItem = new List<string>();
                foreach (string package in specificPackgeTable)
                {
                    int packageID = 0;
                    int.TryParse(package, out packageID);
                    string query = "SELECT item_id FROM Package WHERE Package_id= " + packageID;
                    packageToItem.Add(Controller.getId(query));
                }


                List<string> tempSecondHandItemId = new List<string>();
                tempSecondHandItemId = Controller.getIdListforSerach(SecondHand);
                string SecondHand_purchuse_date = "SELECT purchuse_date FROM Item_SecondHand Where item_id = ";

                List<string> temp1 = new List<string>();
                for (int n = 0; n < packageToItem.Count; n++)
                {
                    for (int u = 0; u < tempSecondHandItemId.Count; u++)
                    {
                        if (tempSecondHandItemId[u] == packageToItem[n])
                            temp1.Add(tempSecondHandItemId[u]);
                    }
                }

                tempSecondHandItemId = temp1;

                DateTime dataToComper = purchaseDate.SelectedDate.Value.Date;
                foreach (string item_id in tempSecondHandItemId)
                {
                    string purchuse_date_query = SecondHand_purchuse_date + item_id;
                    string purchuse_date = Controller.getId(purchuse_date_query);
                    string[] date = purchuse_date.ToString().Split('/');

                    Int32 day; Int32 month; Int32 year;
                    Int32.TryParse(date[0], out day);
                    Int32.TryParse(date[1], out month);
                    Int32.TryParse(date[2], out year);
                    DateTime purchuse = new DateTime(year, day, month);

                    if (dataToComper.CompareTo(purchuse) > -1)
                    {
                        secondHandItemId.Add(item_id);
                    }
                }


                for (int j = 0; j < secondHandItemId.Count; j++)
                {
                    for (int i = 0; i < AllSecondHandItems.Count; i++)
                    {
                        if (AllSecondHandItems[i][0] == secondHandItemId[j][0])
                        {
                            string itemName = "SELECT item_name FROM Items WHERE Item_id =" + secondHandItemId[j];
                            itemsToShow.Add(Controller.getId(itemName));
                        }
                    }

                }
            }
            //string startDateQuery = "SELECT StartDate FROM Package WHERE item_id ='" + item_id[i] + "'";

            DefaultSearchResults w2 = new DefaultSearchResults(itemsToShow, action, Controller);

            w2.Show();

            /// itemsToShow;
        }

        private bool checkIsValid()
        {
            int x;
            if (!int.TryParse(priceAllCatecories.Text, out x))
            {
                MessageBox.Show("Please Insert Valid Price", "Error");
                return false;
            }
            if (purchaseDate.Text == "")
            {
                MessageBox.Show("Please Insert Valid Date", "Error");
                return false;
            }
            return true;

        }
    }
}