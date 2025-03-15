using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UpdateFeaturedCollectionDto
    {
        public string Name { get; set; }

        public string? CoverImage { get; set; }

        public bool? IsPublish { get; set; }
    }
}
