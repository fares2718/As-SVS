using As_SVS.Business.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Business.Interfaces
{
    public interface IImageServices
    {
        Task<string> UploadImageAsync(IFormFile imageFile,string userId); 
    }
}
