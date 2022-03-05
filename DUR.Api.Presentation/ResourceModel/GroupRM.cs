using System;

namespace DUR.Api.Presentation.ResourceModel;

public class GroupRM : BaseRM
{
    public Guid IdGroup { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Leaders { get; set; }
    public string Mail { get; set; }
    public string MailLeaders { get; set; }
    public string NumberNotification { get; set; }
}