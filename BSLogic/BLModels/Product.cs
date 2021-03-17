using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Models
{
    public class ProductBL
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category Catagery { get; set; }
        public string Cpecific { get; set; }
        public double Price { get; set; }
        public byte[] ProductImg { get; set; }
    }
}
