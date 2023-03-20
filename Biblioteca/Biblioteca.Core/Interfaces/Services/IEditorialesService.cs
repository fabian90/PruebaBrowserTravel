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
    public interface IEditorialesService
    {
        Task<ApiResponse<EditorialesDto>> Add(EditorialesDto request);
        Task<ApiResponse<EditorialesDto>> Update(EditorialesDto request);
        Task<ApiResponse<object>> Delete(int id);
        Task<RecordsResponse<EditorialesDto>> Get(QueryFilter filter);
        Task<ApiResponse<EditorialesDto>> Get(int id);
    }
}
