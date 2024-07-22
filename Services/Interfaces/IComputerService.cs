using System.Collections.Generic;
using System.Threading.Tasks;
using thesis_exercise.Models;

namespace thesis_exercise.Services.Interfaces
{
    public interface IComputerService
    {
        Task<IEnumerable<Computer>> GetAllComputersAsync();
        Task SaveComputerAsync(Computer computer);
        Task<Computer> GetComputerAsync(int id);
        Task UpdateComputerAsync(Computer computer);
    }
}
