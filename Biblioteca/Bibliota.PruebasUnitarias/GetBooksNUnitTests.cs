using AutoMapper;
using Biblioteca.Commons.RequestFilter;
using Biblioteca.Commons.Response;
using Biblioteca.Controllers;
using Biblioteca.Core.DTOs.Request;
using Biblioteca.Core.Interfaces.Repositories;
using Biblioteca.Core.Interfaces.Services;
using Biblioteca.Core.Services.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Bibliota.PruebasUnitarias
{
    public class GetBooksNUnitTests
    {
        private readonly librosController _controller;
       
        public GetBooksNUnitTests(librosController controller)
        {
            _controller = controller;
        }
        [Fact]
        public void Get_Ok()
        {
            QueryFilter filter = new QueryFilter();
            filter.page = 0;
            var result = _controller.Get(filter);
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void Get_Quantity()
        {
            QueryFilter filter = new QueryFilter();
            filter.page = 0;
            var result = _controller.Get(filter);
            var books = Assert.IsType<RecordsResponse<LibrosDto>>(result);
            Assert.True(books.Total > 0);
        }
        [Fact]
        public void GetById_NotFound()
        {
            long id = 1;
            var result = (OkObjectResult)_controller.Get(id).Result;
            var books = Assert.IsType<RecordsResponse<LibrosDto>>(result);
        }
    }
}