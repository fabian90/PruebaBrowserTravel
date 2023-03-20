using AutoMapper;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Autores
            CreateMap<Autores, AutoresDto>();
            CreateMap<AutoresDto, Autores>();
            #endregion
            #region AutoresHasLibro
            CreateMap<AutoresHasLibro, AutoresHasLibroDto>();
            CreateMap<AutoresHasLibroDto, AutoresHasLibro>();
            #endregion
            #region Editoriales
            CreateMap<Editoriales, EditorialesDto>();
            CreateMap<EditorialesDto, Editoriales>();
            #endregion
            #region Libros
            CreateMap<Libros, LibrosDto>();
            CreateMap<LibrosDto, Libros>();
            #endregion
        }
    }
}