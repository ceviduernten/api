using System;
using DUR.Api.Repo.Nextcloud.Interfaces;

namespace DUR.Api.Repo.Nextcloud.Repositories
{
    public class RepoBase : IRepo
    {
        protected INextcloudApi _api;

        public RepoBase(INextcloudApi api)
        {
            _api = api;
        }
    }
}
