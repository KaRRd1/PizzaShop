using Application;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using WebUI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookieWithSettings();

builder.Services.Configure<CookiePolicyOptions>(options => { options.MinimumSameSitePolicy = SameSiteMode.Strict; });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSpaStaticFiles(config => config.RootPath = "ClientApp/dist");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<ShopDbInitializer>();
    await initializer.InitializeAsync();
    await initializer.SeedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx => { ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=31536000"); }
});

if (!app.Environment.IsDevelopment())
    app.UseSpaStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx => { ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=31536000"); }
    });

app.UseHttpsRedirection();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());


app.UseSpa(x =>
{
    x.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
        x.UseProxyToSpaDevelopmentServer("http://localhost:8080");
});

app.Run();