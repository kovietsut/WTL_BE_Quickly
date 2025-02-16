using Application.Features.Users.Create;
using Application.Interfaces;
using Application.Models;
using Application.Utils;
using Domain.Configurations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Create
{
    public class CreateGenreCommand : IRequest<IActionResult>
    {
        public required string Name { get; set; }
    }

    public class CreateGenreCommmandHandler(IGenreRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<CreateGenreCommand, IActionResult>
    {
        private readonly ErrorCode _errorCodes = errorCodes.Value;

        public async Task<IActionResult> Handle(CreateGenreCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var createGenreDto = new CreateGenreDto
                {
                    Name = query.Name
                };
                var validator = new CreateGenreValidator();
                var check = await validator.ValidateAsync(createGenreDto, cancellationToken);
                if (!check.IsValid)
                {
                    return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                }

                var genre = await repository.CreateGenreAsync(createGenreDto);
                return JsonUtil.Success(genre.Id);
            }
            catch (Exception ex)
            {
                return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
            }
        }
    }
}
