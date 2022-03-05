using System.Net.Http;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Kool.Interfaces;

public interface IKoolApi
{
    HttpClient GetHttpClient();
    KoolInterfaceSettings GetSettings();
}