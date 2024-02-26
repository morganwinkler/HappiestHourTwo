using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Bar;
using api.Models;

namespace api.Mappers
{
  public static class BarMappers
  {
    public static BarDto ToBarDto(this Bar barModel)
    {
      return new BarDto
      {
        Id = barModel.Id,
        Name = barModel.Name,
        Address = barModel.Address,
        City = barModel.City,
        State = barModel.State,
        Zip = barModel.Zip,
        Hours = barModel.Hours,
        Image = barModel.Image,
        Latitude = barModel.Latitude,
        Longitude = barModel.Longitude
      };
    }
  }
}