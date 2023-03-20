using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces.Services
{
    public interface IAutoresHasLibroService
    {
        Task<ApiResponse<AutoresHasLibroDto>> Add(AutoresHasLibroDto request);
        Task<ApiResponse<AutoresHasLibroDto>> Update(AutoresHasLibroDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<AutoresHasLibroDto>> Get(QueryFilter filter);
        Task<ApiResponse<AutoresHasLibroDto>> Get(int id);
    }
}
