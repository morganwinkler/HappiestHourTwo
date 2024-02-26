using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bar;
using api.Interfaces;
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
    private readonly IBarRepository _barRepo;
    public BarController(ApplicationDbContext context, IBarRepository barRepo)
    {
      _barRepo = barRepo;
      _context = context;

    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var bars = await _barRepo.GetAllAsync();

      var barDto = bars.Select(b => b.ToBarDto());

      return Ok(bars);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var bar = await _barRepo.GetByIdAsync(id);

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
      await _barRepo.CreateAsync(barModel);
      return CreatedAtAction(nameof(GetById), new { id = barModel.Id }, barModel.ToBarDto());
    }

    // UPDATE
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBarRequestDto updateDto)
    {
      var barModel = await _barRepo.UpdateAsync(id, updateDto);

      if (barModel == null)
      {
        return NotFound();
      }

      return Ok(barModel.ToBarDto());
    }

    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

      var barModel = await _barRepo.DeleteAsync(id);

      if (barModel == null)
      {

        return NotFound();

      }

      return NoContent();
    }
  }
}