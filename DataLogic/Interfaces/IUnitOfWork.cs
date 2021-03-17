using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLogic.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Buyer> Buyers { get; }
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        void Save();
    }
}
