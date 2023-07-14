using EveryDose.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryDose.Helper
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Profile>();
        }

        // Fetching data from database

        public Task<List<Profile>> GetProfileAsync()
        {
            return _database.Table<Profile>().ToListAsync();
        }

        // Inserting New Profile
        public Task<int> SaveProfileAsync(Profile profile)
        {
            return _database.InsertAsync(profile);
        }

        // Updating the existing profile
        public Task<int> UpdateProfileAsync(Profile profile)
        {
            return _database.UpdateAsync(profile);
        }
    }
}
