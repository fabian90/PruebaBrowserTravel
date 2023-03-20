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
    public class AutoresHasLibroService : IAutoresHasLibroService
    {
        private string table = "AutoresHasLibro";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AutoresHasLibroService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<AutoresHasLibroDto>> Add(AutoresHasLibroDto request)
        {

            AutoresHasLibro oAutoresHasLibro = await _unitOfWork.AutoresHasLibroRepository.GetById(request.Id);

            if (oAutoresHasLibro == null)
            {
                var autoresHasLibro = _mapper.Map<AutoresHasLibro>(request);

                await _unitOfWork.AutoresHasLibroRepository.Add(autoresHasLibro);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<AutoresHasLibroDto>(autoresHasLibro);

                return new ApiResponse<AutoresHasLibroDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<AutoresHasLibroDto>()
                {
                    Message = "name " + table + " already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            AutoresHasLibro oAutoresHasLibro = await _unitOfWork.AutoresHasLibroRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<AutoresHasLibroDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.AutoresHasLibroRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<AutoresHasLibroDto>> Get(int id)
        {
            AutoresHasLibro oAutoresHasLibro = await _unitOfWork.AutoresHasLibroRepository.GetById(id);
            var mapper = _mapper.Map<AutoresHasLibroDto>(oAutoresHasLibro);

            return new ApiResponse<AutoresHasLibroDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " AutoresHasLibro Id already exist",
            };
        }
        public async Task<ApiResponse<AutoresHasLibroDto>> Update(AutoresHasLibroDto request)
        {
            var autoresHasLibro = _mapper.Map<AutoresHasLibro>(request);

            if (autoresHasLibro != null)
            {

                _unitOfWork.AutoresHasLibroRepository.UpdateProperties(autoresHasLibro, p => p.Id!);
            }
            else
            {
                _unitOfWork.AutoresHasLibroRepository.UpdateProperties(autoresHasLibro, p => p.Id!);
            }

            await _unitOfWork.SaveChangesAsync();

            var mapper = _mapper.Map<AutoresHasLibroDto>(autoresHasLibro);

            return new ApiResponse<AutoresHasLibroDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
