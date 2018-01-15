using Everything4Rent.Model;
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
        public bool userLogedIn = false;

        public Dictionary<int, User> _allUsersInDB { get; set; } //INDEX AND USER FOR ALL USERS
        public static int id = 0;
        public Dictionary<string, string> userNameAndPassword { get; set; } //from DB!! inex,user       

        public MainModel mainModel;

        public Controller(Dictionary<int, User> allUsersInDB, Dictionary<string, string> userNameAndPassword)
        {
            _allUsersInDB = allUsersInDB;
            UsersIndex = _allUsersInDB.Count;
            this.userNameAndPassword = userNameAndPassword;
            ConnectionString = string.Format(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);

            mainModel = new MainModel(allUsersInDB, userNameAndPassword);
        }


        public List<string> Search(string type, string action, string category, DateTime? dateStart, DateTime? dateEnd)
        {
            return mainModel.Search(type, action, category, dateStart, dateEnd, CurrentUser);
        }

        private DateTime getDate(string startDateQuery)
        {
            DateTime itemID = new DateTime();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(startDateQuery, connection))
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string id = reader.GetString(reader.GetOrdinal("item_id"));
                            }
                        }
                    }
                }
                return itemID;
            }

            catch (Exception e)
            {
                return itemID;
            }
        }

        internal List<string> getIdListforSerach(string query)
        {
            return mainModel.getIdList(query);
        }

        private List<string> getIdList(string itemNameQuery)
        {
            return getIdList(itemNameQuery);
        }
        public string getId(string itemNameQuery)
        {
            return mainModel.getId(itemNameQuery);
        }
            public string getItemsID(List<string> itemName)
        {

            return mainModel.getItemsID(itemName);
        }

        public List<string> GetQueryResults(string typeCombo, string actionCombo, string categoryCombo, DateTime? dateStart, DateTime? dateEnd,string userName)
        {
            return mainModel.Search(typeCombo, actionCombo, categoryCombo, dateStart, dateEnd, userName);
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
            mainModel.AddUserToDB(firstName, lastName, userName, password, txtAge, Gender, Email, PayPalUseName, PayPalPassword);
        }

        public List<string> tradeItemsByUsers()
        {
            return mainModel.tradeItemsByUsers();
        }

        public string borrowItem(string itemName, DateTime? selectedDate1, DateTime? selectedDate2)
        {
           return mainModel.borrowItem(itemName, selectedDate1, selectedDate2);
        }

        public List<string> getUserItems(string action)
        {
            return mainModel.getUserItems(action);
        }
        /// <summary>
        /// new
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>

        public List<string> getUserItems()
        {
            return mainModel.getUserItems();
        }

        public bool checkMail(string email)
        {
            return mainModel.checkMail(email);
        }

        public bool checkIfnameUnique(string name)
        {
            return mainModel.checkIfnameUnique(name);

        }
        internal bool checkIfUsernameUnique(string name)
        {
            return mainModel.checkIfUsernameUnique(name);
        }

        public void writeToDB(string query)
        {
            mainModel.writeToDB(query);
        }


        /// <summary>
        /// write to DB new package!
        /// </summary>
        public void AddPackageToUser(List<string> SelectedItemsForPackage)
        {
            mainModel.AddPackageToUser(SelectedItemsForPackage);
        }
        public void AddItemToUser(IItem item)
        {
            mainModel.AddItemToUser(item);
        }

        public string getItemId()
        {
            return mainModel.getItemId();

        }

        public string getPackageId()
        {
            return mainModel.getPackageId();
        }



    }
}
