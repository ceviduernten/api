using System.Collections.Generic;

namespace DUR.Api.Presentation.ResourceModel;

public class ExportRM<T> where T : class
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public IEnumerable<T> Data { get; set; }
}