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
    public class AutoresService: IAutoresService
    {
        private string table = "Autores";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AutoresService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<AutoresDto>> Add(AutoresDto request)
        {

            Autores oAutores = await _unitOfWork.AutoresRepository.GetById(request.Id);

            if (oAutores == null)
            {
                var autor = _mapper.Map<Autores>(request);

                await _unitOfWork.AutoresRepository.Add(autor);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<AutoresDto>(autor);

                return new ApiResponse<AutoresDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<AutoresDto>()
                {
                    Message = "name "+table+ " already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Autores oAutores = await _unitOfWork.AutoresRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<AutoresDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.AutoresRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<AutoresDto>> Get(int id)
        {
            Autores oAutores = await _unitOfWork.AutoresRepository.GetById(id);
            var mapper = _mapper.Map<AutoresDto>(oAutores);

            return new ApiResponse<AutoresDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Autores Id already exist",
            };
        }
        public async Task<ApiResponse<AutoresDto>> Update(AutoresDto request)
        {
            var autor = _mapper.Map<Autores>(request);

            if (autor != null)
            {

                _unitOfWork.AutoresRepository.UpdateProperties(autor, p => p.Id!);
            }
            else
            {
                _unitOfWork.AutoresRepository.UpdateProperties(autor, p => p.Id!);
            }

            await _unitOfWork.SaveChangesAsync();

            var mapper = _mapper.Map<AutoresDto>(autor);

            return new ApiResponse<AutoresDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }

    }
}
