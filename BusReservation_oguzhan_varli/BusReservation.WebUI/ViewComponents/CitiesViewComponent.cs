using BusReservation.Business.Abstract;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservation.WebUI.ViewComponents
{
    public class CitiesViewComponent : ViewComponent
    {
        private ICityService _cityService;
        public CitiesViewComponent(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cityService.GetAll());
        }
    }
}
