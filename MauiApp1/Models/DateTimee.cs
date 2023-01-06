using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MauiApp1.Models
{
    public class DateTimee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [OneToMany]
        public List<ListDateAndTime> ListDateAndTime { get; set; }
    }

}
