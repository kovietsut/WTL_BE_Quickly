using Application.Features.Genres.Create;
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

namespace Application.Features.Genres.Update
{
    public class UpdateGenreCommand : IRequest<IActionResult>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }

        public class UpdateGenreCommmandHandler(IGenreRepository repository, IOptions<ErrorCode> errorCodes) : IRequestHandler<UpdateGenreCommand, IActionResult>
        {
            private readonly ErrorCode _errorCodes = errorCodes.Value;

            public async Task<IActionResult> Handle(UpdateGenreCommand query, CancellationToken cancellationToken)
            {
                try
                {
                    var updateGenreDto = new UpdateGenreDto
                    {
                        Name = query.Name
                    };
                    var validator = new UpdateGenreValidator();
                    var check = await validator.ValidateAsync(updateGenreDto, cancellationToken);
                    if (!check.IsValid)
                    {
                        return JsonUtil.Errors(StatusCodes.Status400BadRequest, _errorCodes?.Status400?.ConstraintViolation ?? "ConstraintViolation", check.Errors);
                    }

                    var genre = await repository.UpdateGenreAsync(query.Id, updateGenreDto);
                    return JsonUtil.Success(genre.Id);
                }
                catch (Exception ex)
                {
                    return JsonUtil.Error(StatusCodes.Status500InternalServerError, _errorCodes?.Status500?.APIServerError, ex.Message);
                }
            }
        }
    }
}
