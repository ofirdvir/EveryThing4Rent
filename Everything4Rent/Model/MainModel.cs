using Everything4Rent.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Everything4Rent.Model
{
    public class MainModel
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
        public MainModel(Dictionary<int, User> allUsersInDB, Dictionary<string, string> userNameAndPassword)
        {
            _allUsersInDB = allUsersInDB;
            UsersIndex = _allUsersInDB.Count;
            this.userNameAndPassword = userNameAndPassword;
            ConnectionString = string.Format(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ={0}\Everything4Rent.accdb", Environment.CurrentDirectory);
        }

        public List<string> Search(string type, string action, string category, DateTime? dateStart, DateTime? dateEnd , string user_name)
        {
            string userq = " select user_id  from  Users where user_name = '" + user_name + "'";
            string userid = getId(userq);


            List<string> ans = new List<string>();
            List<string> item_id = new List<string>(); ;
            if (type == "Items")
            {
                string itemNameQuery = "SELECT item_id FROM " + type + " WHERE action = '" + action + "' AND category = '" + category + "'";
                if (userid != "")
                    itemNameQuery += " AND user_id Not like " + userid + "";
                item_id = getIdList(itemNameQuery);


            }
            else
            {
                string itemNameQuery = "SELECT Package_id FROM " + type + " WHERE action = '" + action + "'";
                if (userid != "")
                    itemNameQuery += " AND user_id Not like " + userid + "";
                item_id = getIdList(itemNameQuery);
            }


            for (int i = 0; i < item_id.Count; i++)
            {
                string startDateQuery = "SELECT StartDate FROM Package WHERE item_id ='" + item_id[i] + "'";
                DateTime startDate = getDate(startDateQuery);
                string endDateQuery = "SELECT EndDate FROM Package WHERE item_id ='" + item_id[i] + "'";
                DateTime endDate = getDate(endDateQuery);
                if (dateStart >= startDate && endDate >= dateEnd)
                {
                    string pack_name = "SELECT package_name From Package WHERE item_id = '" + item_id[i] + "'";
                    string name = getId(pack_name);
                    ans.Add(name );
                }


            }
 

            return ans;
        }

        private DateTime getDate(string DateQuery)
        {
            DateTime date;
            //List<string> dateFractions = new List<string>();
            string[] dateFractions = new string[3];
            DateTime itemID = new DateTime();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(DateQuery, connection))
                    {
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            dateFractions = reader[0].ToString().Split('/');
                        }

                    }
                }
                Int32 day; Int32 month; Int32 year;
                Int32.TryParse(dateFractions[0], out day);
                Int32.TryParse(dateFractions[1], out month); Int32.TryParse(dateFractions[2], out year);
                return new DateTime(year, day, month);
            }

            catch (Exception e)
            {
                return itemID;
            }
        }

        public List<string> getIdList(string itemNameQuery)
        {
            List<string> itemID = new List<string>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(itemNameQuery, connection))
                    {
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string id = reader[0].ToString();
                            itemID.Add(id);
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

        public string getItemsID(List<string> itemName)
        {
            List<string> packageItemsID = new List<string>();
            string ans = "";
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
            for (int i = 0; i < packageItemsID.Count; i++)
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
              4,
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
            string query = "SELECT Package_id FROM Package WHERE package_name = " + name1;
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

        internal bool checkIfUsernameUnique(string name)
        {
            string name1 = "'" + name + "'";
            string query = "SELECT count(*) FROM Users WHERE user_name = " + name1;

            string itemId = getId(query);

            int count = Int32.Parse(itemId);

            if ( count > 0)
            {
                return false;
            }
            return true;

        }




        public void writeToDB(string query)
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

        public OleDbConnection getConnection()
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
            int numberId = 0;
            if (Int32.TryParse(item.ID, out numberId))
            {
                numberId = AllItemsIndex;
                _allUsersInDB[currentUserId].ItemsofUser.Add(item);
                AllItemsIndex++;
            }
        }

        public string getItemId()
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

        public string getPackageId()
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


        public List<string> tradeItemsByUsers()
        {

            string itemidquery = "SELECT Package_id FROM Package WHERE action = Exchange and user_id = " + CurrentUser + "";
            return getPackegesByUsers(itemidquery);
        }



        public List<string> getPackegesByUsers(string packagelistOfItemsQuery)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(packagelistOfItemsQuery, connection))
                    {
                        List<string> s = new List<string>();
                        int readerIndex = 0;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            s.Add(reader[readerIndex].ToString());
                            readerIndex++;
                        }

                        return s;

                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string borrowItem(string pack_name, DateTime? start, DateTime? end)

        {
           
            //  if (start == null || end == null)

            /////////////////////////////// change real item name

          //  item_name = "sdf";
            string itemidquery = "SELECT item_id FROM Items WHERE item_name ='" + pack_name + "'";
            string itemId = getId(itemidquery);


            string packageidq = "SELECT Package_id FROM Package WHERE package_name ='" + pack_name + "'";
            string packageid = getId(packageidq);

            string policyquery = "SELECT policy FROM Package WHERE package_name= '" + pack_name + "'";
            string policy = getId(policyquery);



            string startDate = "SELECT StartDate FROM Package WHERE [package_name ] = '" + pack_name + "'";
            DateTime item_start_date = getDate(startDate);

            string endDate = "SELECT EndDate  FROM Package WHERE [package_name] =  '" + pack_name + "'";
            DateTime item_end_date = getDate(endDate);

            if (start >= item_start_date && end<= item_end_date)
            {
                //   string new_date_ask1 = "Update Package SET StartDate = '" + defult + "'" + "where item_id = " + "'" + item_name + "'";
                //   string new_date_ask2 = "Update Package SET EndtDate = '" + defult + "'" + "where item_id = " + "'" + item_name + "'";





                string useridquery = "SELECT user_id FROM Package WHERE [package_name] = '" + pack_name + "'";
                string userid = getId(useridquery);

                if (policy.Equals("Conservative"))
                {

                    string tresholdquery = "SELECT treshold FROM Package WHERE [item_id] = '" + itemId + "'";
                    string tresh = getId(tresholdquery);


           

                    string rank = "SELECT consumer_rank FROM Users WHERE user_id = " + userid + "";
                    string cosrank = getId(rank);

                    int itemrank = Int32.Parse(tresh);

                    int costumerrank = Int32.Parse(cosrank);


                    if (costumerrank < itemrank)
                    {

                        return "Sorry, your rank is not enough";


                    }
                }

                    string statusq = "SELECT status FROM archives WHERE [Package_id] = " + packageid + "";
                    string status = getId(statusq);

                    if (status.Equals(""))
                    {

                        string query = string.Format("Insert Into archives\nValues({0},'{1}','{2}')",  packageid,  "in process", userid);
                        writeToDB(query);

                        return "success";
                    }
                    else
                    {

                        return "the package already in process";
                    }

            }



            return "Error";
        }


        public string getId(string itemNameQuery)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(itemNameQuery, connection))
                    {

                        reader = command.ExecuteReader();
                        reader.Read();
                        if (!reader.HasRows)
                            return "";
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