using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAutoresHasLibroRepository AutoresHasLibroRepository { get; }
        IAutoresRepository AutoresRepository { get; }
        IEditorialesRepository EditorialesRepository { get; }
        ILibrosRepository LibrosRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
