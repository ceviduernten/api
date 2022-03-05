using System;

namespace DUR.Api.Presentation.ResourceModel;

public class GroupListRM : BaseRM
{
    public Guid IdGroup { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Leaders { get; set; }
    public string MailLeaders { get; set; }
    public string NumberNotification { get; set; }
}