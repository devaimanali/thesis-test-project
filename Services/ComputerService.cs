using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thesis_exercise.Models;
using thesis_exercise.Services.Interfaces;

namespace thesis_exercise.Repositories
{
    public class ComputerService : IComputerService
    {
        private readonly AppDbContext _appDbContext;

        public ComputerService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Computer>> GetAllComputersAsync()
        {
            try
            {
                return await _appDbContext.Set<Computer>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error fetching computers", e);
            }
        }

        public async Task SaveComputerAsync(Computer computer)
        {
            try
            {
                _appDbContext.Entry(computer).State = EntityState.Added;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error saving computer", e);
            }
        }

        public async Task<Computer> GetComputerAsync(int id)
        {
            try
            {
                return await _appDbContext.Computers.SingleOrDefaultAsync(s => s.ComputerID == id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error fetching computer with ID {id}", e);
            }
        }

        public async Task UpdateComputerAsync(Computer computer)
        {
            try
            {
                var data = await GetComputerAsync(computer.ComputerID);
                if (data != null)
                {
                    data.RAM = computer.RAM;
                    data.DiskSpace = computer.DiskSpace;
                    data.Ports = computer.Ports;
                    data.Processor = computer.Processor;
                    _appDbContext.Entry(data).State = EntityState.Modified;
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Computer not found");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating computer", e);
            }
        }
    }
}
