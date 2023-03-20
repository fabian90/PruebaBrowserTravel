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
    public class autoresController : ControllerBase
    {
        private readonly ILibrosService _autoreService;
        //private readonly IUConfiguracionService _ConfiguracionService;
        private readonly IValidator<LibrosDto> _validator;
        public autoresController(ILibrosService autoreService, IValidator<LibrosDto> validator)
        {
            //_ConfiguracionService = ConfiguracionService;
            _validator = validator;
            _autoreService = autoreService;
        }
        // GET: api/<autoreController>
        [HttpGet]
        public async Task<RecordsResponse<LibrosDto>> Get([FromQuery] QueryFilter filter)
        {
            var response = await _autoreService.Get(filter);
            return response;
        }

        // GET api/<autoreController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _autoreService.Get(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

        // POST api/<autoreController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibrosDto request)
        {
            var response = await _autoreService.Add(request);

            return Ok(response);
        }

        // PUT api/<autoreController>/5
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

            var response = await _autoreService.Update(request);

            return Ok(response);
        }

        // DELETE api/<autoreController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _autoreService.Delete(id);
            return Ok(response);
        }
    }
}
