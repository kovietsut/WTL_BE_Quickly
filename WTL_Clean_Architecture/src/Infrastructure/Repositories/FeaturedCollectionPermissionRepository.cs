using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.FeaturedCollectionPermissions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FeaturedCollectionPermissionRepository : RepositoryBase<FeaturedCollectionPermission, string, MyDbContext>, IFeaturedCollectionPermissionRepository
    {
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IUserRepository _userRepository;

        public FeaturedCollectionPermissionRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork,
            ISasTokenGenerator sasTokenGenerator, IChapterImageRepository chapterImageRepository,
            IAuthenticationRepository authenticationRepository, IMangaRepository mangaRepository,
            IUserRepository userRepository
            ) : base(dbContext, unitOfWork)
        {
            _sasTokenGenerator = sasTokenGenerator;
            _authenticationRepository = authenticationRepository;
            _mangaRepository = mangaRepository;
            _userRepository = userRepository;
        }

        //Add permission for one or many user
        public async Task<List<string>> CreateListFeaturedCollectionPermissionAsync(CreateFeaturedCollectionPermissionDto model)
        {
            List<FeaturedCollectionPermission> permissions = new List<FeaturedCollectionPermission>();
            foreach (var userId in model.UserIds)
            {
                var collectionPermission = new FeaturedCollectionPermission
                {
                    Id = Guid.NewGuid().ToString(),
                    IsDeleted = false,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UserId = userId,
                    FeaturedCollectionId = model.FeaturedCollectionId,
                    PermissionType = model.PermissionType
                };
                permissions.Add(collectionPermission);
            }
            var result = await CreateListAsync(permissions);
            return result.ToList();
        }

        public async Task<FeaturedCollectionPermission?> GetFeaturedCollectionPermissionById(string collectionId, string userId)
        {
            var query = FindByCondition(x => x.FeaturedCollectionId == collectionId && x.UserId == userId);
            var specification = new GetFeaturedCollectionPermissionByIdSpecification(collectionId, userId);
            var result = await SpecificationQueryBuilder.GetQuery(query, specification).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> DeleteListFeaturedCollectionPermissionAsync(string collectionId, List<string> userIds)
        {
            List<FeaturedCollectionPermission> permissions = new List<FeaturedCollectionPermission>();
            foreach (var userId in userIds)
            {
                var collectionPermission = await GetFeaturedCollectionPermissionById(collectionId, userId);
                if (collectionPermission != null)
                {
                    collectionPermission.IsDeleted = true;
                    permissions.Add(collectionPermission);
                }
                else 
                    return false;
            }
            await UpdateListAsync(permissions);
            return true;
        }
    }
}
