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
    /// Interaction logic for TradeAction.xaml
    /// </summary>
    public partial class TradeAction : Window
    {
        public TradeAction(List<string>userItems)
        {
            InitializeComponent();
            for (int i = 0; i < userItems.Count; i++)
                ItemsToBorrowCombo.Items.Add(userItems[i]);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            ////צריך לחשוב פה איך לכתוב ששני האייטמים מוצגים כמושכרים....
            //זה האייטים שהמשתמש בחר:
            string chosenItem = ((ComboBoxItem)ItemsToBorrowCombo.SelectedItem).Content as string;

        }
    }
}
