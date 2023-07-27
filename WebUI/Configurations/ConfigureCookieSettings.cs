using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebUI.Configurations;

public static class ConfigureCookieSettings
{
    private const string IdentifierCookieName = "auth";
    private const int ExpireTimeInDays = 30;

    public static AuthenticationBuilder AddCookieWithSettings(this AuthenticationBuilder builder)
    {
        builder.AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            // options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Lax;

            options.ExpireTimeSpan = TimeSpan.FromDays(ExpireTimeInDays);
            options.SlidingExpiration = true;
            options.Cookie.Name = IdentifierCookieName;
            
            options.Events.OnRedirectToLogin = context => {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            };
        });

        return builder;
    }
}