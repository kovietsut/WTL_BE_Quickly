using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ChapterImageDto
    {
        public string Name { get; set; }

        public string? FileSize { get; set; }

        public string? MimeType { get; set; }

        public string? FilePath { get; set; }
    }
}
