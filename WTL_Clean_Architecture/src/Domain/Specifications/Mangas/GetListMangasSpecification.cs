using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.Mangas
{
    public class GetListMangasSpecification : Specification<Manga, long>
    {
        public GetListMangasSpecification(int? pageNumber, int? pageSize, string? searchText) :
            base(manga => manga.IsDeleted != true &&
            (string.IsNullOrEmpty(searchText) || (manga.Title != null && manga.Title.Contains(searchText.Trim()))))
        {
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
            AddOrderByDescending(u => u.CreatedAt);
        }
    }
}
