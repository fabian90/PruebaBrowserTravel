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
    public class AutoresRepository : GenericRepository<Autores, BibliotecaContext>,IAutoresRepository
    {
        protected readonly BibliotecaContext _context;
        public AutoresRepository(BibliotecaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<AutoresDto>> Get(QueryFilter filter)
        {
            var AutoresDto = new AutoresDto();
            try
            {

                var response = await _context.Autores.OrderBy(x => x.Id).Where(x => x.Id != 0).GetPagedAsync(filter.page, filter.take);
                return response.MapTo<RecordsResponse<AutoresDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
