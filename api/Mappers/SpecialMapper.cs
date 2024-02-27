using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Special;
using api.Models;

namespace api.Mappers
{
  public static class SpecialMapper
  {
    public static SpecialDto ToSpecialDto(this Special specialModel)
    {
      return new SpecialDto
      {
        Id = specialModel.Id,
        Content = specialModel.Content,
        BarId = specialModel.BarId
      };
    }
  }
}