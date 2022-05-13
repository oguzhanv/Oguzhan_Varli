using BusReservation.Entity;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new BusResContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Cities.Count() == 0)
                {
                    context.Cities.AddRange(Cities);
                }
                if (context.Routes.Count() == 0)
                {
                    context.Routes.AddRange(Routes);
                }
                if (context.Tickets.Count() == 0)
                {
                    context.Tickets.AddRange(Tickets);
                }
            }
            context.SaveChanges();
        }

        private static City[] Cities =
        {
            new City() {CityName="Adana"},
            new City() {CityName="Adıyaman"},
            new City() {CityName="Afyonkarahisar"},
            new City() {CityName="Ağrı"},
            new City() {CityName="Amasya"},
            new City() {CityName="Ankara"},
            new City() {CityName="Artvin"},
            new City() {CityName="Aydın"},
            new City() {CityName="Balıkesir"},
            new City() {CityName="Bilecik"},
            new City() {CityName="Bingöl"},
            new City() {CityName="Bitlis"},
            new City() {CityName="Bolu"},
            new City() {CityName="Burdur"},
            new City() {CityName="Bursa"},
            new City() {CityName="Çanakkale"},
            new City() {CityName="Çankırı"},
        };

        private static Route[] Routes =
        {
            new Route() { RouteStart="Adana", RouteFirstTransfer="Ağrı", RouteSecondTransfer="Çankırı", RouteThirdTransfer="Bolu", RouteFourthTransfer="Aydın", RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=13.00, RoutePrice=100},
            new Route() { RouteStart="ağrı", RouteFirstTransfer="Aydın", RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=14.00, RoutePrice=200},
            new Route() { RouteStart="Bingöl",  RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=15.00, RoutePrice=300},
            new Route() { RouteStart="Burdur", RouteFirstTransfer="Ağrı", RouteSecondTransfer="Çankırı", RouteThirdTransfer="Bolu", RouteFourthTransfer="Aydın", RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=16.00, RoutePrice=400},
            new Route() { RouteStart="Amasya", RouteFirstTransfer="Adana", RouteSecondTransfer="Çankırı",  RouteFinish="Bitlis", RouteDate="12.05.2022", RouteClock=17.00, RoutePrice=500},
            new Route() { RouteStart="Artvin", RouteFirstTransfer="Ağrı", RouteSecondTransfer="Çankırı", RouteThirdTransfer="Bursa", RouteFourthTransfer="Aydın", RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=18.00, RoutePrice=600},
            new Route() { RouteStart="Aydın", RouteFirstTransfer="Balıkesir", RouteSecondTransfer="Çankırı", RouteThirdTransfer="Bolu", RouteFourthTransfer="ağrı", RouteFinish="Çanakkale", RouteDate="12.05.2022", RouteClock=19.00, RoutePrice=700}
        };

        private static Ticket[] Tickets =
        {
            new Ticket() {TicketName="Ahmet", TicketSurname="Mağara", TicketFromWhere="Adana", TicketToWhere="Bolu", TicketDate="12.05.2022", TicketPrice=300, TicketSeatNo=01},
            new Ticket() {TicketName="Azer", TicketSurname="Bülbül", TicketFromWhere="Çankırı", TicketToWhere="Aydın", TicketDate="12.05.2022", TicketPrice=400, TicketSeatNo=02},
            new Ticket() {TicketName="Eda", TicketSurname="Kaya", TicketFromWhere="Balıkesir", TicketToWhere="Bolu", TicketDate="12.05.2022", TicketPrice=500, TicketSeatNo=03},
            new Ticket() {TicketName="Sena", TicketSurname="Kaş", TicketFromWhere="Aydın", TicketToWhere="Çanakkale", TicketDate="12.05.2022", TicketPrice=100, TicketSeatNo=04},
            new Ticket() {TicketName="Süleyman", TicketSurname="Sayan", TicketFromWhere="Balıkesir", TicketToWhere="Çankırı", TicketDate="12.05.2022", TicketPrice=200, TicketSeatNo=05},
            new Ticket() {TicketName="Tarık", TicketSurname="Kapı", TicketFromWhere="Balıkesir", TicketToWhere="Ağrı", TicketDate="12.05.2022", TicketPrice=250, TicketSeatNo=06}
        };
    }
}
            