using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bar;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/bar")]
  [ApiController]
  public class BarController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    public BarController(ApplicationDbContext context)
    {

      _context = context;

    }
    // GET ALL

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var bars = await _context.Bars.ToListAsync();

      var barDto = bars.Select(b => b.ToBarDto());

      return Ok(bars);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var bar = await _context.Bars.FindAsync(id);

      if (bar == null)
      {
        return NotFound();
      }

      return Ok(bar.ToBarDto());
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBarRequestDto barDto)
    {
      var barModel = barDto.ToBarFromCreateDto();
      await _context.Bars.AddAsync(barModel);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = barModel.Id }, barModel.ToBarDto());
    }

    // UPDATE
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBarRequestDto updateDto)
    {
      var barModel = await _context.Bars.FirstOrDefaultAsync(b => b.Id == id);

      if (barModel == null)
      {
        return NotFound();
      }

      barModel.Name = updateDto.Name;
      barModel.Address = updateDto.Address;
      barModel.City = updateDto.City;
      barModel.State = updateDto.State;
      barModel.Zip = updateDto.Zip;
      barModel.Hours = updateDto.Hours;
      barModel.Image = updateDto.Image;
      barModel.Latitude = updateDto.Latitude;
      barModel.Longitude = updateDto.Longitude;

      await _context.SaveChangesAsync();

      return Ok(barModel.ToBarDto());
    }

    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

      var barModel = await _context.Bars.FirstOrDefaultAsync(b => b.Id == id);

      if (barModel == null)
      {

        return NotFound();

      }

      _context.Bars.Remove(barModel);

      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}