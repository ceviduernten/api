using System;
using System.Net.Http;
using System.Net.Http.Headers;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Nextcloud;

public class NextcloudApi : INextcloudApi
{
    private readonly NextcloudInterfaceSettings _settings;
    private HttpClient _httpClient;

    public NextcloudApi(NextcloudInterfaceSettings settings)
    {
        _settings = settings;
        TryAndSetService();
    }

    public HttpClient GetHttpClient()
    {
        if (_httpClient == null) return null;

        return _httpClient;
    }

    public NextcloudInterfaceSettings GetSettings()
    {
        if (_settings == null) return null;

        return _settings;
    }

    private void TryAndSetService()
    {
        try
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://" + _settings.Host);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}