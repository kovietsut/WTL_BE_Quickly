using Application.Interfaces;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications.MangaGenres;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MangaGenreRepository : RepositoryBase<MangaGenre, string, MyDbContext>, IMangaGenreRepository
    {
        public MangaGenreRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork) 
            : base(dbContext, unitOfWork)
        {
        }

        public async Task CreateMangaGenresAsync(string mangaId, List<string> genreIds)
        {
            var mangaGenres = genreIds.Select(genreId => new MangaGenre
            {
                Id = Guid.NewGuid().ToString(),
                MangaId = mangaId,
                GenreId = genreId,
                IsDeleted = false,
            }).ToList();

            await CreateListAsync(mangaGenres);
        }

        public async Task DeleteMangaGenresAsync(string mangaId)
        {
            var specification = new GetMangaGenresByMangaIdSpecification(mangaId);
            var query = FindBySpecification(specification);
            var mangaGenres = await query.ToListAsync();

            foreach (var mangaGenre in mangaGenres)
            {
                mangaGenre.IsDeleted = true;
            }
            await UpdateListAsync(mangaGenres);
        }
    }
} 