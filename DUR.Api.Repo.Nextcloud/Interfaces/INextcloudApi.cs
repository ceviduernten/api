using System;
using System.Net.Http;

namespace DUR.Api.Repo.Nextcloud.Interfaces
{
    public interface INextcloudApi
    {
        HttpClient GetHttpClient();
    }
}
