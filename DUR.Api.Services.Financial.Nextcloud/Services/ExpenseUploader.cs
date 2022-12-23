using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using DUR.Api.Services.Financial.Interfaces;
using WebDav;

namespace DUR.Api.Services.Financial.Services;

public class ExpenseUploader : IExpenseUploader
{
    public async Task UploadExpense(string fileName, MemoryStream stream)
    {
        stream.Position = 0;
        var clientParams = new WebDavClientParams { BaseAddress = new Uri("https://duernten.cevi.cloud/remote.php/dav/files/sa_expense/Digitalen Spesen/"), Credentials = new NetworkCredential("sa_expense", "w0mWMVL7QugM73fbW8g0GHLC") };
        using var client = new WebDavClient(clientParams);
        await client.PutFile(fileName, stream);
    }
}