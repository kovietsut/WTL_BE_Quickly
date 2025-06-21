using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.FeaturedCollections;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FeaturedCollectionRepository : RepositoryBase<FeaturedCollection, string, MyDbContext>, IFeaturedCollectionRepository
    {
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMangaRepository _mangaRepository;

        public FeaturedCollectionRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork,
            ISasTokenGenerator sasTokenGenerator, IChapterImageRepository chapterImageRepository,
            IAuthenticationRepository authenticationRepository, IMangaRepository mangaRepository
            ) : base(dbContext, unitOfWork)
        {
            _sasTokenGenerator = sasTokenGenerator;
            _authenticationRepository = authenticationRepository;
            _mangaRepository = mangaRepository;
        }

        public async Task<FeaturedCollection> CreateFeaturedCollectionAsync(CreateFeaturedCollectionDto model)
        {
            var currentUserId = _authenticationRepository.GetUserId();
            var collection = new FeaturedCollection
            {
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = currentUserId,
                Name = model.Name.Trim(),
                CoverImage = model.CoverImage != null ? _sasTokenGenerator.GenerateCoverImageUriWithSas(model.CoverImage) : null,
                IsPublish = model.IsPublish
            };
            //Create new chapter
            await CreateAsync(collection);
            return collection;
        }

        public async Task<FeaturedCollection?> DeleteFeaturedCollectionAsync(string id)
        {
            var collection = await GetFeaturedCollectionById(id);
            if (collection != null)
            {
                collection.IsDeleted = true;
                await UpdateAsync(collection);
            }
            return collection;
        }

        public async Task<FeaturedCollection?> GetFeaturedCollectionById(string id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetFeaturedCollectionByIdSpecification(id);
            var result = await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
            return result;
        }

        public async Task<List<FeaturedCollection>> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var currentUserId = _authenticationRepository.GetUserId();
            var specification = new GetListFeaturedCollectionsSpecification(pageNumber, pageSize, searchText, currentUserId);
            var query = FindBySpecification(specification);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<FeaturedCollection> UpdateFeaturedCollectionAsync(string featuredCollectionId, UpdateFeaturedCollectionDto model)
        {
            var currentCollection = await GetByIdAsync(featuredCollectionId) ?? throw new ArgumentNullException(nameof(featuredCollectionId), "Collection not found");
            currentCollection.UpdatedAt = DateTimeOffset.UtcNow;
            currentCollection.Name = model.Name.Trim();
            currentCollection.CoverImage = model.CoverImage.Trim();
            currentCollection.IsPublish = model.IsPublish;
            await UpdateAsync(currentCollection);
            return currentCollection;
        }
    }
}
