using System.Security.Principal;

namespace WebUI.Extensions;

public static class IdentityExtensions
{
    public static int? NameToInt(this IIdentity identity)
    {
        if (int.TryParse(identity.Name, out int value))
            return value;

        return null;
    }
}