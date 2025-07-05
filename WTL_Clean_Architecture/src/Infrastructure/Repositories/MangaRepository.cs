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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Repositories
{
    public class MangaRepository : RepositoryBase<Manga, string, MyDbContext>, IMangaRepository
    {
        private readonly ErrorCode _errorCodes;
        private readonly IMangaGenreRepository _mangaGenreRepository;
        private readonly ISasTokenGenerator _sasTokenGenerator;
        private readonly IImageRepository _imageRepository;
        private readonly IAzureBlobRepository _azureBlobRepository;
        //private readonly IMangaInteractionService _mangaInteractionService;
        //private readonly IMangaReactionRepository _mangaInteractionRepository;
        public MangaRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IOptions<ErrorCode> errorCode,
            ISasTokenGenerator sasTokenGenerator,
            IMangaGenreRepository mangaGenreRepository, IImageRepository imageRepository,
            IAzureBlobRepository azureBlobRepository) : base(dbContext, unitOfWork)
        {
            _errorCodes = errorCode.Value;
            _mangaGenreRepository = mangaGenreRepository;
            _sasTokenGenerator = sasTokenGenerator;
            _azureBlobRepository = azureBlobRepository;
            _imageRepository = imageRepository;
            //_mangaInteractionService = mangaInteractionService;
            //_mangaInteractionRepository = mangaInteractionRepository;
        }

        public async Task<Manga> CreateMangaAsync(CreateMangaDto model)
        {
            var manga = new Manga()
            {
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                CreatedAt = DateTimeOffset.UtcNow,
                Title = model.Title.Trim(),
                PublishedDate = model.PublishedDate,
                Format = MangaMapper.ToDomainFormat((Domain.Enums.MangaFormatDto?)model.Format),
                Region = MangaMapper.ToDomainRegion((Domain.Enums.MangaRegionDto?)model.Region),
                ReleaseStatus = MangaMapper.ToDomainReleaseStatus((Domain.Enums.MangaReleaseStatusDto?)model.ReleaseStatus),
                Preface = model.Preface?.Trim(),
                HasAdult = model.HasAdult,
                CreatedBy = model.CreatedBy,
                SubAuthor = model.SubAuthor,
                Publishor = model.Publishor,
                Artist = model.Artist,
                Translator = model.Translator
            };
            await CreateAsync(manga);

            if (model.GenreIds != null && model.GenreIds.Any())
            {
                await _mangaGenreRepository.CreateMangaGenresAsync(manga.Id, model.GenreIds);
            }

            return manga;
        }

        public async Task<Manga?> DeleteMangaAsync(string id)
        {
            var manga = await GetMangaById(id);
            if (manga != null)
            {
                manga.IsDeleted = true;
                await UpdateAsync(manga);
                await _mangaGenreRepository.DeleteMangaGenresAsync(id);
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

        public async Task<Manga?> GetMangaById(string id)
        {
            var query = FindByCondition(x => x.Id == id);
            var specification = new GetMangaByIdSpecification(id);
            return await SpecificationQueryBuilder.GetQuery(query, specification).SingleOrDefaultAsync();
        }

        public async Task<Manga> UpdateMangaAsync(string mangaId, UpdateMangaDto model)
        {
            var currentManga = await GetByIdAsync(mangaId) ?? throw new ArgumentNullException(nameof(mangaId), "Manga not found");
            
            currentManga.UpdatedAt = DateTimeOffset.UtcNow;
            currentManga.Title = model.Title.Trim();
            currentManga.PublishedDate = model.PublishedDate ?? currentManga.PublishedDate;
            currentManga.Format = model.Format.HasValue ? MangaMapper.ToDomainFormat((Domain.Enums.MangaFormatDto?)model.Format) : currentManga.Format;
            currentManga.Region = model.Region.HasValue ? MangaMapper.ToDomainRegion((Domain.Enums.MangaRegionDto?)model.Region) : currentManga.Region;
            currentManga.ReleaseStatus = model.ReleaseStatus.HasValue ? MangaMapper.ToDomainReleaseStatus((Domain.Enums.MangaReleaseStatusDto?)model.ReleaseStatus) : currentManga.ReleaseStatus;
            currentManga.Preface = model.Preface?.Trim() ?? currentManga.Preface?.Trim();
            currentManga.HasAdult = model.HasAdult ?? currentManga.HasAdult;
            currentManga.SubAuthor = model.SubAuthor ?? currentManga.SubAuthor;
            currentManga.Publishor = model.Publishor ?? currentManga.Publishor;
            currentManga.Artist = model.Artist ?? currentManga.Artist;
            currentManga.Translator = model.Translator ?? currentManga.Translator;
            await UpdateAsync(currentManga);
            return currentManga;
        }

        public async Task<string> UploadCoverImageAsync(string mangaId, string coverImageUrl)
        {
            
            var manga = await GetByIdAsync(mangaId) ?? throw new ArgumentNullException(nameof(mangaId), "Manga not found");

            manga.CoverImage = coverImageUrl;
            await UpdateAsync(manga);

            return manga.CoverImage;
        }
    }
}
