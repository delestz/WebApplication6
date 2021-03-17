using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLogic.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(6)]
        public string NumberOfOrder { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
