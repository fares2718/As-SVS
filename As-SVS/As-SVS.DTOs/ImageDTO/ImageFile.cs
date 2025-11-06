using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.ImageDTO
{
    public class ImageFile
    {
        public FileStream imageFile { get; set; } = default!;
        public string mimeType { get; set; } = string.Empty ;
    }
}
