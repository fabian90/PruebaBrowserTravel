using Biblioteca.Commons.Mapper;
using Biblioteca.Commons.Paging;
using Biblioteca.Commons.Repository.Repository;
using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Entity;
using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class EditorialesRepository : GenericRepository<Editoriales, BibliotecaContext>, IEditorialesRepository
    {
        protected readonly BibliotecaContext _context;
        public EditorialesRepository(BibliotecaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<EditorialesDto>> Get(QueryFilter filter)
        {
            var EditorialesDto = new EditorialesDto();
            try
            {

                var response = await _context.Editoriales.OrderBy(x => x.Id).Where(x => x.Id != 0).GetPagedAsync(filter.page, filter.take);
                return response.MapTo<RecordsResponse<EditorialesDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
