namespace Application.Models
{
    public class UpdateFeaturedCollectionDto
    {
        public required string Name { get; set; }

        public string? CoverImage { get; set; }

        public bool? IsPublish { get; set; }
    }
}
