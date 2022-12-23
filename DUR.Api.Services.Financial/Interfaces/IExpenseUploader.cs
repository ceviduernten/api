using System.IO;
using System.Threading.Tasks;
using DUR.Api.Entities.Financial;

namespace DUR.Api.Services.Financial.Interfaces;

public interface IExpenseUploader
{
    Task UploadExpense(string fileName, MemoryStream stream);
}