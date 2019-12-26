using DUR.Api.Repo.Nextcloud.Interfaces;
using DUR.Api.Settings;
using Microsoft.Extensions.Options;

namespace DUR.Api.Repo.Nextcloud
{
    public class NextcloudUnitOfWorkFactory : INextcloudUnitOfWorkFactory
    {
        private readonly GeneralSettings _settings;
        private readonly NextcloudInterfaceSettings _nextcloudInterfaceSettings;
        private readonly INextcloudUnitOfWork _nextcloudUnitOfWork;

        public NextcloudUnitOfWorkFactory(INextcloudUnitOfWork unitOfWork, IOptions<GeneralSettings> settings, IOptions<NextcloudInterfaceSettings> nextcloudInterfaceSettings)
        {
            _nextcloudUnitOfWork = unitOfWork;
            _nextcloudInterfaceSettings = nextcloudInterfaceSettings.Value;
            _settings = settings.Value;
        }

        public INextcloudUnitOfWork Create()
        {
            return _nextcloudUnitOfWork.GetCurrent(_nextcloudInterfaceSettings, _settings);
        }

        public INextcloudUnitOfWork New()
        {
            return new NextcloudUnitOfWork(true, _nextcloudInterfaceSettings, _settings);
        }
    }
}
