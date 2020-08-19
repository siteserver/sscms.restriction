using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datory;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Models;
using SSCMS.Services;

namespace SSCMS.Restriction.Core
{
    public class RangeRepository : IRangeRepository
    {
        private readonly Repository<Range> _repository;

        public RangeRepository(ISettingsManager settingsManager)
        {
            _repository = new Repository<Range>(settingsManager.Database);
        }

        private static string GetCacheKey(bool isWhiteList)
        {
            return $"SSCMS.Restriction.Implements.RangeRepository:{isWhiteList}";
        }

        public async Task<int> InsertAsync(Range range)
        {
            return await _repository.InsertAsync(range, Q
                .CachingRemove(GetCacheKey(range.IsWhiteList))
            );
        }

        public async Task UpdateAsync(bool isWhiteList, int rangeId, string ipRange)
        {
            await _repository.UpdateAsync(Q
                .Set(nameof(Range.IpRange), ipRange)
                .Where(nameof(Range.Id), rangeId)
                .CachingRemove(GetCacheKey(isWhiteList))
            );
        }

        public async Task DeleteAsync(bool isWhiteList, int id)
        {
            await _repository.DeleteAsync(id, Q
                .CachingRemove(GetCacheKey(isWhiteList))
            );
        }

        public async Task<List<Range>> GetAllAsync(bool isWhiteList)
        {
            return await _repository.GetAllAsync(Q
                .Where(nameof(Range.IsWhiteList), isWhiteList)
                .OrderByDesc(nameof(Range.Id))
                .CachingGet(GetCacheKey(isWhiteList))
            );
        }

        public async Task<bool> ExistsAsync(bool isWhiteList, string ipRange)
        {
            return await _repository.ExistsAsync(Q
                .Where(nameof(Range.IsWhiteList), isWhiteList)
                .Where(nameof(Range.IpRange), ipRange)
            );
        }

        public async Task<List<string>> GetIpRangesAsync(bool isWhiteList)
        {
            var ranges = await GetAllAsync(isWhiteList);
            return ranges.Select(x => x.IpRange).ToList();
        }
    }
}
