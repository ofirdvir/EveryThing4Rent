using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything4Rent
{
    class RentItem :IItem
    {
        public string ID { get; set; }
        public string _category { get; set; }
        public string ItemName { get; set; }
        string _descrition;/// all the item fields!

        public RentItem(string name,  string category, string description ,string ID)
        {
            _category = category;
            _descrition = description;
            ItemName = name;
            this.ID = ID;
        }


    }
}
