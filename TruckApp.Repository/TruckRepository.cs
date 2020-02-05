using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;
using TruckApp.Infra.Persistence;
using TruckApp.Repository.Base;
using TruckApp.Repository.Interfaces;

namespace TruckApp.Repository
{
    public class TruckRepository : RepositoryBase<Truck, Guid>, ITruckRepository
    {
        public TruckRepository(DataContext _context) : base(_context)
        {
        }
    }
}
