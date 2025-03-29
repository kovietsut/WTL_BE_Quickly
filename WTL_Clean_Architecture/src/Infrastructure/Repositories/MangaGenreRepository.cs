using Application.Interfaces;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications.MangaGenres;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MangaGenreRepository : RepositoryBase<MangaGenre, long, MyDbContext>, IMangaGenreRepository
    {
        public MangaGenreRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork) 
            : base(dbContext, unitOfWork)
        {
        }

        public async Task CreateMangaGenresAsync(long mangaId, List<long> genreIds)
        {
            var mangaGenres = genreIds.Select(genreId => new MangaGenre
            {
                MangaId = mangaId,
                GenreId = genreId,
                IsDeleted = false,
            }).ToList();

            await CreateListAsync(mangaGenres);
        }

        public async Task DeleteMangaGenresAsync(long mangaId)
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