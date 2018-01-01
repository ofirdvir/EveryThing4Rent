
﻿using System;
using System.Collections.Generic;
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

namespace Everything4Rent.View
{
    /// <summary>
    /// Interaction logic for Item_Operations.xaml
    /// </summary>
    public partial class Item_Operations : Window
    {
        Controller control;
        List<string> UsersItem = new List<string>();
        public Item_Operations(Controller c)
        {
            control = c;
            InitializeComponent();
            initializeItems();
        }



        private void initializeItems()
        {
            UsersItem = getUserItems();

            for (int i = 0; i < UsersItem.Count; i++)
            {
                comboDelete.Items.Add(UsersItem[i].ToString());
                
                showItem.Items.Add(UsersItem[i].ToString());
            }

        }

        private List<string> getUserItems()
        {
            return this.control.getUserItems();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(comboDelete.SelectedIndex==-1||comboDelete.SelectedIndex==-1)
            {
                MessageBox.Show("Please choose item to delete", "Error");
                return;
            }
            string itemName = comboDelete.SelectedValue.ToString();
            string itemNameQuery = "SELECT item_id FROM Items WHERE [item_name] = '" + itemName + "'";
            string item_id = getId(itemNameQuery);
            string DeleteFromItemsQuery = "DELETE FROM Items WHERE [item_id] = " + item_id + "";
            deleteFromItemsTable(DeleteFromItemsQuery);
            string packageIdQuery = "SELECT Package_id FROM Package WHERE item_id = '" + item_id + "'";
            string Package_id = getId(packageIdQuery);
            string DeleteFromPackagesQuery = "DELETE FROM Package WHERE [item_id] =  '" + item_id + "'";
            deleteFromPackageTable(DeleteFromPackagesQuery);
            string query = "SELECT Count(*) FROM Renting_package  where package_id =" + Package_id + "";
            string query1 = "SELECT Count(*) FROM Trade_package where package_id =" + Package_id + "";
            string query2 = "SELECT Count(*) FROM Donation_package where package_id =" + Package_id + "";
            string count = getId(query);
            string count1 = getId(query1);
            string count2 = getId(query2);
            int res = Int32.Parse(count);
            int res1 = Int32.Parse(count1);
            int res2 = Int32.Parse(count2);
            if (res > 0)
            {
                string query3 = "DELETE FROM Renting_package where  package_id = " + Package_id + "";
                DeleteFromSpecificPackageTable(query3);

            }
            if (res1 > 0)
            {
                string query4 = "DELETE FROM Trade_package where package_id = " + Package_id + "";
                DeleteFromSpecificPackageTable(query4);

            }
            if (res2 > 0)
            {
                string query5 = "DELETE FROM Donation_package where package_id = " + Package_id + "";
                DeleteFromSpecificPackageTable(query5);
            }
            string like = "%,%";
            string PackagelistOfItemsQuery = "SELECT item_id FROM Package WHERE item_id like '" + like + "'";
            deletePackeges(PackagelistOfItemsQuery, item_id);


            initializeItems();
            MessageBox.Show("Item deleted successfully!", "Error");
            Item_Operations sd = new Item_Operations(control);
            sd.Show();
            Close();
        }

        private void deletePackeges(string packagelistOfItemsQuery, string item_id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(packagelistOfItemsQuery, connection))
                    {
                        int readerIndex = 0;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string[] PackageItemList = (reader[readerIndex].ToString()).Split(',');
                            for (int i = 0; i < PackageItemList.Length - 1; i++)
                            {
                                if (PackageItemList[i].Equals(item_id))
                                {

                                    string Query = "SELECT Package_id FROM Package WHERE item_id ='" + reader[readerIndex].ToString() + "'";
                                    string packagId = getId(Query);
                                    string DeletePackageQuery = "DELETE Package_id FROM Package WHERE Package_id= " + packagId + "";
                                    deleteFromPackageTable(DeletePackageQuery);

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void DeleteFromSpecificPackageTable(string query3)
        {
            bool rtn;
            using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query3, connection))
                {
                    object obj = command.ExecuteScalar();
                    int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
                    rtn = (count == 0);
                }
            }
        }

        private void deleteFromPackageTable(string deleteFromPackagesQuery)
        {

            bool rtn;
            using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(deleteFromPackagesQuery, connection))
                {
                    object obj = command.ExecuteScalar();
                    int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
                    rtn = (count == 0);
                }
            }
        }
        private void deleteFromItemsTable(string query)
        {
            bool rtn;
            using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    object obj = command.ExecuteScalar();
                    int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
                    rtn = (count == 0);
                }
            }
        }
        private string getId(string itemNameQuery)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
                {
                    connection.Open();
                    OleDbDataReader reader = null;
                    using (OleDbCommand command = new OleDbCommand(itemNameQuery, connection))
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

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ShowItem win2 = new ShowItem(control, showItem.SelectedValue.ToString());
                win2.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Please choose item to show", "Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {



        }


        private string action()
        {

            string itemName = showItem.SelectedValue.ToString();


            string name = "'" + itemName + "'";


            string query = "SELECT action FROM Items WHERE item_name = " + name;
            string action = "";


            using (OleDbConnection connection = new OleDbConnection(control.ConnectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        action = reader[0].ToString();
                    }


                }
            }
            return action;

        }


    }


}
