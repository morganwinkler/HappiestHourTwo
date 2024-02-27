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
        Longitude = barModel.Longitude,
        Specials = barModel.Specials.Select(s => s.ToSpecialDto()).ToList()
      };
    }

    public static Bar ToBarFromCreateDto(this CreateBarRequestDto barDto)
    {
      return new Bar
      {
        Name = barDto.Name,
        Address = barDto.Address,
        City = barDto.City,
        State = barDto.State,
        Zip = barDto.Zip,
        Hours = barDto.Hours,
        Image = barDto.Image,
        Latitude = barDto.Latitude,
        Longitude = barDto.Longitude
      };
    }
  }
}