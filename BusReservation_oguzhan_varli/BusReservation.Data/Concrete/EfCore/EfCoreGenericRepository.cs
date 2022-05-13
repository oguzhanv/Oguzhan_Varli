using BusReservation.Data.Abstract;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<Tentity, Tcontext> : IRepository<Tentity> where Tentity:class where Tcontext:DbContext, new()
    {
        public void Create(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<Tentity> GetAll()
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().ToList();
            }
        }

        public Tentity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
