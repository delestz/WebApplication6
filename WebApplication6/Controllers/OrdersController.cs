using ASP.MagazineVievModel;
using AutoMapper;
using BSLogic;
using DataLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Controllers
{
    public class OrdersController : Controller
    {
        private Mapper Mapper;
        private MapperConfiguration configuration;
        public OrdersController()
        {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderBL, OrderModel>();
                cfg.CreateMap<BuyerBL, BuyerModel>();
            });

            Mapper = new Mapper(configuration);
        }

        public IActionResult AddToOrder(string buyerId, string productId)
        {
            using (var db = new BLogic())
            {
                var model = new MagazineModel()
                {
                    Orders = Mapper.Map<List<OrderModel>>(db.GetOrders()),
                    Buyers = Mapper.Map<List<BuyerModel>>(db.GetBuyers()),
                    Prroducts = Mapper.Map<List<ProductModel>>(db.GetProducts())
                };
                var buffbuyer = from item in model.Buyers
                           where item.Id == Convert.ToInt32(buyerId)
                           select item;
                var buffproduct = from item in model.Prroducts
                                  where item.Id == Convert.ToInt32(productId)
                                  select item;
                db.AddOrder(new OrderBL() { NumberOfOrder = "123141251", Product = buffproduct as ProductBL });

                return View();
            }
        }
    }
}
