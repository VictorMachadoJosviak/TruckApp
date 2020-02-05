using System;
using System.Collections.Generic;
using System.Text;

namespace TruckApp.Infra.DTO.Truck
{
    public class TruckDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ModelId { get; set; }
        public string Model { get; set; }
        public int YearManufacture { get; set; }
        public int ModelYear { get; set; }
    }
}
