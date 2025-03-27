using Application.Interfaces;
using Application.Models;
using Domain.Configurations;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Domain.Specifications.Mangas;
using Domain.Mappers;
using Domain.SpecificationModels;

namespace Infrastructure.Repositories
{
    public class MangaRepository : RepositoryBase<Manga, long, MyDbContext>, IMangaRepository
    {
        private readonly ErrorCode _errorCodes;
        //private readonly IMangaGenreRepository _mangaGenreRepository;
        private readonly ISasTokenGenerator _sasTokenGenerator;
        //private readonly IMangaInteractionService _mangaInteractionService;
        //private readonly IMangaReactionRepository _mangaInteractionRepository;
        public MangaRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IOptions<ErrorCode> errorCode,
            ISasTokenGenerator sasTokenGenerator) : base(dbContext, unitOfWork)
        {
            _errorCodes = errorCode.Value;
            //_mangaGenreRepository = mangaGenreRepository;
            _sasTokenGenerator = sasTokenGenerator;
            //_mangaInteractionService = mangaInteractionService;
            //_mangaInteractionRepository = mangaInteractionRepository;
        }

        public async Task<Manga> CreateMangaAsync(CreateMangaDto model)
        {
            var manga = new Manga()
            {
                IsDeleted = false,
                CreatedAt = DateTimeOffset.UtcNow,
                Title = model.Title.Trim(),
                PublishedDate = model.PublishedDate,
                Format = MangaMapper.ToDomainFormat(model.Format),
                Season = MangaMapper.ToDomainSeason(model.Season),
                Region = MangaMapper.ToDomainRegion(model.Region),
                ReleaseStatus = MangaMapper.ToDomainReleaseStatus(model.ReleaseStatus),
                Preface = model.Preface.Trim(),
                HasAdult = model.HasAdult,
                CoverImage = _sasTokenGenerator.GenerateCoverImageUriWithSas(model.CoverImage),
                CreatedBy = model.CreatedBy,
                SubAuthor = model.SubAuthor,
                Publishor = model.Publishor,
                Artist = model.Artist,
                Translator = model.Translator
            };
            await CreateAsync(manga);
            return manga;
        }

        public async Task<Manga?> DeleteMangaAsync(long id)
        {
            var manga = await GetMangaById(id);
            if (manga != null)
            {
                manga.IsDeleted = true;
                await UpdateAsync(manga);
            }
            return manga;
        }

        public async Task<(List<Manga> Items, int TotalCount)> GetList(MangaFilterDto filter)
        {
            var specification = new GetListMangasSpecification(filter);
            var query = FindBySpecification(specification);
            var result = await query.ToListAsync();
            
            // Get total count with the same filters but without paging
            var countSpecification = new GetListMangasSpecification(filter, includePaging: false);
            var countQuery = FindBySpecification(countSpecification);
            var totalCount = await countQuery.CountAsync();
            
            return (result, totalCount);
        }

        public async Task<Manga?> GetMangaById(long id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetMangaByIdSpecification(id);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<Manga> UpdateMangaAsync(long mangaId, UpdateMangaDto model)
        {
            var currentManga = await GetByIdAsync(mangaId) ?? throw new ArgumentNullException(nameof(mangaId), "Manga not found");
            currentManga.UpdatedAt = DateTimeOffset.UtcNow;
            currentManga.Title = model.Title.Trim();
            currentManga.PublishedDate = model.PublishedDate ?? currentManga.PublishedDate;
            currentManga.Format = model.Format.HasValue ? MangaMapper.ToDomainFormat(model.Format) : currentManga.Format;
            currentManga.Season = model.Season.HasValue ? MangaMapper.ToDomainSeason(model.Season) : currentManga.Season;
            currentManga.Region = model.Region.HasValue ? MangaMapper.ToDomainRegion(model.Region) : currentManga.Region;
            currentManga.ReleaseStatus = model.ReleaseStatus.HasValue ? MangaMapper.ToDomainReleaseStatus(model.ReleaseStatus) : currentManga.ReleaseStatus;
            currentManga.Preface = model.Preface.Trim() ?? currentManga.Preface.Trim();
            currentManga.HasAdult = model.HasAdult ?? currentManga.HasAdult;
            currentManga.CoverImage = model.CoverImage.Trim() ?? currentManga.CoverImage.Trim();
            currentManga.SubAuthor = model.SubAuthor ?? currentManga.SubAuthor;
            currentManga.Publishor = model.Publishor ?? currentManga.Publishor;
            currentManga.Artist = model.Artist ?? currentManga.Artist;
            currentManga.Translator = model.Translator ?? currentManga.Translator;
            await UpdateAsync(currentManga);
            return currentManga;
        }
    }
}
