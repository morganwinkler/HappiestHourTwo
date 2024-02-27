using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
  public interface ISpecialRepository
  {
    // GET ALL
    Task<List<Special>> GetAllAsync();

    // GET BY ID
    Task<Special?> GetByIdAsync(int id);
  }
}