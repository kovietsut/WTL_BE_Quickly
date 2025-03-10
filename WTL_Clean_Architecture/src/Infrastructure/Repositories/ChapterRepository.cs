using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Domain.Specifications.Chapter;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChapterRepository : RepositoryBase<Chapter, long, MyDbContext>, IChapterRepository
    {
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IChapterImageRepository _chapterImageRepository;
        private readonly IAuthenticationRepository _authenticationRepository;

        public ChapterRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork,
            ISasTokenGenerator sasTokenGenerator, IChapterImageRepository chapterImageRepository,
            IAuthenticationRepository authenticationRepository
            ) : base(dbContext, unitOfWork)
        {
            _sasTokenGenerator = sasTokenGenerator;
            _chapterImageRepository = chapterImageRepository;
            _authenticationRepository = authenticationRepository;
        }

        public async Task<Chapter> CreateChapterAsync(CreateChapterDto model)
        {
            var currentUserId = _authenticationRepository.GetUserId();
            var chapter = new Chapter
            {
                IsDeleted = false,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = currentUserId,
                Name = model.Name.Trim(),
                NovelContent = model.NovelContent,
                HasDraft = model.HasDraft,
                ThumbnailImage = model.ThumbnailImage,
                PublishedDate = model.PublishedDate,
                HasComment = model.HasComment,
                StatusChapter = model.StatusChapter
            };
            //Create new chapter
            await CreateAsync(chapter);
            //Create list of chapter image
            await _chapterImageRepository.CreateListChapterImageAsync(chapter.Id, model.ImageList);
            return chapter;
        }

        public async Task<Chapter?> DeleteChapterAsync(long id)
        {
            var chapter = await GetChapterById(id);
            if (chapter != null)
            {
                chapter.IsDeleted = true;
                await UpdateAsync(chapter);
            }
            return chapter;
        }

        public async Task<Chapter?> GetChapterById(long id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetChapterByIdSpecification(id);
            var result = await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
            if(result != null)
            {
                var chapterImages = await _chapterImageRepository.GetListByChapterId(id);
                result.ChapterImages = chapterImages;
            }
            return result;
        }

        public async Task<List<Chapter>> GetList(int? pageNumber, int? pageSize, string? searchText)
        {
            var specification = new GetListChaptersSpecification(pageNumber, pageSize, searchText);
            var result = await SpecificationQueryBuilder.GetQuery(FindAll(), specification).ToListAsync();
            return result;
        }

        public async Task<Chapter> UpdateChapterAsync(long chapterId, UpdateChapterDto model)
        {
            var currentChapter = await GetByIdAsync(chapterId) ?? throw new ArgumentNullException(nameof(chapterId), "Chapter not found");
            currentChapter.UpdatedAt = DateTimeOffset.UtcNow;
            currentChapter.Name = model.Name.Trim();
            currentChapter.NovelContent = model.NovelContent.Trim();
            currentChapter.HasDraft = model.HasDraft;
            currentChapter.ThumbnailImage = model.ThumbnailImage.Trim();
            currentChapter.PublishedDate = model.PublishedDate ?? currentChapter.PublishedDate;
            currentChapter.HasComment = model.HasComment ?? currentChapter.HasComment;
            currentChapter.StatusChapter = model.StatusChapter ?? currentChapter.StatusChapter;

            //Delete old chapter image
            var deleteResult = await _chapterImageRepository.DeleteChapterImageListAsync(currentChapter.Id);
            //Add new list chapter image
            await _chapterImageRepository.CreateListChapterImageAsync(currentChapter.Id, model.ImageList);
            await UpdateAsync(currentChapter);
            return currentChapter;
        }
    }
}
