using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BaseCommandResponseAcccount
    {
      public Guid Id { get; set; }
      public bool Success { get; set; } = true;
      public string Token { get; set; }
      public string Message { get; set; }
      public List<string> Errors { get; set; }
      public string Status { get; set; }
        
    }
}
