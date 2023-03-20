using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Commons.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Detail { get; set; } = string.Empty;

        public RecordsResponse<T>? Records { get; set; }

    }
}
