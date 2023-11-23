﻿using SQLite;
using ProteinePlusApp.MVVM.Views;
namespace ProteinePlusApp
{
    public class LocalDbService
    {
        private const string DB_NAME = "proteinedata_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Exercise>();
        }

        public async Task<List<Exercise>> GetExercises()
        {
            return await _connection.Table<Exercise>().ToListAsync();
        }

        public async Task<Exercise> GetById(int id)
        {
            return await _connection.Table<Exercise>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Exercise exercise)
        {
            await _connection.InsertAsync(exercise);
        }

        public async Task Update(Exercise exercise)
        {
            await _connection.UpdateAsync(exercise);
        }

        public async Task Delete(Exercise exercise)
        {
            await _connection.DeleteAsync(exercise);
        }

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
    }
}