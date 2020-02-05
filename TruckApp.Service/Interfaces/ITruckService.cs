using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruckApp.Infra.DTO.Truck;

namespace TruckApp.Service.Interfaces
{
    public interface ITruckService
    {
        Task<List<TruckDTO>> ListAllTrucks();

        Task<TruckDTO> CreateTruck(SaveTruckDTO dto);
        Task<TruckDTO> EditTruck(SaveTruckDTO dto);

        Task<SaveTruckDTO> FindTruckById(Guid id);

        Task DeleteTruck(Guid id);
    }
}
