using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.DTOs.VideoDTO
{
    public class VideoFile
    {
        public FileStream videoFile { get; set; } = default!;
        public string mimeType { get; set; } = string.Empty;
    }
}
