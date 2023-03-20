using Biblioteca.Commons.Mapper;
using Biblioteca.Commons.Paging;
using Biblioteca.Commons.Repository.Repository;
using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Entity;
using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Infrastructure.Data.Context;


namespace Biblioteca.Infrastructure.Repositories
{
    public class LibrosRepository : GenericRepository<Libros, BibliotecaContext>, ILibrosRepository
    {
        protected readonly BibliotecaContext _context;
        public LibrosRepository(BibliotecaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RecordsResponse<LibrosDto>> Get(QueryFilter filter)
        {
            var LibrosDto = new LibrosDto();
            try
            {

                var response = await _context.Libros.OrderBy(x => x.Isbn).Where(x => x.Isbn != 0).GetPagedAsync(filter.page, filter.take);
                return response.MapTo<RecordsResponse<LibrosDto>>()!;

            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
