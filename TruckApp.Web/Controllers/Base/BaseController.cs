using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckApp.Infra.Transactions;

namespace TruckApp.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<IActionResult> ViewAsync(object result,string controllerName = null,string actionName = null)
        {
            if (result != null && ModelState.IsValid)
            {
                try
                {

                    _unitOfWork.Commit();

                    if (string.IsNullOrEmpty(controllerName) && string.IsNullOrEmpty(actionName))
                    {
                        return View(result);
                    }
                    else if (!string.IsNullOrEmpty(actionName))
                    {
                        return RedirectToAction(actionName);
                    }
                    else
                    {
                        return RedirectToAction(actionName, controllerName);
                    }
                    
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Erro interno no servidor");
                }
            }
            else
            {
                return View(result);
            }
        }

        protected async Task<PartialViewResult> PartialViewAsync(string partialName, object data)
        {
            try
            {
                _unitOfWork.Commit();
                return PartialView(partialName,data);
            }
            catch (Exception ex)
            {
                return PartialView(new { error = ex.Message });
            }
        }
    }
}
