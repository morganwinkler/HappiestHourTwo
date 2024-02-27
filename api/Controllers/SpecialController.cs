using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public SpecialController(ISpecialRepository specialRepo)
    {
      _specialRepo = specialRepo;
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
  }
}