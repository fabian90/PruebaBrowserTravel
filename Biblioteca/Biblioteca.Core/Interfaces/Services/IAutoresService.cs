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
    public interface IAutoresService
    {
        Task<ApiResponse<AutoresDto>> Add(AutoresDto request);
        Task<ApiResponse<AutoresDto>> Update(AutoresDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<AutoresDto>> Get(QueryFilter filter);
        Task<ApiResponse<AutoresDto>> Get(int id);
    }
}
