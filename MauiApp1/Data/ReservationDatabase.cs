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
            _database.CreateTableAsync<Route>().Wait();
            _database.CreateTableAsync<ListRoute>().Wait();
            _database.CreateTableAsync<DateTimee>().Wait();
            _database.CreateTableAsync<ListDateAndTime>().Wait();
        }
        public Task<int> SaveRouteAsync(Route route)
        {
            if (route.ID != 0)
            {
                return _database.UpdateAsync(route);
            }
            else
            {
                return _database.InsertAsync(route);
            }
        }
        public Task<int> DeleteRouteAsync(Route route)
        {
            return _database.DeleteAsync(route);
        }
        public Task<List<Route>> GetRouteAsync()
        {
            return _database.Table<Route>().ToListAsync();
        }

        internal Task SaveReservationAsync(Reservation slist)
        {
            throw new NotImplementedException();
        }

        internal Task<IEnumerable> GetReservationsAsync()
        {
            throw new NotImplementedException();
        }

        internal Task DeleteReservationAsync(Reservation slist)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveDateAndTimeAsync(DateTimee DateAndTime)
        {
            if (DateAndTime.ID != 0)
            {
                return _database.UpdateAsync(DateAndTime);
            }
            else
            {
                return _database.InsertAsync(DateAndTime);
            }
        }
        public Task<int> DeleteDateAndTimeAsync(DateTimee DateAndTime)
        {
            return _database.DeleteAsync(DateAndTime);
        }
        public Task<List<DateTimee>> GetDateAndTimeAsync()
        {
            return _database.Table<DateTimee>().ToListAsync();
        }
        public Task<int> SaveListRouteAsync(ListRoute listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<int> SaveListDateAndTimeAsync(ListDateAndTime listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Route>> GetListRouteAsync(int shoplistid)
        {
            return _database.QueryAsync<Route>(
            "select P.ID, P.Description from Route P"
            + " inner join ListRoute LP"
            + " on P.ID = LP.ProductID where LP.ReservationID = ?",
            shoplistid);
        }

    }
}