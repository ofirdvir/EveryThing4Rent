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
    /// Interaction logic for DefaultSearchResults.xaml
    /// </summary>
    public partial class DefaultSearchResults : Window
    {
 
        List<string> result;
        string _action;
        Controller controller;
        public DefaultSearchResults(List<string> results,string action,Controller c)
        {
            InitializeComponent();
            result = results;
            _action = action;
            showResults(result);
            controller = c;
            borrow.Visibility = Visibility.Collapsed;
            if(result.Count==0)
            {
                MessageBox.Show("No Results found. Please Try Differnt Parameters", "Error");
              
            }
            if (controller.userLogedIn)
                logInOptions();
        }
      

        private void logInOptions()
        {

            if (_action == "Donation" || _action == "Exchange")
            {
                borrow.Visibility = Visibility.Visible;
            }
            if (_action == "Exchange")
            {
                ItemToBorrow.Visibility = Visibility.Collapsed;
                ItemsToBorrowCombo.Visibility = Visibility.Collapsed;
                ItemsToChange.Visibility = Visibility.Visible;
                ItemsToChangeCombo.Visibility = Visibility.Visible;
                Borrow.Content = "Exchange";
            }
            else if (_action == "Donation")
            {
                ItemToBorrow.Visibility = Visibility.Visible;
                ItemsToBorrowCombo.Visibility = Visibility.Visible;
                ItemsToChange.Visibility = Visibility.Collapsed;
                ItemsToChangeCombo.Visibility = Visibility.Collapsed;
            }
        }

        private void showResults(List<string> results)
        {
            for (int i = 0; i < results.Count; i++) {
                ChosenItemsForPackage.Items.Add(results[i]);
                ItemsToBorrowCombo.Items.Add(results[i]);
                ItemsToChangeCombo.Items.Add(results[i]);


            }

        }



        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            if (DateStart.Text == "")
            {
                MessageBox.Show("Please insert start date", "Error");
                return;
            }
            else if (DateEnd.Text == "")
            {
                MessageBox.Show("Please insert end date", "Error");
                return;
            }

            if (_action == "Donation")
            {
                if (ItemsToBorrowCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose item");
                    return;
                }

                string itemName = ItemsToBorrowCombo.SelectedValue.ToString();
                borrowItem(itemName, DateStart.SelectedDate, DateEnd.SelectedDate);
            }



            if (_action == "Exchange")
            {
                if (ItemsToChangeCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose item");
                    return;
                }
              
                string itemName = ItemsToChangeCombo.SelectedValue.ToString();
                tradeItem(itemName, DateStart.SelectedDate, DateEnd.SelectedDate);
            }
        }

        private void borrowItem(string itemName, DateTime? selectedDate1, DateTime? selectedDate2)//to check that the date is valid
        {
            MessageBox.Show(controller.borrowItem(itemName, selectedDate1, selectedDate2)); 
        }

        private void tradeItem(string itemName, DateTime? selectedDate1, DateTime? selectedDate2)
        {


            if (controller.borrowItem(itemName, selectedDate1, selectedDate2) == "seccess")
            {

                TradeAction w2 = new TradeAction(controller.tradeItemsByUsers());
                w2.Show();

                Close();
            }
            else
                MessageBox.Show(controller.borrowItem(itemName, selectedDate1, selectedDate2));
        }
    }
}
