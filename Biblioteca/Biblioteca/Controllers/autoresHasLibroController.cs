using Biblioteca.Commons.RequestFilter;
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
    public class autoresHasLibrosController : ControllerBase
    {
        private readonly IAutoresHasLibroService _autoresHasLibroService;
        private readonly IValidator<AutoresHasLibroDto> _validator;
        public autoresHasLibrosController(IAutoresHasLibroService autoresHasLibroService, IValidator<AutoresHasLibroDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _autoresHasLibroService = autoresHasLibroService;
        }
        // GET: api/<autoresHasLibroController>
        [HttpGet]
        public async Task<RecordsResponse<AutoresHasLibroDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _autoresHasLibroService.Get(filter);
            return response;
        }

        // GET api/<autoresHasLibroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _autoresHasLibroService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<autoresHasLibroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AutoresHasLibroDto request)
        {
            var response = await _autoresHasLibroService.Add(request);

            return Ok(response);
        }

        // PUT api/<autoresHasLibroController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AutoresHasLibroDto request)
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

            var response = await _autoresHasLibroService.Update(request);

            return Ok(response);
        }

        // DELETE api/<autoresHasLibroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _autoresHasLibroService.Delete(id);
            return Ok(response);
        }
    }
}
