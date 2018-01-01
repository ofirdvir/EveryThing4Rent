using System;
using System.Collections.Generic;
using System.Data;
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

namespace Everything4Rent
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        string userName = "";
        string password = "";
        Controller _controller;
        public LogInWindow(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        /// <summary>
        /// Connect to DB and gets the relevant info
        /// In case that the info is not relevant, a pop up message will appear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            bool valid = chackIfValid();
            if (valid)
            {
                _controller.CurrentUser = userName;
                readFromDB();
                UserMenagment win2 = new UserMenagment(_controller);
                win2.Show();
                Close();
            }
        }

        private void readFromDB()
        {
            string ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);

            OleDbConnection connection = new OleDbConnection(ConnectionString);

            if (connection.State == ConnectionState.Closed && connection != null)
                connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT user_id FROM Users WHERE user_name =" + "'" + userName + "'", connection);
            reader = command.ExecuteReader();
            reader.Read();
            int userID;

            if (reader.FieldCount > 0 && Int32.TryParse(reader[0].ToString(), out userID))
                _controller.currentUserId = userID;
            else
            {
                //throw message 
            }

        
        }

        /// <summary>
        /// checks if the Paswword exist in the DB!
        /// </summary>
        /// <returns></returns>
        private bool chackIfValid()
        {
            if (txtUserName.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please Insert all the Mandatory Fields", "Error");
                return false;
            }
            userName = txtUserName.Text;
            password = txtPassword.Password;
            if (_controller.userNameAndPassword.ContainsKey(userName))
            {
                if (_controller.userNameAndPassword[userName] != txtPassword.Password)
                {
                    MessageBox.Show("The Password is Wrong", "Error");
                    return false;

                }
                else
                    return true;
            }
            else
            {
                MessageBox.Show("The User Name does not exist! ", "Error");
                return false;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            Close();
        }
    }

}
