using System;
namespace DUR.Api.Repo.Nextcloud.Interfaces
{
    public interface INextcloudUnitOfWorkFactory
    {
        INextcloudUnitOfWork Create();
        INextcloudUnitOfWork New();
    }
}
