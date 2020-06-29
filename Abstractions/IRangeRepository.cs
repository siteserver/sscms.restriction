using System.Collections.Generic;
using System.Threading.Tasks;
using SSCMS.Restriction.Models;

namespace SSCMS.Restriction.Abstractions
{
    public interface IRangeRepository
    {
        Task<int> InsertAsync(Range range);

        Task UpdateAsync(bool isWhiteList, int rangeId, string ipRange);

        Task DeleteAsync(bool isWhiteList, int id);

        Task<List<Range>> GetAllAsync(bool isWhiteList);

        Task<bool> ExistsAsync(bool isWhiteList, string ipRange);

        Task<List<string>> GetIpRangesAsync(bool isWhiteList);
    }
}
