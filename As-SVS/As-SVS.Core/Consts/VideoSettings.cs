using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Consts
{
    public class VideoSettings
    {
        public const string videoPath = "/assets/courses";
        public const string AllowedExtentions = ".mp4";
        public const int MaxSizeinMB = 200;
        public const int MaxSizeinB = MaxSizeinMB * 1024 * 1024;
    }
}
