using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Models
{
    public class BuyerBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Prhome { get; set; }
        public string Email { get; set; }
        public List<OrderBL> Orders { get; set; }

    }
}
