using DataLogic.Interfaces;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private Context db;
        public ProductRepository(Context context)
        {
            this.db = context;
        }
        public void Create(Product item)
        {
            db.product.Add(item);
        }

        public void Delete(int id)
        {
            Product product = db.product.Find(id);
            if (product != null)
                db.product.Remove(product);
        }

        public Product Read(int id)
        {
            return db.product.Find(id);
        }

        public IEnumerable<Product> ReadAll()
        {
            return db.product;
        }

        public void Update(Product item)
        {
            db.product.Update(item);
        }
    }
}
