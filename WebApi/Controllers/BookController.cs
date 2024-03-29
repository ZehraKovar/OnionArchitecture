﻿using Application.Features.Mediator.Book.AddBook;
using Application.Features.Mediator.Book.GetBooks;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetBooksQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookCommand command)
        {
            var validator = new BookValidator();
            var validatorResult=validator.Validate(command);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }
            await _mediator.Send(command);
            return Ok("");
        }
    }
}
