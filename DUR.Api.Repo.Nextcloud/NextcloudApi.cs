using System;
using System.Net.Http;
using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Settings;

namespace DUR.Api.Repo.Nextcloud
{
    public class NextcloudApi : INextcloudApi
    {
        private HttpClient _httpClient;
        private NextcloudInterfaceSettings _settings;

        public NextcloudApi(NextcloudInterfaceSettings settings)
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
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
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

        public NextcloudInterfaceSettings GetSettings()
        {
            if (_settings == null)
            {
                return null;
            }

            return _settings;
        }
    }
}
