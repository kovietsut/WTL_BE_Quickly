using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BlobItemResponse
    {
        public string? FilePath { get; set; }
        public string? Name { get; set; }
        public Stream? Content { get; set; }
        public string? Message { get; set; }
        public string? ContentType { get; set; }
    }
}
