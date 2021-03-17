using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Models
{
    public class OrderBL
    {
        public int Id { get; set; }
        public string NumberOfOrder { get; set; }
        public int ProductId { get; set; }
        public ProductBL Product { get; set; }

    }
}
