using Biblioteca.Commons.Repository.Interfaces;
using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces.Repositories
{
    public interface IEditorialesRepository:IGenericRepository<Editoriales>
    {
        Task<RecordsResponse<EditorialesDto>> Get(QueryFilter filter);
    }
}
