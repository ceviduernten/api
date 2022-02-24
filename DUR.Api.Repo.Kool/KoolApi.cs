using DUR.Api.Repo.Kool.Interfaces;
using DUR.Api.Settings;
using System;
using System.Net.Http;

namespace DUR.Api.Repo.Kool
{
    public class KoolApi : IKoolApi
    {
        private HttpClient _httpClient;
        private KoolInterfaceSettings _settings;

        public KoolApi(KoolInterfaceSettings settings)
        {
            _settings = settings;
            TryAndSetService();
        }

        private void TryAndSetService()
        {
            try
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new System.Uri("https://" + _settings.Host);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public HttpClient GetHttpClient()
        {
            if (_httpClient == null)
            {
                return null;
            }

            return _httpClient;
        }

        public KoolInterfaceSettings GetSettings()
        {
            if (_settings == null)
            {
                return null;
            }

            return _settings;
        }
    }
}
