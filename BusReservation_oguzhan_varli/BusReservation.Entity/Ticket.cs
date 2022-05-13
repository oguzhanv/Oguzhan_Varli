using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string TicketSurname { get; set; }
        public string TicketFromWhere { get; set; }
        public string TicketToWhere { get; set; }
        public string TicketDate { get; set; }
        public double TicketPrice { get; set; }
        public int TicketSeatNo { get; set; }
        public City City { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
