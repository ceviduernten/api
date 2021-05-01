using DUR.Api.Settings;
using System.Net.Http;

namespace DUR.Api.Repo.Nextcloud.Interfaces
{
    public interface INextcloudApi
    {
        HttpClient GetHttpClient();
        NextcloudInterfaceSettings GetSettings();
    }
}
