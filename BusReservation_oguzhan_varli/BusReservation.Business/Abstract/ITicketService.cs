using BusReservation.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface ITicketService
    {
        Ticket GetById(int id);
        List<Ticket> GetAll();
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
        void Crete(Ticket ticket);
    }
}
