using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string BatDescription { get; set; }
        public string BatId { get; set; }
        public string BatType { get; set; }
        public decimal BatPrice { get; set; }
    }
}
