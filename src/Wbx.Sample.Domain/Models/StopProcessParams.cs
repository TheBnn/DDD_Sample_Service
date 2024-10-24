using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wbx.Sample.Domain.Models
{
    public class StopProcessParams
    {
        public bool Now { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan AfterInterval { get; set; }
    }
}
