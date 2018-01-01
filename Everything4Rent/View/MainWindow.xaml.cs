using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Everything4Rent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller conteroller;
        Dictionary<int, User> allUserDb = new Dictionary<int, User>();
        Dictionary<string, string> allUserNameAndPassword = new Dictionary<string, string>();
        public MainWindow()
        {

            /// read this from DB!
            ///
            connectToDB();

            conteroller = new Controller(allUserDb, allUserNameAndPassword);
            InitializeComponent();

        }

        private void connectToDB()
        {
            OleDbConnection connection = null; ;
            try
            {
                string ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);
                connection = new OleDbConnection(ConnectionString);
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand command = new OleDbCommand("SELECT * from Users ", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int ID;
                    Int32.TryParse(reader[0].ToString(), out ID);
                    string firstName = reader[1].ToString(); string lastName = reader[2].ToString();
                    string age = reader[3].ToString(); string gender = reader[4].ToString();
                    string payPalUser = reader[11].ToString(); string payPalPassword = reader[12].ToString();
                    string Email = reader[6].ToString(); string password = reader[5].ToString();
                    string userName = reader[8].ToString();
                    string PassWord = reader[5].ToString();


                    allUserDb.Add(ID, new User(ID, firstName, lastName, userName, password, age, gender, Email, payPalUser, payPalPassword));
                    allUserNameAndPassword.Add(userName, PassWord);

                }
                connection.Close();
            }
            catch(Exception e)
            {
                if(connection != null )
                connection.Close();
            }

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            /*
            MyGrid.Children.Clear();
            UserControl _currentUser = new SignUpWindow(conteroller);
            MyGrid.Children.Add(_currentUser);*/

            SignUpWindow win2 = new SignUpWindow(conteroller);
            win2.Show();
            Close();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow win2 = new LogInWindow(conteroller);
            win2.Show();
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
