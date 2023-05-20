using System;
using DUR.Api.Entities.Admin;
using Microsoft.AspNetCore.Http;

namespace DUR.Api.Presentation.ResourceModel;

public class ExpenseUploadRM
{
    public string Values { get; set; }
    public IFormFile File { get; set; }
}