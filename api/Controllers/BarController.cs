using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Bar;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
      var bars = _context.Bars.ToList()
      .Select(b => b.ToBarDto());

      return Ok(bars);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var bar = _context.Bars.Find(id);

      if (bar == null)
      {
        return NotFound();
      }

      return Ok(bar.ToBarDto());
    }

    // CREATE
    [HttpPost]
    public IActionResult Create([FromBody] CreateBarRequestDto barDto)
    {
      var barModel = barDto.ToBarFromCreateDto();
      _context.Bars.Add(barModel);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = barModel.Id }, barModel.ToBarDto());
    }
  }
}