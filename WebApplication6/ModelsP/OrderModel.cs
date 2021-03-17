using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string NumberOfOrder { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
