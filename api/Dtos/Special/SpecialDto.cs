using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Special
{
  public class SpecialDto
  {
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? BarId { get; set; }
  }
}