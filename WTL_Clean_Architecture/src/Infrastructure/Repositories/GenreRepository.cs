using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.Genres;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository : RepositoryBase<Genere, long, MyDbContext>, IGenreRepository
    {
        private readonly IEncryptionRepository _iEncryptionRepository;
        public GenreRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IEncryptionRepository iEncryptionRepository)
           : base(dbContext, unitOfWork)
        {
            _iEncryptionRepository = iEncryptionRepository;
        }
        public async Task<Genere> CreateGenreAsync(CreateGenreDto model)
        {
            var genre = new Genere()
            {
                IsDeleted = false,
                CreatedAt = DateTimeOffset.UtcNow,
                Name = model.Name.Trim()
            };
            await CreateAsync(genre);
            return genre;
        }

        public async Task<Genere?> GetGenreById(long id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetGenreByIdSpecification(id);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<List<Genere>> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var specification = new GetListGenresSpecification(pageNumber, pageSize, searchText);
            var query = FindBySpecification(specification);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Genere> UpdateGenreAsync(long genreId, UpdateGenreDto model)
        {
            var currentGenre = await GetByIdAsync(genreId) ?? throw new ArgumentNullException(nameof(genreId), "Genre not found");
            currentGenre.UpdatedAt = DateTimeOffset.UtcNow;
            currentGenre.Name = model.Name.Trim();
            await UpdateAsync(currentGenre);
            return currentGenre;
        }

        public async Task<Genere?> DeleteGenreAsync(long id)
        {
            var genre = await GetGenreById(id);
            if (genre != null)
            {
                genre.IsDeleted = true;
                await UpdateAsync(genre);
            }
            return genre;
        }
    }
}
