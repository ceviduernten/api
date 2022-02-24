using DUR.Api.Settings;
using System.Net.Http;

namespace DUR.Api.Repo.Kool.Interfaces
{
    public interface IKoolApi
    {
        HttpClient GetHttpClient();
        KoolInterfaceSettings GetSettings();
    }
}
