using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Models
{
    public class CreateMangaInteractionDto
    {
        public long? MangaId { get; set; }

        public long? ChapterId { get; set; }

        public MangaInteractionType? InteractionType { get; set; }
    }
}
