using Microsoft.AspNetCore.Http;

namespace CloudStorage.Application.UseCases.Users.UploadProfilePhoto
{
    public interface IUploadProfilePhotoUseCase
    {
        public void Execute(IFormFile file);
    }
}
