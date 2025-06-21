using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.FeaturedCollectionMangas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FeaturedCollectionMangaRepository : RepositoryBase<FeaturedCollectionManga, string, MyDbContext>, IFeaturedCollectionMangaRepository
    {
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMangaRepository _mangaRepository;

        public FeaturedCollectionMangaRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork,
            ISasTokenGenerator sasTokenGenerator, IChapterImageRepository chapterImageRepository,
            IAuthenticationRepository authenticationRepository, IMangaRepository mangaRepository
            ) : base(dbContext, unitOfWork)
        {
            _sasTokenGenerator = sasTokenGenerator;
            _authenticationRepository = authenticationRepository;
            _mangaRepository = mangaRepository;
        }

        //Add manga to collection
        public async Task<FeaturedCollectionManga> CreateFeaturedCollectionMangaAsync(CreateFeaturedCollectionMangaDto model)
        {
            var collection = new FeaturedCollectionManga
            {
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                MangaId = model.MangaId,
                FeaturedCollectionId = model.FeaturedCollectionId
            };

            await CreateAsync(collection);
            return collection;
        }

        public async Task<FeaturedCollectionManga?> GetFeaturedCollectionMangaById(string collectionId, string mangaId)
        {
            var query = FindByCondition(x => x.FeaturedCollectionId == collectionId && x.MangaId == mangaId);
            var specification = new GetFeaturedCollectionMangaByIdSpecification(collectionId, mangaId);
            var result = await SpecificationQueryBuilder.GetQuery(query, specification).FirstOrDefaultAsync();
            return result;
        }

        //Remove manga from collection
        public async Task<FeaturedCollectionManga?> DeleteFeaturedCollectionMangaAsync(string collectionId, string mangaId)
        {
            var collectionManga = await GetFeaturedCollectionMangaById(collectionId, mangaId);
            if (collectionManga != null)
            {
                collectionManga.IsDeleted = true;
                await UpdateAsync(collectionManga);
            }
            return collectionManga;
        }
    }
}
