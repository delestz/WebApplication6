using DataLogic.Interfaces;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private Context db;
        public OrderRepository(Context context)
        {
            this.db = context;
        }
        public void Create(Order item)
        {
            db.order.Add(item);
        }

        public void Delete(int id)
        {
            Order order = db.order.Find(id);
            if (order != null)
                db.order.Remove(order);
        }

        public Order Read(int id)
        {
            return db.order.Find(id);
        }

        public IEnumerable<Order> ReadAll()
        {
            return db.order;
        }

        public void Update(Order item)
        {
            db.order.Update(item);
        }
    }
}
