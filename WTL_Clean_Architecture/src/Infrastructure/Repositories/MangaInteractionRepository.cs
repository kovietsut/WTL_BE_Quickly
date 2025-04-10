using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Persistence;
using Domain.Specifications.MangaInteractions;
using Microsoft.AspNetCore.Http;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MangaInteractionRepository : RepositoryBase<MangaInteraction, long, MyDbContext>, IMangaInteractionRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MangaInteractionRepository(MyDbContext dbContext, IUnitOfWork<MyDbContext> unitOfWork, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MangaInteraction> CreateMangaInteractionAsync(CreateMangaInteractionDto mangaInteractionDto)
        {
            var userId = long.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value ?? "0");
            
            var mangaInteraction = new MangaInteraction
            {
                UserId = userId,
                MangaId = mangaInteractionDto.MangaId,
                ChapterId = mangaInteractionDto.ChapterId,
                InteractionType = mangaInteractionDto.InteractionType,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await CreateAsync(mangaInteraction);
            return mangaInteraction;
        }

        public async Task<MangaInteraction?> DeleteMangaInteractionAsync(long? mangaId, long? chapterId)
        {
            var userId = long.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value ?? "0");
            var mangaInteraction = await GetMangaInteractionByUserAndContentAsync(userId, mangaId, chapterId, null);
            if (mangaInteraction != null)
            {
                await DeleteAsync(mangaInteraction);
            }
            return mangaInteraction;
        }

        public async Task<MangaInteraction?> GetMangaInteractionByUserAndContentAsync(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType)
        {
            var specification = new GetMangaInteractionByUserAndContentSpecification(userId, mangaId, chapterId, interactionType);
            return await GetBySpecificationAsync(specification);
        }

        public async Task<IEnumerable<MangaInteraction>> GetMangaInteractionListAsync(long userId, long? mangaId, long? chapterId, MangaInteractionType? interactionType, int? pageNumber, int? pageSize)
        {
            try
            {
                var specification = new GetMangaInteractionListSpecification(userId, mangaId, chapterId, interactionType, pageNumber, pageSize);
                var query = FindBySpecification(specification);
                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception here if you have a logging mechanism
                Console.WriteLine($"Error in GetMangaInteractionListAsync: {ex.Message}");
                return new List<MangaInteraction>();
            }
        }
    }
}
