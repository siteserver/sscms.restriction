namespace SSCMS.Restriction.Abstractions
{
    public interface IRestrictionManager
    {
        string GetIpAddress();

        string GetHost();

        bool IsVisitAllowed();
    }
}
