using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Special
  {
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? BarId { get; set; }
    public Bar? Bar { get; set; }
  }
}