using CloudStorage.Domain.Entities;
using CloudStorage.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CloudStorage.Application.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();
        var isImage = fileStream.Is<JointPhotographicExpertsGroup>() || fileStream.Is<PortableNetworkGraphic>();

        if (isImage == false)
            throw new Exception("Por Favor, insira um arquivo de imagem válido.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Teste",
            Email = "Email@gmail.com",
            RefreshToken = "",
            AcessToken = "",

        };
    }
}
