using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace MauiApp1.Models
{
    public class ListRoute
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Reservation))]
        public int ReservationID { get; set; }
        public int RouteID { get; set; }
    }
}
