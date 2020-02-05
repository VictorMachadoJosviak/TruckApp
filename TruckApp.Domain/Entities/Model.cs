using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities.Base;

namespace TruckApp.Domain.Entities
{
    public class Model : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Truck> Trucks { get; set; }
    }
}
