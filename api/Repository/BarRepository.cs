using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bar;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class BarRepository : IBarRepository
  {
    private readonly ApplicationDbContext _context;
    public BarRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET ALL
    public async Task<List<Bar>> GetAllAsync()
    {
      return await _context.Bars.ToListAsync();
    }

    // GET BY ID
    public async Task<Bar?> GetByIdAsync(int id)
    {
      return await _context.Bars.FindAsync(id);
    }

    // CREATE
    public async Task<Bar> CreateAsync(Bar barModel)
    {
      await _context.Bars.AddAsync(barModel);
      await _context.SaveChangesAsync();
      return barModel;

    }

    // UPDATE
    public async Task<Bar?> UpdateAsync(int id, UpdateBarRequestDto barDto)
    {
      var existingBar = await _context.Bars.FirstOrDefaultAsync(b => b.Id == id);

      if (existingBar == null)
      {
        return null;
      }

      existingBar.Name = barDto.Name;
      existingBar.Address = barDto.Address;
      existingBar.City = barDto.City;
      existingBar.State = barDto.State;
      existingBar.Zip = barDto.Zip;
      existingBar.Hours = barDto.Hours;
      existingBar.Image = barDto.Image;
      existingBar.Latitude = barDto.Latitude;
      existingBar.Longitude = barDto.Longitude;

      await _context.SaveChangesAsync();

      return existingBar;
    }

    // DELETE
    public async Task<Bar?> DeleteAsync(int id)
    {
      var barModel = await _context.Bars.FirstOrDefaultAsync(b => b.Id == id);

      if (barModel == null)
      {

        return null;

      }

      _context.Bars.Remove(barModel);
      await _context.SaveChangesAsync();
      return barModel;
    }
  }
}