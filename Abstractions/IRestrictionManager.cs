using System.Threading.Tasks;

namespace SSCMS.Restriction.Abstractions
{
    public interface IRestrictionManager
    {
        string GetIpAddress();

        string GetHost();

        Task<bool> IsVisitAllowedAsync();
    }
}
