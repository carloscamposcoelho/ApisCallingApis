using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApisCallingApis.Models;

namespace ApisCallingApis.Data
{
    public interface IComandosRepo
    {
        Task<IEnumerable<Comando>> GetAllAsync();
        Task<Comando> GetByIdAsync(int id);
        Task<Comando> CreateAsync(Comando cmd);
        Task UpdateAsync(Comando cmd);
        Task DeleteAsync(int id);
    }
}
