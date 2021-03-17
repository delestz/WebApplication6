using BSLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ASP.MagazineVievModel;
using System.IO;
using DataLogic.Models;


namespace ASP.Controllers
{
    public class ProductsController : Controller
    {
        private Mapper Mapper;
        private MapperConfiguration configuration;
        public ProductsController()
        {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductBL, ProductModel>();
                cfg.CreateMap<BuyerBL, BuyerModel>();
            });

            Mapper = new Mapper(configuration);
        }
        public IActionResult Drinks()
        {
            using(var db = new BLogic())
            {
                var buffmodel = Mapper.Map<List<ProductModel>>(db.GetProducts());
                var model1 = from item in buffmodel
                            where item.Catagery == Category.drink
                            select item;
                var model = new MagazineModel() { Prroducts = model1 };
                return View("Catalog", model);
            }
        }
        public IActionResult Food()
        {
            using (var db = new BLogic())
            {
                var buffmodel = Mapper.Map<List<ProductModel>>(db.GetProducts());
                var model1 = from item in buffmodel
                             where item.Catagery == Category.food
                             select item;
                var model = new MagazineModel() { Prroducts = model1, Buyers=Mapper.Map<List<BuyerModel>>(db.GetBuyers()) };
                return View("Catalog", model);
            }
        }
        public IActionResult Catalog(string category)
        {
            ViewBag.ImgWay = @"C:\Users\Kekozavrishe\source\repos\WebApplication6\WebApplication6\wwwroot\BuffImages\";
            using (var db = new BLogic())
            {
                var model = new MagazineModel()
                {
                    Prroducts = Mapper.Map<List<ProductModel>>(db.GetProducts()),
                    Buyers = Mapper.Map<List<BuyerModel>>(db.GetBuyers())
                };
                foreach (ProductModel item in model.Prroducts)
                {
                    Image buff = Image.FromStream(new MemoryStream(item.ProductImg));
                    buff.Save(@$"C:\Users\Kekozavrishe\source\repos\WebApplication6\WebApplication6\wwwroot\BuffImages\{item.ProductName}.jpg");
                }
                return View(model);
            }

        }
    }
}
