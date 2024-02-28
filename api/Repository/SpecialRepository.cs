using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class SpecialRepository : ISpecialRepository
  {
    private readonly ApplicationDbContext _context;

    public SpecialRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET ALL
    public async Task<List<Special>> GetAllAsync()
    {
      return await _context.Specials.ToListAsync();
    }

    // GET BY ID
    public async Task<Special?> GetByIdAsync(int id)
    {
      return await _context.Specials.FindAsync(id);
    }

    // CREATE
    public async Task<Special> CreateAsync(Special specialModel)
    {
      await _context.Specials.AddAsync(specialModel);
      await _context.SaveChangesAsync();
      return specialModel;
    }
  }
}