using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class CreateMangaInteractionDto
    {
        public long? MangaId { get; set; }

        public long? ChapterId { get; set; }

        public int? InteractionType { get; set; }
    }
}
