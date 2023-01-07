using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Route
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RouteName { get; set; }
        public string Adress { get; set; }
        public string RouteDetails
        {
            get
            {
                return RouteName + " "+Adress;} }
        [OneToMany]
        public List<Reservation> Reservations { get; set; }

    }
}
