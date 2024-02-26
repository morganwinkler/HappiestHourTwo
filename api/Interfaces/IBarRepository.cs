using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bar;
using api.Models;

namespace api.Interfaces
{
  public interface IBarRepository
  {
    // GET ALL
    Task<List<Bar>> GetAllAsync();

    // GET BY ID
    Task<Bar?> GetByIdAsync(int id);

    // CREATE
    Task<Bar> CreateAsync(Bar barModel);

    // UPDATE
    Task<Bar?> UpdateAsync(int id, UpdateBarRequestDto barDto);

    // DELETE
    Task<Bar?> DeleteAsync(int id);
  }
}