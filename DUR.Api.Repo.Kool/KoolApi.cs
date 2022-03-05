using System;
using System.Net.Http;
using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Kool;

public class KoolApi : IKoolApi
{
    private HttpClient _httpClient;
    private readonly KoolInterfaceSettings _settings;

    public KoolApi(KoolInterfaceSettings settings)
    {
        _settings = settings;
        TryAndSetService();
    }

    public HttpClient GetHttpClient()
    {
        if (_httpClient == null) return null;

        return _httpClient;
    }

    public KoolInterfaceSettings GetSettings()
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
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}