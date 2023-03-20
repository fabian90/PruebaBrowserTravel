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
    public class EditorialesService:IEditorialesService
    {
        private string table = "Editoriales";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditorialesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<EditorialesDto>> Add(EditorialesDto request)
        {

            Editoriales oEditoriales = await _unitOfWork.EditorialesRepository.GetById(request.Id);

            if (oEditoriales == null)
            {
                var editorial = _mapper.Map<Editoriales>(request);

                await _unitOfWork.EditorialesRepository.Add(editorial);
                await _unitOfWork.SaveChangesAsync();

                var mapper = _mapper.Map<EditorialesDto>(editorial);

                return new ApiResponse<EditorialesDto>()
                {
                    Data = mapper,
                    Success = true,
                    Message = "The " + table + " was created successfully",
                };
            }
            else
            {
                return new ApiResponse<EditorialesDto>()
                {
                    Message = "Editorialesname already exist",
                    Success = false
                };
            }
        }

        public async Task<ApiResponse<object>> Delete(int id)
        {
            Editoriales oEditoriales = await _unitOfWork.EditorialesRepository.GetById(id);

            _unitOfWork.SaveChanges();

            return new ApiResponse<object>()
            {
                Success = true,
                Message = table + " deleted successfully"
            };
        }

        public async Task<RecordsResponse<EditorialesDto>> Get(QueryFilter filter)
        {
            var response = await _unitOfWork.EditorialesRepository.Get(filter);
            return response;
        }

        public async Task<ApiResponse<EditorialesDto>> Get(int id)
        {
            Editoriales oEditoriales = await _unitOfWork.EditorialesRepository.GetById(id);
            var mapper = _mapper.Map<EditorialesDto>(oEditoriales);

            return new ApiResponse<EditorialesDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " Editoriales Id already exist",
            };
        }
        public async Task<ApiResponse<EditorialesDto>> Update(EditorialesDto request)
        {
            var editorial = _mapper.Map<Editoriales>(request);

            if (editorial != null)
            {

                _unitOfWork.EditorialesRepository.UpdateProperties(editorial, p => p.Id!);
            }
            else
            {
                _unitOfWork.EditorialesRepository.UpdateProperties(editorial, p => p.Id!);
            }

            await _unitOfWork.SaveChangesAsync();

            var mapper = _mapper.Map<EditorialesDto>(editorial);

            return new ApiResponse<EditorialesDto>()
            {
                Data = mapper,
                Success = true,
                Message = "The " + table + " was update successfully",
            };
        }
    }
}
