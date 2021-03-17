using AutoMapper;
using BSLogic;
using DataLogic;
using DataLogic.Models;
using System;
using System.Collections.Generic;

namespace BSLogic
{
    public class BLogic : IDisposable
    {
        private MapperConfiguration configuration;
        private Mapper Mapper;
        private UnitForWork db { get; }

        public BLogic()
        {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductBL>();
                cfg.CreateMap<Buyer, BuyerBL>();
                cfg.CreateMap<Order, OrderBL>();
            });
            configuration.AssertConfigurationIsValid();
            Mapper = new Mapper(configuration);
            db = new UnitForWork();
        }

        public void AddProduct(ProductBL productBL)
        {
            db.Products.Create(Mapper.Map<Product>(productBL));
            db.Save();
        }
        public void AddOrder(OrderBL orderBL)
        {
            Product product = Mapper.Map<Product>(orderBL.Product);
            Order order = new Order()
            {
                Product = product,
                ProductId = orderBL.ProductId
            };
            db.Orders.Create(order);
            db.Save();
        }
        public void AddBuyer(BuyerBL buyerBL)
        {
            List<Order> orders = Mapper.Map<List<Order>>(buyerBL.Orders);

            Buyer buyer = new Buyer()
            {
                Name = buyerBL.Name,
                Email = buyerBL.Email,
                Orders = orders,
                Prhome = buyerBL.Prhome
            };
            db.Buyers.Create(buyer);
            db.Save();

        } 
        public void RemoveBuyer(int id)
        {
            db.Buyers.Delete(id);
            db.Save();
        }
        public void RemoveOrders(int id)
        {
            db.Orders.Delete(id);
            db.Save();
        }
        public void RemoveProduct(int id)
        {
            db.Products.Delete(id);
            db.Save();
        }
        public void UpdateBuyer(BuyerBL element)
        {
            Buyer toUpdate = db.Buyers.Read(element.Id);
            List<Order> list = new List<Order>();
            foreach (OrderBL model in element.Orders)
                list.Add(db.Orders.Read(model.Id));

            if (toUpdate != null)
            {
                toUpdate.Name = element.Name;
                toUpdate.Orders = list;
                toUpdate.Prhome = element.Prhome;
                toUpdate.Email = element.Email;
                db.Buyers.Update(toUpdate);
                db.Save();
            }
        }

        public void UpdateProduct(ProductBL element)
        {
            Product toUpdate = db.Products.Read(element.Id);

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Product>(element);
                db.Products.Update(toUpdate);
                db.Save();
            }
        }

        public IEnumerable<BuyerBL> GetBuyers()
        {
            List<BuyerBL> result = new List<BuyerBL>();

            foreach (var item in db.Buyers.ReadAll())
                result.Add(new BuyerBL
                {
                    Name = item.Name,
                    Prhome = item.Prhome,
                    Email = item.Email,
                    Orders = Mapper.Map<List<OrderBL>>(item.Orders)                    
                });            

            return result;
        }
        public IEnumerable<OrderBL> GetOrders()
        {
            List<OrderBL> result = new List<OrderBL>();

            foreach (var item in db.Orders.ReadAll())
            {
                result.Add(new OrderBL
                {
                    NumberOfOrder = item.NumberOfOrder,
                    Product = Mapper.Map<ProductBL>(item.Product),
                    ProductId = item.ProductId
                });
            }

            return result;
        }
        public IEnumerable<ProductBL> GetProducts()
        {
            List<ProductBL> result = new List<ProductBL>();

            foreach (var item in db.Products.ReadAll())
                result.Add(Mapper.Map<ProductBL>(item));

            return result;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
