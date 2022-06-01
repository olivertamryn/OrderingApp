using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetSwagOrderingApp
{
    public class OrdersDatabase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<OrdersDatabase> Instance = new AsyncLazy<OrdersDatabase>(async () =>
        {
            var instance = new OrdersDatabase();
            CreateTableResult result = await Database.CreateTableAsync<NetSwag>();
            return instance;
        });
        public OrdersDatabase()
        {
            Database = new SQLiteAsyncConnection(Constantcs.DatabasePath, Constantcs.Flags);
        }
        public Task<List<NetSwag>> GetItemsAsync()
        {
            return Database.Table<NetSwag>().ToListAsync();
        }
        public Task<List<NetSwag>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<NetSwag>("SELECT * FROM [NetSwag]");
        }
        public Task<NetSwag> GetItemAsync(int id)
        {
            return Database.Table<NetSwag>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(NetSwag item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(NetSwag item)
        {
            return Database.DeleteAsync(item);
        }










    }
}
