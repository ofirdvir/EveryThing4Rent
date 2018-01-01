using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything4Rent
{

    public class Controller
    {
        public int currentUserId;
        public int AllPackegesIndex = 0;
        public int AllItemsIndex = 0;
        public static int UsersIndex = 0;
        public static int ItemsIndex = 0;
        public string CurrentUser = "";
        public string ConnectionString;
        public Dictionary<int, User> _allUsersInDB { get; set; } //INDEX AND USER FOR ALL USERS
        public static int id = 0;
        public Dictionary<string, string> userNameAndPassword { get; set; } //from DB!! inex,user       
        public Controller(Dictionary<int, User> allUsersInDB, Dictionary<string, string> userNameAndPassword)
        {
            _allUsersInDB = allUsersInDB;
            UsersIndex = _allUsersInDB.Count;
            this.userNameAndPassword = userNameAndPassword;
            ConnectionString = string.Format(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);

        }

        public string getItemsID(List<string> itemName)
        {
            List<string> packageItemsID = new List<string>();
            string ans="";
            for (int i = 0; i < itemName.Count; i++)
            {
                string name = "'" + itemName[i] + "'";
                string query = "SELECT item_id FROM Items WHERE item_name = " + name;
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            packageItemsID.Add(reader[0].ToString());
                        }
                    
                    }
                }
            }
            for(int i=0;i< packageItemsID.Count;i++)
            {
                ans += packageItemsID[i] + ",";
            }
            return ans;
        }

        /// <summary>
        /// Write new user to DB!
        /// </summary>
        /// <param name="txtFullName"></param>
        /// <param name="txtAge"></param>
        /// <param name="Gender"></param>
        /// <param name="Email"></param>
        /// <param name="PayPalUseName"></param>
        /// <param name="PayPalPassword"></param>
        /// need to add user name & password for user!!
        public void AddUserToDB(string firstName, string lastName, string userName, string password, string txtAge, string Gender, string Email, string PayPalUseName, string PayPalPassword)
        {
            User user = new User(UsersIndex, firstName, lastName, userName, password, txtAge, Gender, Email, PayPalUseName, PayPalPassword);
            try
            {
                _allUsersInDB.Add(UsersIndex, user);
            }
            catch (Exception)
            {
                ///need to choose another user name
            }
            currentUserId = UsersIndex;
            UsersIndex++;
            string query = string.Format("Insert Into Users\nValues({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14})",
              currentUserId,
              firstName,
              lastName,
              txtAge,
              Gender,
             password,
              Email,
              "pass creation",
              userName,
              PayPalUseName,
              PayPalPassword,
              "buisness",
              "broker",
              0,
              0
              );
            writeToDB(query);

        }

        internal List<string> getUserItems(string action)
        {
            List<string> userItems = new List<string>();
            string Action = "'" + action + "'";
            string query = "SELECT item_name FROM Items WHERE action = " + Action + " AND user_id = " + currentUserId;
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userItems.Add(reader[0].ToString());
                    }

                    return userItems;
                }
            }
        }
        /// <summary>
        /// new
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>

        internal List<string> getUserItems()
        {
            List<string> userItems = new List<string>();
     
            string query = "SELECT item_name FROM Items WHERE user_id = " + currentUserId;
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userItems.Add(reader[0].ToString());
                    }

                    return userItems;
                }
            }
        }


        internal bool checkMail(string email)
        {
           //string mail = "'" + email + "'";

            //  string sql = "SELECT E-MAIL FROM Users WHERE E-MAIL = " + email;
            string mail = "'" + email + "'";
            string query = "SELECT age FROM Users WHERE EMAIL = " + mail;
            bool rtn;
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    object obj = command.ExecuteScalar();
                    int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
                    rtn = (count == 0);
                }
                return rtn;
            }
        }

        internal bool checkIfnameUnique(string name)
        {
            string name1 = "'" + name + "'";
            string query = "SELECT item_id FROM Items WHERE item_name = " + name1;
            bool rtn;
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    object obj = command.ExecuteScalar();
                    int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
                    rtn = (count == 0);
                }
                return rtn;
            }

        }

        private void writeToDB(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private OleDbConnection getConnection()
        {
            string ConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);
            return new OleDbConnection(ConnectionString);
        }

        /// <summary>
        /// write to DB new package!
        /// </summary>
        public void AddPackageToUser(List<string> SelectedItemsForPackage)
        {
            _allUsersInDB[currentUserId].PackgesOfUser.Add(new Package(SelectedItemsForPackage));
            AllPackegesIndex++;
        }
        public void AddItemToUser(IItem item)
        {
            int numberId=0;
            if (Int32.TryParse(item.ID, out numberId))
            {
                numberId = AllItemsIndex;
                _allUsersInDB[currentUserId].ItemsofUser.Add(item);
                AllItemsIndex++;
            }
        }

        internal string getItemId()
        {
            string query = "SELECT MAX(item_id) FROM Items";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        reader.Read();
                        if (string.Empty == reader[0].ToString())
                            return "0";
                        return reader[0].ToString();
                    }
                }
            }

            catch (Exception e)
            {
                return "0";
            }


        }

        internal string getPackageId()
        {
            string query = "SELECT MAX(package_id) FROM Package";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        reader = command.ExecuteReader();
                        reader.Read();
                        if (string.Empty == reader[0].ToString())
                            return "0";
                        return reader[0].ToString();
                    }
                }
            }

            catch (Exception e)
            {
                return "0";
            }

        }
    }
}
