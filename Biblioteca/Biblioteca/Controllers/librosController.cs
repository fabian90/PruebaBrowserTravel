﻿using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class librosController : ControllerBase
    {
        private readonly ILibrosService _libroService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<LibrosDto> _validator;
        public librosController(ILibrosService libroService, IValidator<LibrosDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _libroService = libroService;
        }
        // GET: api/<libroController>
        [HttpGet]
        public async Task<RecordsResponse<LibrosDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _libroService.Get(filter);
            return response;
        }

        // GET api/<libroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _libroService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<libroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibrosDto request)
        {
            var response = await _libroService.Add(request);

            return Ok(response);
        }

        // PUT api/<libroController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] LibrosDto request)
        {
            var validation = await _validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Code = e.ErrorCode,
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }));
            }

            var response = await _libroService.Update(request);

            return Ok(response);
        }

        // DELETE api/<libroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _libroService.Delete(id);
            return Ok(response);
        }
    }
}
