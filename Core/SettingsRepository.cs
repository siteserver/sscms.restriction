using System.Threading.Tasks;
using Datory;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Models;
using SSCMS.Services;

namespace SSCMS.Restriction.Core
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly Repository<Settings> _repository;

        public SettingsRepository(ISettingsManager settingsManager)
        {
            _repository = new Repository<Settings>(settingsManager.Database);
        }

        private const string CacheKey = "SSCMS.Restriction.Implements.SettingsRepository";

        public async Task<Settings> GetAsync()
        {
            var settings = await _repository.GetAsync(Q
                .OrderBy(nameof(Settings.Id))
                .CachingGet(CacheKey)
            );
            if (settings == null)
            {
                settings = new Settings
                {
                    RestrictionType = RestrictionType.None,
                    IsHostRestriction = false
                };
                settings.Id = await SetAsync(settings);
            }

            return settings;
        }

        public async Task<int> SetAsync(Settings settings)
        {
            if (settings.Id > 0)
            {
                await _repository.UpdateAsync(settings, Q.CachingRemove(CacheKey));
            }
            else
            {
                settings.Id = await _repository.InsertAsync(settings, Q.CachingRemove(CacheKey));
            }
            return settings.Id;
        }
    }
}
