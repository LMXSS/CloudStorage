using Microsoft.AspNetCore.Mvc;
using CloudStorage.Application.UseCases.Users.UploadProfilePhoto;

namespace CloudStorage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase,IFormFile file)
    {


        useCase.Execute(file);
        return Created();
    }
}
