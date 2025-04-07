namespace Application.Models
{
    public class UpdateFeaturedCollectionDto
    {
        public string Name { get; set; }

        public string? CoverImage { get; set; }

        public bool? IsPublish { get; set; }
    }
}
