using CloudStorage.Domain.Entities;
using CloudStorage.Domain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace CloudStorage.Infrastructure.Storage;

public class GoogleDriveStorageService : IStorageService
{
    private readonly GoogleAuthorizationCodeFlow _authorization;
    public GoogleDriveStorageService(GoogleAuthorizationCodeFlow authorization)
    {
        _authorization = authorization;
    }
    public string Upload(IFormFile file, User user)
    {
        var credential = new UserCredential(_authorization, user.Email, new Google.Apis.Auth.OAuth2.Responses.TokenResponse
        {
            AccessToken = user.AcessToken,
            RefreshToken = user.RefreshToken
        });

        var service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
        {
            ApplicationName = "GoogleDrive",
            HttpClientInitializer = credential
        }) ;

        var driveFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = "CloudStorage_"+file.Name,
            MimeType = file.ContentType          
        };

        var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
        command.Fields = "Id";

        var res = command.Upload();
     
        return command.ResponseBody.Id;

    }
}
