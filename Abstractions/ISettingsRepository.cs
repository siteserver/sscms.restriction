using System.Threading.Tasks;
using SSCMS.Restriction.Models;

namespace SSCMS.Restriction.Abstractions
{
    public interface ISettingsRepository
    {
        Task<Settings> GetAsync();

        Task<int> SetAsync(Settings settings);
    }
}
