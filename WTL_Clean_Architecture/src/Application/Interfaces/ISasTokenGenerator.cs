using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISasTokenGenerator
    {
        string GenerateSasToken(string fileName, string folderName);
        string GenerateCoverImageUriWithSas(string coverImageUrl);
    }
}
