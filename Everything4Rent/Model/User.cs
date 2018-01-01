using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything4Rent
{
    public class User
    {
        public List<IItem> ItemsofUser { get; set; } ///the item of the user     
        public List<Package> PackgesOfUser { get; set; } ///the pa of the user

        public string UserID { get; set; }
        public string txtFirstName { get; set; }
        public string txtLastName { get; set; }
        public string txtAge { get; set; }
        public string gender { get; set; }
        public string payPalUseName { get; set; }
        public string payPalPassword { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public User(int ID, string txtFirstName, string txtLastName, string userName, string password, string txtAge, string gender, string email, string payPalUseName, string payPalPassword)
        {
            UserID = ID.ToString();
            this.password = password;
            this.userName = userName;
            this.txtFirstName = txtFirstName;
            this.txtLastName = txtLastName;
            this.txtAge = txtAge;
            this.gender = gender;
            Email = email;
            this.payPalUseName = payPalUseName;
            this.payPalPassword = payPalPassword;
            ItemsofUser = new List<IItem>();
            PackgesOfUser = new List<Package>();
        }
    }
}

