using DataLogic.Interfaces;
using DataLogic.Models;
using DataLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic
{
    public class UnitForWork : IUnitOfWork
    {
        private Context db { get; }
        private BuyerRepository buyerRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        public UnitForWork()
        {
            this.db = new Context();
        }
        public IRepository<Buyer> Buyers
        {
            get
            {
                if (buyerRepository == null)
                    buyerRepository = new BuyerRepository(db);
                return buyerRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
