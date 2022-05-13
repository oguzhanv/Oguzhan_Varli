using BusReservation.Data.Abstract;
using BusReservation.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete.EfCore
{
    public class EfCoreCityRepository : EfCoreGenericRepository<City, BusResContext>, ICityRepository
    {
    }
}
