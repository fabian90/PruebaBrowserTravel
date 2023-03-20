using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BibliotecaContext _context;

        private readonly ILibrosRepository _librosRepository;

        private readonly IEditorialesRepository _editorialesRepository;

        private readonly IAutoresHasLibroRepository _autoresHasLibroRepository;

        private readonly IAutoresRepository _autoresRepository;

        public UnitOfWork(BibliotecaContext context)
        {
            _context= context;
        }

        public IAutoresRepository AutoresRepository => _autoresRepository ?? new AutoresRepository(_context);

        public IEditorialesRepository EditorialesRepository => _editorialesRepository ?? new EditorialesRepository(_context);

        public ILibrosRepository LibrosRepository => _librosRepository ?? new LibrosRepository(_context);
        public IAutoresHasLibroRepository AutoresHasLibroRepository => _autoresHasLibroRepository ?? new AutoresHasLibroRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
