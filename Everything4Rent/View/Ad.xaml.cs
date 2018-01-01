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
    /// Interaction logic for Donation.xaml
    /// </summary>
    public partial class Ad : Window
    {
        string _name;
        string _Category;
        string _Action;
        string _Policy;
        string _Deadline;
        string _StartDate;
        string _EndDate;
        string _duration;
        
        string _treshold="";
        string descritopn = "";
        Controller _controller;
 

        public Ad(Controller controller, string Name, string Action, string Category, string policy ,string treshold,string deadline,string startDate,string endDate, string duation)
        {
            InitializeComponent();
            _Category = Category;
            _controller = controller;
            _Action = Action;
            _name = Name;
            _Deadline = deadline;
            _Policy = policy;
 
            _StartDate = startDate;
            _EndDate = endDate;
            _duration = duation;
            _treshold = treshold;

            initializeGrid();
        }

        private void initializeGrid()
        {
            if (_Action == "Rent")
            {
                RentGrid.Visibility = Visibility.Visible;
                myWindow.Height = 540;
                GridLengthConverter myGridLengthConverter = new GridLengthConverter();
                GridLength gl1 = (GridLength)myGridLengthConverter.ConvertFromString("85");
                ActionRow1Hight.Height = gl1;
            }
            else if (_Action == "Donation")
            {
                GridLengthConverter myGridLengthConverter = new GridLengthConverter();
                GridLength gl1 = (GridLength)myGridLengthConverter.ConvertFromString("75");
                ActionRow1Hight.Height = gl1;
                myWindow.Height = 550;
                DonationGrid.Visibility = Visibility.Visible;

            }
            else if (_Action == "Exchange")
            {
                ExchangeGrid.Visibility = Visibility.Visible;
                GridLengthConverter myGridLengthConverter = new GridLengthConverter();
                GridLength gl1 = (GridLength)myGridLengthConverter.ConvertFromString("135");
                myWindow.Height = 590;
                ActionRow1Hight.Height = gl1;

            }

            if (_Category == "Pet")
            {
                myWindow.Height = myWindow.Height - 255;
                PetGrid.Visibility = Visibility.Visible;
            }
            else if (_Category == "Vehicle")
            {
                VehicleGrid.Visibility = Visibility.Visible;
                myWindow.Height = myWindow.Height-150;

            }
            else if (_Category == "Second Hand")
            {
                SecondHandGrid.Visibility = Visibility.Visible;
                myWindow.Height = myWindow.Height - 300;
            }
            else if (_Category == "Real Estate")
            {
                RealEstateGrid.Visibility = Visibility.Visible;
                myWindow.Height = myWindow.Height - 115;
            }
        }
       
        private void Publish_Click(object sender, RoutedEventArgs e)
        {
            bool ans = checkValitaion();
            IItem item = null;
            int numberId;
            if (Int32.TryParse(getItemId(), out numberId))
                numberId++;
            string Id = numberId.ToString();
          
              
            if(ans)
            {

                if (_Action == "Donation")
                {
                    item = new DonationItem(_name, _Category, descritopn, Id);
                }
                if (_Action == "Rent")
                {
                    item = new RentItem(_name, _Category, descritopn, Id);
                }
                if (_Action == "Exchange")
                {
                    item = new ExchangeItem(_name, _Category, descritopn, Id);
                }
                //dbxt;
                _controller.AddItemToUser(item);
                UpdateItemInDB(item);

                MessageBox.Show("Item added succesfully!");
                Close();
            }
        }

        private string getItemId()
        {
            return _controller.getItemId();
        }

        private void UpdateItemInDB(IItem item)
        {
            switch (_Category)
            {
                case "Pet":
                    writeForPet(item);
                    break;
                case "Real Estate":
                    writeForRealEstate(item);
                    break;
                case "Vehicle":
                    writeForVehicle(item);
                    break;
                default:
                    writeForSecondHand(item);
                    break;
            }
            writeNewItemToItemTable(item);
            writeToPackageTable(item);
            
        }

        private void writeToSpecificPackageTable(string TableName , int PackageId, string cost)
        {
            string query = string.Format("Insert Into "+ TableName+"\nValues({0},'{1}')",
              PackageId,
               cost
              );
            writeToDB(query);
        }

        private void writeToPackageTable(IItem item)
        {
            int PackageId;
            if (Int32.TryParse(getPackageId(), out PackageId))
                PackageId++;

            string query = string.Format("Insert Into Package\nValues({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                PackageId,
                item.ID,
                 _Deadline,
                _Policy,
                _StartDate,
                _EndDate,
                _duration,
                _treshold,
                _Action
            
                );
            writeToDB(query);
           
            switch (_Action)
            {
                case "Donation":
                    writeToSpecificPackageTable("Donation_package", PackageId, txtDeposite1.Text);
                    break;
                case "Rent":
                    writeToSpecificPackageTable("Renting_package", PackageId, txtCost.Text);
                    break;
                case "Exchange":
                    writeToSpecificPackageTable("Trade_package", PackageId, txtPatialPrice.Text);
                    break;
                default:
                    writeToSpecificPackageTable("Renting_package", PackageId,"0");
                    break;
            }
            
        }

        private string getPackageId()
        {
            return _controller.getPackageId();
        }

        private void writeForSecondHand(IItem item)
        {          
            string query = string.Format("Insert Into Item_SecondHand\nValues({0},'{1}','{2}','{3}')",
            item.ID,
              txtpurchase.Text,
              txtItemQuality.Text,              
              ((ComboBoxItem)typType.SelectedItem).Content as string
               );
            writeToDB(query);
        }

        private void writeForVehicle(IItem item)
        {
            
            string Gear = ((ComboBoxItem)typGearbox1.SelectedItem).Content as string;
            string volum = txtEngineVolume.Text;
            string color = txtColor.Text;
            string km = txtKM.Text;
            string query = string.Format("Insert Into Item_Vehicle\nValues({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
               item.ID,
               txtmanufacturer.Text,
               txtItemModel.Text,
               volum,
              txtItemYear.Text,
              Gear,
              color,
              km
               );
            writeToDB(query);
        }

        private void writeForRealEstate(IItem item)
        {
            string type = ((ComboBoxItem)ComboTypeRent.SelectedItem).Content as string;
            string query = string.Format("Insert Into Item_RealEstate\nValues({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
               item.ID,
               txtItemCity.Text,
               txtItemStreet.Text,
               txtItemStreetNum.Text,///todo
               txtApartmentNum.Text,///todo
               txtMaxPeople.Text,
              txtSize.Text,
              txtFacilityDesc.Text,
              type
               );
       

            writeToDB(query);
        }

        private void writeNewItemToItemTable(IItem item)
        {
            //need to calculate from combo boxes + add to item interface and implement at each item
           
            string query = string.Format("Insert Into Items\nValues({0},{1},{2},'{3}','{4}')",
              item.ID,
              _controller.currentUserId,
               0,
              _name,
              _Action
              );
            writeToDB(query);
        }

        private void writeForPet(IItem item)
        {
            string query = string.Format("Insert Into Item_Pet\nValues({0},'{1}','{2}','{3}','{4}')",
              item.ID,
              txtPetType.Text,
              typGender.Text,
              txtPetRace.Text,
              txtPetAge.Text
              );
            writeToDB(query);
        }

        private void writeToDB(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_controller.ConnectionString))
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

        private bool checkValitaion()
        {
            bool ans = false;
         

            if (_Category == "Pet")
            {
                int n, s;
                if (!int.TryParse(txtPetAge.Text, out n))
                {
                    MessageBox.Show("Pet Age is not valid", "Error");
                    return false;
                }
                if (txtPetType.Text != "" && txtPetRace.Text != "" && ((ComboBoxItem)typGender.SelectedItem).Content as string != "" && txtPetAge.Text != "")
                {
                    ans = true;
                    descritopn = "Pet Type" + txtPetType.Text + "Pet Race" + txtPetRace.Text + "Pet Gender" + ((ComboBoxItem)typGender.SelectedItem).Content as string + "Pet Age" + txtPetAge.Text;
                }
                else
                {
                    txtPetType.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtPetType.BorderThickness = new Thickness(1);
                    txtPetRace.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtPetRace.BorderThickness = new Thickness(1);
                    txtPetAge.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtPetAge.BorderThickness = new Thickness(1);
                    MessageBox.Show("Please Insert all the Mandatory Fields", "Error");

                }

            }
            else if (_Category == "Second Hand")
            {
                if (txtpurchase.Text != "" || typType.Text != "")
                {
                    ans = true;
                    descritopn = "Item Type" + txtpurchase.Text + "Item Qualoty" + txtItemQuality.Text;
                }
                else
                {
                    txtpurchase.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtpurchase.BorderThickness = new Thickness(1);
                    typType.BorderBrush = new SolidColorBrush(Colors.Red);
                    typType.BorderThickness = new Thickness(1);
                    MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                }
            }
            else if (_Category == "Vehicle")
            {
                if (txtmanufacturer.Text != "" && txtItemModel.Text != "" && txtItemYear.Text != "")
                {
                    ans = true;
                    descritopn = "manufacturer" + txtmanufacturer.Text + "Item model" + txtItemModel.Text + "Item Year" + txtItemYear.Text;
                }
                else
                {
                    txtItemModel.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtItemModel.BorderThickness = new Thickness(1);
                    txtmanufacturer.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtmanufacturer.BorderThickness = new Thickness(1);
                    txtItemYear.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtItemYear.BorderThickness = new Thickness(1);
                    MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                }
            }

            else if (_Category == "Real Estate")
            {
                int n,s;
                if (!int.TryParse(txtSize.Text, out n))
                {
                    MessageBox.Show("size is not valid", "Error");
                    return false;
                }
                if (!int.TryParse(txtItemStreetNum.Text, out n))
                {
                    MessageBox.Show("Street Num is not valid", "Error");
                    return false;
                }
                if (txtSize.Text != "" && txtItemCity.Text != "" && txtItemStreet.Text != "" && txtItemStreetNum.Text != "")
                {
                    ans = true;
                    descritopn = "size" + txtSize.Text + "address" + txtItemCity.Text + "Type" + txtItemStreetNum.Text;
                }
                else
                {
                    txtSize.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtSize.BorderThickness = new Thickness(1);
                    txtItemCity.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtItemCity.BorderThickness = new Thickness(1);
                    txtItemStreet.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtItemStreet.BorderThickness = new Thickness(1);
                    txtItemStreetNum.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtItemStreetNum.BorderThickness = new Thickness(1);
                    MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                }
            }
            if (_Action == "Rent" && ans)
            {
                int n;
               // string policy = ((ComboBoxItem)Boxpolicy.SelectedItem).Content as string;
                if (!int.TryParse(txtCost.Text, out n)){
                    MessageBox.Show("Cost is not valid", "Error");
                    return false;
                }
                if (txtCost.Text != ""  )/// checks if there is policy&cost
                    ans = true;
                else
                {
                    ans = false;
                    MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                }
            }
            return ans;
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // UserMenagment win2 = new UserMenagment(_controller);
            // win2.Show();
            Close();
        }
    }
}
