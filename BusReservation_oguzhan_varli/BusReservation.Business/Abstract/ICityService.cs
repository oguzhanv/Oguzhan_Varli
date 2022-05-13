using BusReservation.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface ICityService
    {
        City GetById(int id);
        List<City> GetAll();
        void Update(City city);
        void Delete(City city);
        void Create(City city);
    }
}
