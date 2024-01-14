using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaFitness.Models;
using SalaFitness.Data;

namespace SalaFitness.Data
{
    public class FitnessDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FitnessDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Abonament>().Wait();
            _database.CreateTableAsync<Antrenor>().Wait();
            _database.CreateTableAsync<DetaliiAbonament>().Wait();
        }

        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Abonament>().ConfigureAwait(false);
            await _database.CreateTableAsync<Antrenor>().ConfigureAwait(false);
            await _database.CreateTableAsync<DetaliiAbonament>().ConfigureAwait(false);
        }

        public Task<List<Abonament>> GetAbonamenteAsync()
        {
            return _database.Table<Abonament>().ToListAsync();
        }

        public Task<int> SaveAbonamentAsync(Abonament abonament)
        {
            if (abonament.ID != 0)
            {
                return _database.UpdateAsync(abonament);
            }
            else
            {
                return _database.InsertAsync(abonament);
            }
        }

        public Task<int> DeleteAbonamentAsync(Abonament abonament)
        {
            return _database.DeleteAsync(abonament);
        }

        public Task<int> SaveAntrenorAsync(Antrenor antrenor)
        {
            if (antrenor.ID != 0)
            {
                return _database.UpdateAsync(antrenor);
            }
            else
            {
                return _database.InsertAsync(antrenor);
            }
        }

        public Task<int> DeleteAntrenorAsync(Antrenor antrenor)
        {
            return _database.DeleteAsync(antrenor);
        }

        public Task<List<Antrenor>> GetAntrenoriAsync()
        {
            return _database.Table<Antrenor>().ToListAsync();
        }
        public Task<int> SaveDetaliiAbonamentAsync(DetaliiAbonament detaliiAbonament)
        {
            if (detaliiAbonament.ID != 0)
            {
                return _database.UpdateAsync(detaliiAbonament);
            }
            else
            {
                return _database.InsertAsync(detaliiAbonament);
            }
        }

        public Task<int> DeleteDetaliiAbonamentAsync(DetaliiAbonament detaliiAbonament)
        {
            return _database.DeleteAsync(detaliiAbonament);
        }

        public Task<List<DetaliiAbonament>> GetDetaliiAbonamenteAsync()
        {
            return _database.Table<DetaliiAbonament>().ToListAsync();
        }
    }
}
