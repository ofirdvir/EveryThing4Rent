using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything4Rent
{
    public interface IItem
    {
        string ID { get; set; }
        string ItemName { get; set; }
        string _category { get; set; }
    }
}
