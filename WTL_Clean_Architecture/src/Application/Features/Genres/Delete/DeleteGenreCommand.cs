using Application.Features.Users.Delete;
using Application.Interfaces;
using Application.Utils;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Genres.Delete
{
    public class DeleteGenreCommand(string id) : IRequest<IActionResult>
    {
        public string Id { get; private set; } = id;
    }

    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, IActionResult>
    {
        private readonly IGenreRepository _repository;
        private readonly ErrorCode _errorCodes;

        public DeleteGenreCommandHandler(IGenreRepository repository, IOptions<ErrorCode> errorCodes)
        {
            _repository = repository;
            _errorCodes = errorCodes.Value;
        }

        public async Task<IActionResult> Handle(DeleteGenreCommand query, CancellationToken cancellationToken)
        {
            var user = await _repository.DeleteGenreAsync(query.Id);
            if (user == null)
            {
                return JsonUtil.Error(StatusCodes.Status404NotFound, _errorCodes.Status404?.NotFound, "Genre does not exist");
            }
            return JsonUtil.Success(user.Id);
        }
    }
}
