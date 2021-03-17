using AutoMapper;
using DataLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Controllers
{
    public class RegistrationController : Controller
    {
        private Mapper Mapper;
        private MapperConfiguration configuration;
        public RegistrationController()
        {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BuyerBL, BuyerModel>();
            });

            Mapper = new Mapper(configuration);
        }
        public IActionResult Registr()
        {
            return View();
        }
        public IActionResult SaveChanges(string email, string name, int phone)
        {
            BuyerBL buyer = new BuyerBL()
            {
                Name = name,
                Email = email,
                Prhome = Convert.ToInt32(phone)
            };
            using(var db = new BSLogic.BLogic())
            {
                db.AddBuyer(Mapper.Map<BuyerBL>(buyer));
            }
            return Redirect("~/Home/Index");
        }
    }
}
