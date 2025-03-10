using Domain.Entities;

namespace Domain.Specifications.Genres
{
    public class GetListGenresSpecification : Specification<Genere, long>
    {
        public GetListGenresSpecification(int? pageNumber, int? pageSize, string? searchText) :
            base(genre => genre.IsDeleted != true &&
            (string.IsNullOrEmpty(searchText) || (genre.Name != null && genre.Name.Contains(searchText.Trim()))))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            AddOrderByDescending(u => u.CreatedAt);
        }
    }
}
