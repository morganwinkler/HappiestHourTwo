using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Special;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/special")]
  [ApiController]
  public class SpecialController : ControllerBase
  {
    private readonly ISpecialRepository _specialRepo;
    private readonly IBarRepository _barRepo;
    public SpecialController(ISpecialRepository specialRepo, IBarRepository barRepo)
    {
      _specialRepo = specialRepo;
      _barRepo = barRepo;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

      var specials = await _specialRepo.GetAllAsync();

      var specialDto = specials.Select(s => s.ToSpecialDto());

      return Ok(specialDto);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {

      var special = await _specialRepo.GetByIdAsync(id);

      if (special == null)
      {

        return NotFound();

      }

      return Ok(special.ToSpecialDto());

    }

    // CREATE
    [HttpPost("{barId}")]
    public async Task<IActionResult> Create([FromRoute] int barId, CreateSpecialDto specialDto)
    {
      if (!await _barRepo.BarExists(barId))
      {
        return BadRequest("Bar does not exist");
      }

      var specialModel = specialDto.ToSpecialFromCreate(barId);
      await _specialRepo.CreateAsync(specialModel);
      return CreatedAtAction(nameof(GetById), new { id = specialModel }, specialModel.ToSpecialDto());
    }
  }
}