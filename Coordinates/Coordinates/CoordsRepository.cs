using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace Coordinates
{
    public class CoordsRepository
    {
        SQLiteConnection database;
        public CoordsRepository(string databasePath)
        {
            //string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Coords>();
        }
        public IEnumerable<Coords> GetItems()
        {
            return (from i in database.Table<Coords>() select i).ToList();

        }
        public Coords GetItem(int id)
        {
            return database.Get<Coords>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Coords>(id);
        }
        public int SaveItem(Coords item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}

