using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TruckApp.Infra.DTO.Model;

namespace TruckApp.Service.Interfaces
{
    public interface IModelService
    {
        Task<List<ModelDTO>> ListModels();
    }
}
