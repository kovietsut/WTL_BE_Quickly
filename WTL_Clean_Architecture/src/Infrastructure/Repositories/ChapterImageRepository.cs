using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications.Chapter;
using Domain.Specifications;
using Microsoft.AspNetCore.Http;
using Domain.Specifications.ChapterImages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChapterImageRepository : RepositoryBase<ChapterImage, long, MyDbContext>, IChapterImageRepository
    {
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IAuthenticationRepository _authenticationRepository;

        public ChapterImageRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork,
            ISasTokenGenerator sasTokenGenerator, IAuthenticationRepository authenticationRepository
            ) : base(dbContext, unitOfWork)
        {
            _sasTokenGenerator = sasTokenGenerator;
            _authenticationRepository = authenticationRepository;
        }

        public async Task<List<ChapterImage>> CreateListChapterImageAsync(long chapterId, List<ChapterImageDto>? chapterImages)
        {
            var currentUserId = _authenticationRepository.GetUserId();
            var listChapterImages = new List<ChapterImage>();
            chapterImages.ForEach(item =>
            {
                listChapterImages.Add(new ChapterImage
                {
                    IsDeleted = false,
                    Name = item.Name,
                    FileSize = item.FileSize,
                    MimeType = item.MimeType,
                    FilePath = item.FilePath,
                    ChapterId = chapterId,
                    CreatedBy = currentUserId
                });
            });
            await CreateListAsync(listChapterImages);
            return listChapterImages;
        }

        public Task<ChapterImage?> DeleteChapterImageAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ChapterImage>> DeleteChapterImageListAsync(long chapterId)
        {
            List<ChapterImage> imageList = await GetListByChapterId(chapterId);
            await DeleteListAsync(imageList);
            return imageList;
        }

        public Task<ChapterImage?> GetChapterImageById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChapterImage>> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ChapterImage>> GetListByChapterId(long chapterId)
        {
            var query = FindByCondition(x => x.ChapterId == chapterId);
            var specification = new GetListChapterImagesByChapterIdSpecification(chapterId);
            var result = await SpecificationQueryBuilder.GetQuery(query, specification).ToListAsync();
            return result;
        }

        public Task<ChapterImage> UpdateChapterImageAsync(long chapterId, UpdateChapterDto model)
        {
            throw new NotImplementedException();
        }

    }
}
