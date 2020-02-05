using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruckApp.Infra.DTO.Model;
using TruckApp.Repository.Interfaces;
using TruckApp.Service.Interfaces;

namespace TruckApp.Service
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<List<ModelDTO>> ListModels()
        {
            var list = _modelRepository.List();
            return _mapper.Map<List<ModelDTO>>(list);
        }
    }
}
