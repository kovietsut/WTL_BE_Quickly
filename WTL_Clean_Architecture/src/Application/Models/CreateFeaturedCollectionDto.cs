namespace Application.Models
{
    public class CreateFeaturedCollectionDto
    {
        public string Name { get; set; }

        public string? CoverImage { get; set; }

        public bool? IsPublish { get; set; }
    }
}
