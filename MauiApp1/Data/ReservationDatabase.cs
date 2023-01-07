using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiApp1.Models;
using Microsoft.VisualBasic;
using System.Collections;

namespace MauiApp1.Data
{
    public class ReservationDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReservationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reservation>().Wait();
           
        }
       
       
        public Task<List<Reservation>> GetReservationAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }
        public Task<int> SaveReservationAsync(Reservation slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteReservationAsync(Reservation slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}