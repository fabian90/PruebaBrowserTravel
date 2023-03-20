using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Commons.RequestFilter
{
    public class QueryFilter
    {
        public int page { get; set; }
        public int take { get; set; } = 10;
        public string? ids { get; set; } = null;
        public string? filter { get; set; } = null;
        public DateTime? filterDateTime { get; set; }
        public string? type { get; set; } = null;
    }
}
