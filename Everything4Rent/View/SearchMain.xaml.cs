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
    /// Interaction logic for SeachMail.xaml
    /// </summary>
    public partial class SearchMain : Window
    {
        private Controller conteroller;


        public SearchMain(Controller conteroller)
        {
            this.conteroller = conteroller;
            InitializeComponent();

            DateStart.SelectedDate = new DateTime(2001, 10, 20);
            DateEnd.SelectedDate = DateTime.Now.Date;
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<string> s = conteroller.GetQueryResults(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate, conteroller.CurrentUser);
            DefaultSearchResults w1 = new DefaultSearchResults(s, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, conteroller);

            w1.Show();
            Close();
        }

        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {

            if (CategoryCombo.SelectedIndex == 0) //viehcle
            {
                VehicleSearch w1 = new VehicleSearch(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate, conteroller);
                w1.Show();

            }

            if (CategoryCombo.SelectedIndex == 1) //secondHand
            {
                SecondHandSearch w1 = new SecondHandSearch(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate, conteroller);
                w1.Show();
            }

            if (CategoryCombo.SelectedIndex == 2) //Real Estate
            {
                // List<string> s = conteroller.GetQueryResults(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate);
                RealEstateSearch w1 = new RealEstateSearch(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate, conteroller);
                w1.Show();

            }
            if (CategoryCombo.SelectedIndex == 3) //PET
            {
                petSearch w1 = new petSearch(((ComboBoxItem)TypeCombo.SelectedValue).Content as string, ((ComboBoxItem)ActionCombo.SelectedValue).Content as string, ((ComboBoxItem)CategoryCombo.SelectedValue).Content as string, DateStart.SelectedDate, DateEnd.SelectedDate, conteroller);
                w1.Show();
            }
        }



        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void TypeCombo_DropDownClosed(object sender, EventArgs e)
        {
            string choose = ((ComboBoxItem)TypeCombo.SelectedValue).Content as string;
            if (choose == "Package")
            {
                CategoryCombo.Visibility = Visibility.Collapsed;
                titleCat.Visibility = Visibility.Collapsed;
            }
            if (choose == "Items")
            {
                CategoryCombo.Visibility = Visibility.Visible;
                titleCat.Visibility = Visibility.Visible;
            }

        }
    }
}
