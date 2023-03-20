using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Commons.Response
{
    public class ValidationResult
    {
        public string Code { get; set; }
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
