using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using DUR.Api.Services.Financial.Interfaces;
using DUR.Api.Settings;
using Microsoft.Extensions.Options;
using WebDav;

namespace DUR.Api.Services.Financial.Services;

public class ExpenseUploader : IExpenseUploader
{
    private readonly NextcloudInterfaceSettings _nextcloudInterfaceSettings; 
    public ExpenseUploader(IOptions<NextcloudInterfaceSettings> options)
    {
        _nextcloudInterfaceSettings = options.Value;
    }
    
    public async Task UploadExpense(string fileName, MemoryStream stream)
    {
        var uploadStream = new MemoryStream();
        stream.Position = 0;
        await stream.CopyToAsync(uploadStream);
        uploadStream.Position = 0;
        var clientParams = new WebDavClientParams { UseProxy = false, UseDefaultCredentials = false, BaseAddress = BuildUploadUrl(), Credentials = new NetworkCredential(_nextcloudInterfaceSettings.User, _nextcloudInterfaceSettings.Password) };
        using var client = new WebDavClient(clientParams);
        var response = await client.PutFile(fileName, uploadStream);
    }

    private Uri BuildUploadUrl()
    {
        return new Uri("https://" + _nextcloudInterfaceSettings.Host + _nextcloudInterfaceSettings.WebDavUploadUrl);
    }
}