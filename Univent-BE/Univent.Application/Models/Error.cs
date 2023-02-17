using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univent.Application.Enums;

namespace Univent.Application.Models
{
    public class Error
    {
        public ErrorCodeEnum Code { get; set; }
        public string Message { get; set; }
    }
}
