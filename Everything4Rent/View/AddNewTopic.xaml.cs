
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Everything4Rent.View
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class AddTopicWindow : Window
    {
        Controller _controller;
        public AddTopicWindow(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }
        private void topicNameText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void AddAd_Click(object sender, RoutedEventArgs e)
        {
            string content = ((ComboBoxItem)typOfAdd.SelectedItem).Content as string;
            string category = ((ComboBoxItem)Category.SelectedItem).Content as string;

            if (!_controller.checkIfnameUnique(topicNameText.Text))

                {
                MessageBox.Show("Name already exist! please choose another name", "Error");
                return;
            }

            if (content == "Type" || category == "Category")
            {
                MessageBox.Show("Please Insert Category and Action", "Error");
                return;
            }
            if (topicNameText.Text == "")
            {
                MessageBox.Show("Please Insert Name", "Error");
                return;
            }
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
            int result=txtStartDate.SelectedDate.Value.Date.CompareTo(txtEndDate.SelectedDate.Value.Date);
            {
                if (result == 1)
                {
                    MessageBox.Show("Please end date after start date", "Error");
                    return;
                }
                   
            }


        
            Close();
            string tresh;
            if (Treshold.SelectedIndex == -1 || Treshold.SelectedIndex == 0)
                tresh = "";
            else
              tresh = ((ComboBoxItem)Treshold.SelectedItem).Content as string;
            var window = new Ad(_controller, topicNameText.Text, content, ((ComboBoxItem)Category.SelectedItem).Content as string, ((ComboBoxItem)Policy.SelectedItem).Content as string, tresh, ((ComboBoxItem)deadline.SelectedItem).Content as string, txtStartDate.SelectedDate.Value.Date.ToShortDateString(),  txtEndDate.SelectedDate.Value.Date.ToShortDateString(), txtDuration.Text);
                                           

            window.ShowDialog();
            /*
            if (content == "Rent")
            {
            
                var window = new RentAd(_controller, topicNameText.Text, ((ComboBoxItem)Category.SelectedItem).Content as string);
                window.ShowDialog();
            }
            if (content == "Donation")
            {
                var window = new DonationAd(_controller, topicNameText.Text, ((ComboBoxItem)Category.SelectedItem).Content as string);
                window.ShowDialog();
            }
            if (content == "Exchange")
            {
                var window = new ExchangeAd(_controller, topicNameText.Text, ((ComboBoxItem)Category.SelectedItem).Content as string);
                window.ShowDialog();
            }*/

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Policy_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {

        
          
            String policy = ((ComboBoxItem)Policy.SelectedItem).Content as string;
            if (policy == "Conservative")
            {
                Treshold.Visibility = Visibility.Visible;
                boxRandTreshold.Visibility = Visibility.Visible;

            }
            else if (policy == "First Come First Sarved" || policy == "Safe")
            {
                boxRandTreshold.Visibility = Visibility.Collapsed;
                Treshold.Visibility = Visibility.Collapsed;
            }
            
        }

        /// <summary>
        /// adding a topic for the system and making sure everything was inserted correctly,
        /// </summary>

    }
}

