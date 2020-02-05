using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruckApp.Domain.Entities;
using TruckApp.Infra.DTO.Truck;
using TruckApp.Repository.Interfaces;
using TruckApp.Service.Interfaces;

namespace TruckApp.Service
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public TruckService(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<TruckDTO> CreateTruck(SaveTruckDTO dto)
        {
            var truck = new Truck
            {
                ModelId = dto.ModelId,
                ModelYear = dto.ModelYear,
                Name = dto.Name,
                YearManufacture = dto.YearManufacture
            };

            var insert = _truckRepository.Add(truck);

            return _mapper.Map<TruckDTO>(insert);
        }

        public async Task DeleteTruck(Guid id)
        {
            var truck = _truckRepository.FindById(id);
            _truckRepository.Remove(truck);
        }

        public async Task<TruckDTO> EditTruck(SaveTruckDTO dto)
        {
            var truck = _truckRepository.FindById(dto.Id.GetValueOrDefault());

            truck.Name = dto.Name;
            truck.ModelYear = dto.ModelYear;
            truck.YearManufacture = dto.YearManufacture;
            truck.ModelId = dto.ModelId;
            truck.UpdatedAt = DateTime.Now;

            var edited = _truckRepository.Edit(truck);

            return _mapper.Map<TruckDTO>(edited);
        }

        public async Task<SaveTruckDTO> FindTruckById(Guid id)
        {
            var truck = _truckRepository.FindById(id);
            return _mapper.Map<SaveTruckDTO>(truck);
        }

        public async Task<List<TruckDTO>> ListAllTrucks()
        {
            var list = _truckRepository.ListOrderBy(x => x.YearManufacture, true, x => x.Model).AsNoTracking();
            return _mapper.Map<List<TruckDTO>>(list);
        }
    }
}
