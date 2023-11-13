using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services
{
    public interface IImageService
    {
        Task<int> AddImage(IFormFile image);
        Task<bool> UpdateImagePath(IFormFile image, int imageId);

    }
}
