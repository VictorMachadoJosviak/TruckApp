using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TruckApp.Infra.DTO.Model;
using TruckApp.Infra.DTO.Truck;
using TruckApp.Infra.Transactions;
using TruckApp.Service.Interfaces;
using TruckApp.Web.Controllers.Base;
using TruckApp.Web.Models;

namespace TruckApp.Web.Controllers
{
    public class TruckController : BaseController
    {
        private readonly ITruckService _truckService;
        private readonly IModelService _modelService;

        public TruckController(IUnitOfWork unitOfWork,ITruckService truckService, IModelService modelService) : base(unitOfWork)
        {
            _truckService = truckService;
            _modelService = modelService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _truckService.ListAllTrucks());
        }

        public async Task<PartialViewResult> _ListTrucks()
        {
            return PartialView("_ListTrucks",await _truckService.ListAllTrucks());
        }

        public async Task<IActionResult> Save(Guid? idTruck)
        {
            var models = await _modelService.ListModels();
            ViewData["ModelId"] = new SelectList(models, "Id", "Name");

            if (idTruck.HasValue)
            {
                var truck = await _truckService.FindTruckById(idTruck.GetValueOrDefault());
                return await ViewAsync(truck);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SaveTruckDTO dto)
        {
            var models = await _modelService.ListModels();
            models = models ?? new List<ModelDTO>();
            ViewData["ModelId"] = new SelectList(models, "Id", "Name");

            if (ModelState.IsValid)
            {
                if (dto.Id.HasValue)
                {
                    var edited = await _truckService.EditTruck(dto);
                    return await ViewAsync(edited, "Truck", "Index");
                }
                else
                {
                    var truck = await _truckService.CreateTruck(dto);
                    return await ViewAsync(truck, "Truck", "Index");
                }               
            }
            return View();            
        }


        public async Task<PartialViewResult> Delete(Guid idTruck)
        {
            await _truckService.DeleteTruck(idTruck);
            var list = await _truckService.ListAllTrucks();
            return await PartialViewAsync("_ListTrucks", list);
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
