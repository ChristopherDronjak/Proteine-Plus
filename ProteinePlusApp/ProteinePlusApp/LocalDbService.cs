using SQLite;
using ProteinePlusApp.MVVM.Views;
using ProteinePlusApp.MVVM.Models;

namespace ProteinePlusApp
{
    public class LocalDbService
    {
        private const string DB_NAME = "proteinedata_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        //creating table 
        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Exercise>();
            _connection.CreateTableAsync<Tracker>();

        }

        //ensuring table exists for exercise and food intake
        public async Task<List<Exercise>> GetExercises()
        {
            return await _connection.Table<Exercise>().ToListAsync();
        }

        public async Task<List<Tracker>> GetTrackers()
        {
            return await _connection.Table<Tracker>().ToListAsync();
        }


        //gathering ID for food intake and exercises
        public async Task<Exercise> GetById(int id)
        {
            return await _connection.Table<Exercise>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tracker> GetByTrackerId(int trackid)
        {
            return await _connection.Table<Tracker>().Where(x => x.TrackId == trackid).FirstOrDefaultAsync();
        }

        //insertion function for exercise and food intake into the database
        public async Task Create(Exercise exercise)
        {
            await _connection.InsertAsync(exercise);
        }

        public async Task Create(Tracker tracker)
        {
            await _connection.InsertAsync(tracker);
        }


        //updating data in the database for the exercises and food intake
        public async Task Update(Exercise exercise)
        {
            await _connection.UpdateAsync(exercise);
        }

        public async Task Update(Tracker tracker)
        {
            await _connection.UpdateAsync(tracker);
        }


        //deleting data from the database for exercises and food intake
        public async Task Delete(Exercise exercise)
        {
            await _connection.DeleteAsync(exercise);
        }

        public async Task Delete(Tracker tracker)
        {
            await _connection.DeleteAsync(tracker);
        }



        //saving new data into the database for exercises
        public async Task<int> SaveCategoryAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
            {
                return await _connection.UpdateAsync(exercise);
            }
            else
            {
                return await _connection.InsertAsync(exercise);
            }
        }

        //saving new data into the database for food intake
        public async Task<int> SaveCategoryAsync(Tracker tracker)
        {
            if (tracker.TrackId != 0)
            {
                return await _connection.UpdateAsync(tracker);
            }
            else
            {
                return await _connection.InsertAsync(tracker);
            }
        }
    }
}