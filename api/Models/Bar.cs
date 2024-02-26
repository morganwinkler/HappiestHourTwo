using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Bar
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string Hours { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,6)")]
    public decimal Latitude { get; set; }
    [Column(TypeName = "decimal(10,6)")]
    public decimal Longitude { get; set; }

  }
}