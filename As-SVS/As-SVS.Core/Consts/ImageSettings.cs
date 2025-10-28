using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Consts
{
    public class ImageSettings
    {
        public const string ImagesPath = "/assets/images/user";
        public const string AllowedExtentions = ".jpg,.jpeg,.png";
        public const int MaxSizeinMB = 2;
        public const int MaxSizeinB = MaxSizeinMB * 1024 * 1024;
    }
}
