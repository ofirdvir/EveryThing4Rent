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
    /// Interaction logic for PackacgeMain.xaml
    /// </summary>
    public partial class PackacgeMain : Window
    {
        Controller controller;
        public PackacgeMain(Controller c)
        {
            controller = c;
            InitializeComponent();
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
                tresh.Visibility = Visibility.Visible;
                boxRandTreshold.Visibility = Visibility.Visible;

            }
            else if (policy == "First Come First Sarved" || policy == "Safe")
            {
                boxRandTreshold.Visibility = Visibility.Collapsed;
                tresh.Visibility = Visibility.Collapsed;
            }
        }


        private void AddPackage_Click(object sender, RoutedEventArgs e)
        {
            String typOfAdd1 = ((ComboBoxItem)typOfAdd.SelectedItem).Content as string;
            if (topicNameText.Text=="")
            {
                MessageBox.Show("Please Insert Name!!", "Error");
                return;
            }
            if (typOfAdd1 == "Type")
                {
                MessageBox.Show("Please Insert Policy!!", "Error");
                return;
            }
            string treshold="";
            if (tresh.SelectedIndex == -1 || tresh.SelectedIndex == 0)
                treshold = "";
            else
                treshold = ((ComboBoxItem)tresh.SelectedItem).Content as string;


            CreatePackage win2 = new CreatePackage(controller, typOfAdd1, ((ComboBoxItem)Policy.SelectedItem).Content as string, treshold, ((ComboBoxItem)deadline.SelectedItem).Content as string);

            if (win2.checkIfToOpen())
            {
                win2.Show();
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
