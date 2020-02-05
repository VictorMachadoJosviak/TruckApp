using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Infra.Persistence;

namespace TruckApp.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
