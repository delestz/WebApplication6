using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataLogic.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(9)]
        public int Prhome { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
