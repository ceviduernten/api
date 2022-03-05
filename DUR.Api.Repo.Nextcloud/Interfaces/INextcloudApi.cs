using System.Net.Http;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Nextcloud.Interfaces;

public interface INextcloudApi
{
    HttpClient GetHttpClient();
    NextcloudInterfaceSettings GetSettings();
}