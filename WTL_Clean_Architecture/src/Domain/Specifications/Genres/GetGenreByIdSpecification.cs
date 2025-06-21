using Domain.Entities;

namespace Domain.Specifications.Genres
{
    public class GetGenreByIdSpecification : Specification<Genere, string>
    {
        public GetGenreByIdSpecification(string id) : base(genre => genre.Id == id)
        {

        }
    }
}
