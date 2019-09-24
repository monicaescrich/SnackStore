using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestChallenge_FrontEnd_ME.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int Likes { get; set; }

        public int CategoryID { get; set; }
        public bool Discontinued { get; set; }
        public Category Category { get; set; }
    }
}
