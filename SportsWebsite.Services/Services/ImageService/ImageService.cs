using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.Entities;
using System.Runtime;

namespace SprotsWebsite.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddImage(IFormFile image)
        {
            string photoName =  await AddImageToImagesFolder(image);
            var DbImage = new Image { PhotoName = $"{photoName}" };
            await _unitOfWork.ImageRepository.InsertAsync(DbImage);
            await _unitOfWork.SaveChangesAsync();
            return DbImage.Id;
        }

        public async Task<bool> UpdateImagePath(IFormFile image, int imageId)
        {
            if (imageId < 1) return false;
            string photoName = await AddImageToImagesFolder(image);
            Image DbImage = await _unitOfWork.ImageRepository.GetAsIQueryable().FirstOrDefaultAsync(x=>x.Id == imageId);
            if (image == null) return false;
            DeleteOldImage(DbImage.PhotoName);
            DbImage.PhotoName = photoName;
            return await _unitOfWork.SaveChangesAsync();
        }
        private async Task<string> AddImageToImagesFolder(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var randomName = Path.GetRandomFileName();
            string newPhotoName = $"{randomName}{extension}";
            var photoPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "images", newPhotoName);

            await image.CopyToAsync(new FileStream(photoPath, FileMode.Create));

            return newPhotoName;
        }
        private void DeleteOldImage(string photoName)
        {
            string photoPath =  Path.Combine(Environment.CurrentDirectory, "wwwroot", "images", $"{photoName}");
            if (File.Exists(photoPath))
            {
                File.Delete(photoPath);
            }
        }
    }
}
