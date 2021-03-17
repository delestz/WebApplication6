using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Models
{
    public class BuyerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Prhome { get; set; }
        public string Email { get; set; }
        public List<OrderModel> Orders { get; set; }


    }
}
