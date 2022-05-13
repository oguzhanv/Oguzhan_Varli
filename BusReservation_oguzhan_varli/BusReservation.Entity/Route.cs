using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteStart { get; set; }
        public string? RouteFirstTransfer { get; set; }
        public string? RouteSecondTransfer { get; set; }
        public string? RouteThirdTransfer { get; set; }
        public string? RouteFourthTransfer { get; set; }
        public string RouteFinish { get; set; }
        public string RouteDate { get; set; }
        public double RouteClock { get; set; }
        public double RoutePrice { get; set; }

        public List<Ticket> Ticket { get; set; }
    }
}
