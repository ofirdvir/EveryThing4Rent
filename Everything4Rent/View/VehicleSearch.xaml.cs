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
    /// Interaction logic for VehicleSearch.xaml
    /// </summary>
    public partial class VehicleSearch : Window
    {


        string type;
        string action;
        DateTime? startDate;
        DateTime? EndDate;
        Controller Controller;
        string _category;

        //   public DefaultSearchResults(string TypeCombo, string ActionCombo, string CategoryCombo, DateTime? DateStart, DateTime? DateEnd, Controller c)

        public VehicleSearch(string type, string action, string category, DateTime? DateStart, DateTime? DateEnd, Controller conteroller)
        {
            InitializeComponent();
            this.type = type;
            _category = category;
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
                return;
            List<string> AllVihicleItems = Controller.GetQueryResults(type, action, _category, startDate, EndDate, Controller.CurrentUser);
            List<string> ans = new List<string>();
            List<string> vihicleItemId1 = new List<string>();
            List<string> specificPackgeTable = new List<string>();
            List<string> itemsToShow = new List<string>();
            List<string> answer = new List<string>();
            List<string> FinalvihicleItemId = new List<string>();
            //type


            string vihicleQuery = "SELECT Item_id FROM Item_Vehicle Where model ='" + Model.Text + "' AND manufecturer = '" + Manu.Text + "' AND gear = '" + ((ComboBoxItem)gir.SelectedValue).Content as string + "'";


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
            string specificPackgeQuery = "SELECT package_id FROM " + specificPackageTable + " WHERE " + cost + ">=" + specificPackagePrice +" AND isPackage = " + 0;
            specificPackgeTable = Controller.getIdListforSerach(specificPackgeQuery);
 

            List<string> packageToItem = new List<string>();
            foreach (string package in specificPackgeTable)
            {
                int packageID = 0;
                int.TryParse(package, out packageID);
                string query = "SELECT item_id FROM Package WHERE Package_id= " + packageID;
                packageToItem.Add(Controller.getId(query));
            }

            vihicleItemId1 = Controller.getIdListforSerach(vihicleQuery);


            List<string> temp1 = new List<string>();
            for (int n = 0; n < packageToItem.Count; n++)
            {
                for (int u = 0; u < vihicleItemId1.Count; u++)
                {
                    if (vihicleItemId1[u] == packageToItem[n])
                        temp1.Add(vihicleItemId1[u]);
                }
            }

            vihicleItemId1 = temp1;

           for (int j = 0; j < packageToItem.Count; j++)
                {
                    string startDateQuery = "SELECT year_manu FROM Item_Vehicle WHERE Item_id =" + vihicleItemId1[j];
                    int year2;
                    int yearfromxaml;
                    int.TryParse(Controller.getId(startDateQuery), out year2);
                    int.TryParse(year.Text, out yearfromxaml);

                    if (yearfromxaml <= year2)
                    {
                        string itemName = "SELECT item_name FROM Items WHERE Item_id =" + vihicleItemId1[j];
                        FinalvihicleItemId.Add(Controller.getId(itemName));
                    }
                }
            

            int i = 0;
            while (i < AllVihicleItems.Count)
            {
                for (int j = 0; j < FinalvihicleItemId.Count; j++)
                {
                    if (AllVihicleItems[i][0] == FinalvihicleItemId[j][0])
                    {
                        itemsToShow.Add(AllVihicleItems[i]);
                    }
                }
                i++;
            }

            DefaultSearchResults w2 = new DefaultSearchResults(itemsToShow, action, Controller);

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
            if(String.IsNullOrEmpty(Manu.Text))
            {
                MessageBox.Show("Please Insert Valid Manufacture", "Error");
                return false;
            }
            if (String.IsNullOrEmpty(Model.Text))
            {
                MessageBox.Show("Please Insert Valid Model", "Error");
                return false;
            }
            int y;
            if (!int.TryParse(year.Text, out y))
            {
                MessageBox.Show("Please Insert Valid Year", "Error");
                return false;
            }
            return true;

        }
    }
}
