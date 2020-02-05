using System;
using System.Collections.Generic;
using System.Text;
using TruckApp.Domain.Entities.Base;

namespace TruckApp.Domain.Entities
{
    public class Truck : EntityBase
    {
        public Truck() : base()
        {
            YearManufacture = DateTime.Now.Year;
        }

        public string Name { get; set; }
        public int YearManufacture { get; set; }
        public int ModelYear { get; set; }
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }

    }
}
