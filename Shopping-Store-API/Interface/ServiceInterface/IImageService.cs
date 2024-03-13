using CloudinaryDotNet.Actions;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IImageService
    {
        Task<ImageUploadResult> AddImageAsync(IFormFile file);
        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}
