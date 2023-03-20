using AutoMapper;
using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Entity;
using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Services.Implementation
{
    public class LibrosService: ILibrosService
    {
        private string table = "Libros";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LibrosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<LibrosDto>> Add(LibrosDto request)
        {

            Libros oLibros = await _unitOfWork.LibrosRepository.GetById(request.Isbn);

            if (oLibros == null)
            {
                var libro = _mapper.Map<Libros>(request);

                await _unitOfWork.LibrosRepository.Add(libro);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<LibrosDto>(libro);

                return new ApiResponse<LibrosDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<LibrosDto>()
                {
                    Message = table+" name already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(long id)
        {
            Libros oLibros = await _unitOfWork.LibrosRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<LibrosDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.LibrosRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<LibrosDto>> Get(long id)
        {
            Libros oLibros = await _unitOfWork.LibrosRepository.GetById(id);
            var mapper = _mapper.Map<LibrosDto>(oLibros);

            return new ApiResponse<LibrosDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Libros Id already exist",
            };
        }
        public async Task<ApiResponse<LibrosDto>> Update(LibrosDto request)
        {
            var libro = _mapper.Map<Libros>(request);

            if (libro != null)
            {

                _unitOfWork.LibrosRepository.UpdateProperties(libro, p => p.Isbn!);
            }
            else
            {
                _unitOfWork.LibrosRepository.UpdateProperties(libro, p => p.Isbn!);
            }

            await _unitOfWork.SaveChangesAsync();

            var mapper = _mapper.Map<LibrosDto>(libro);

            return new ApiResponse<LibrosDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
