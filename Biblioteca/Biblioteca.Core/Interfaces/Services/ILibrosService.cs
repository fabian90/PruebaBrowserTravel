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
    public interface ILibrosService
    {
        Task<ApiResponse<LibrosDto>> Add(LibrosDto request);
        Task<ApiResponse<LibrosDto>> Update(LibrosDto request);
        Task<ApiResponse<object>> Delete(long id);
        Task<RecordsResponse<LibrosDto>> Get(QueryFilter filter);
        Task<ApiResponse<LibrosDto>> Get(long id);
    }
}
