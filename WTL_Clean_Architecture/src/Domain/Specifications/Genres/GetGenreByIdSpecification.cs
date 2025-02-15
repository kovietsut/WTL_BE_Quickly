using Domain.Entities;

namespace Domain.Specifications.Genres
{
    public class GetGenreByIdSpecification : Specification<Genere, long>
    {
        public GetGenreByIdSpecification(long id) : base(genre => genre.Id == id)
        {

        }
    }
}
