using BusReservation.Business.Abstract;
using BusReservation.Data.Abstract;
using BusReservation.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Concrete
{
    public class RouteManager : IRouteService
    {
        private IRouteRepository _routeRepository;
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public void Create(Route route)
        {
            _routeRepository.Create(route);
        }

        public void Delete(Route route)
        {
            _routeRepository.Delete(route);
        }

        public List<Route> GetAll()
        {
            return _routeRepository.GetAll();
        }

        public Route GetById(int id)
        {
            return _routeRepository.GetById(id);
        }

        public void Update(Route route)
        {
            _routeRepository.Update(route);
        }
    }
}
