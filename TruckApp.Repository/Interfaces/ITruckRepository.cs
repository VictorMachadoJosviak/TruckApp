using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities;

namespace TruckApp.Repository.Interfaces
{
    public interface ITruckRepository : IRepositoryBase<Truck, Guid>
    {
    }
}
