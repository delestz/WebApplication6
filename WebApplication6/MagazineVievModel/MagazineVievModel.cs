
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.MagazineVievModel
{
    public class MagazineModel
    {
        public IEnumerable<BuyerModel> Buyers { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
        public IEnumerable<ProductModel> Prroducts { get; set; }
    }
}
