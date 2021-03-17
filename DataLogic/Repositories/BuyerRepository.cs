using DataLogic.Interfaces;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Repositories
{
    public class BuyerRepository : IRepository<Buyer>
    {
        private Context db;
        public BuyerRepository(Context context)
        {
            this.db = context;
        }
        public void Create(Buyer item)
        {
            db.buyer.Add(item);
        }

        public void Delete(int id)
        {
            Buyer buyer = db.buyer.Find(id);
            if (buyer != null)
                db.buyer.Remove(buyer);
        }

        public Buyer Read(int id)
        {
            return db.buyer.Find(id);
        }

        public IEnumerable<Buyer> ReadAll()
        {
            return db.buyer;
        }

        public void Update(Buyer item)
        {
            db.buyer.Update(item);
        }
    }
}
