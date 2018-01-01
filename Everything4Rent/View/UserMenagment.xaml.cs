using Everything4Rent.View;
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

namespace Everything4Rent
{

    /// <summary>
    /// Interaction logic for UserMenagment.xaml
    /// </summary>
    public partial class UserMenagment : Window
    {
        Controller controller;
        public UserMenagment(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();

        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            var window = new AddTopicWindow(controller);
            window.ShowDialog();
        }

        private void AddPackage_Click(object sender, RoutedEventArgs e)
        {
            var window = new PackacgeMain(controller);
            window.ShowDialog();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wq = new MainWindow();
            wq.Show();
            Close();
        }

        private void ItemOpe(object sender, RoutedEventArgs e)
        {
            Item_Operations w1 = new Item_Operations(controller);
            w1.Show();
        }
    }
}
