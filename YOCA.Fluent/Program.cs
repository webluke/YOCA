using System.Net;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.FluentUI.AspNetCore.Components;
using YOCA.Fluent.Components;
using YOCA.Fluent.Models;
using YOCA.Fluent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddCascadingAuthenticationState();

// Auth0: ensure an Action/API maps the Admin role onto ClaimTypes.Role
// (http://schemas.microsoft.com/ws/2008/06/identity/claims/role).
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    // Non-Development startup validates Domain/ClientId below; Development may use empty placeholders.
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<DayOfCodeDataAccess>();
builder.Services.AddSingleton<ProjectDataAccess>();
builder.Services.AddSingleton<ProjectBoardDataAccess>();
builder.Services.AddSingleton<ProjectTaskDataAccess>();
builder.Services.AddSingleton<PageDataAccess>();
builder.Services.AddSingleton<ClipboardDataAccess>();
builder.Services.AddSingleton<IdeaDataAccess>();
builder.Services.AddSingleton<LinkDataAccess>();
builder.Services.AddSingleton<RewindDataAccess>();

builder.Services.AddSingleton<Statuses>();
builder.Services.AddSingleton<LinkTargets>();
builder.Services.AddSingleton<AppTimeZone>();

builder.Services.AddSingleton<IMarkdownService, MarkdigService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    if (string.IsNullOrWhiteSpace(connectionString) || connectionString.Trim() == "Data Source=")
    {
        throw new InvalidOperationException("ConnectionStrings:Default must be configured for non-Development environments.");
    }

    if (string.IsNullOrWhiteSpace(builder.Configuration["Auth0:Domain"])
        || string.IsNullOrWhiteSpace(builder.Configuration["Auth0:ClientId"]))
    {
        throw new InvalidOperationException("Auth0:Domain and Auth0:ClientId must be configured for non-Development environments.");
    }

    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownNetworks.Clear();
forwardedHeadersOptions.KnownProxies.Clear();

var knownProxies = builder.Configuration.GetSection("ForwardedHeaders:KnownProxies").Get<string[]>();
if (knownProxies is { Length: > 0 })
{
    foreach (var proxy in knownProxies)
    {
        if (IPAddress.TryParse(proxy, out var address))
        {
            forwardedHeadersOptions.KnownProxies.Add(address);
        }
    }
}
else if (app.Environment.IsDevelopment())
{
    // Allow common local reverse-proxy addresses in Development only.
    forwardedHeadersOptions.KnownProxies.Add(IPAddress.Loopback);
    forwardedHeadersOptions.KnownProxies.Add(IPAddress.IPv6Loopback);
}

app.UseForwardedHeaders(forwardedHeadersOptions);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Report-Only first so CDN scripts (Toast UI, Font Awesome, Ko-fi, GA) can be tuned without breaking the site.
    context.Response.Headers.Append(
        "Content-Security-Policy-Report-Only",
        "default-src 'self'; " +
        "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://uicdn.toast.com https://storage.ko-fi.com https://www.googletagmanager.com https://www.google-analytics.com; " +
        "style-src 'self' 'unsafe-inline' https://use.fontawesome.com https://uicdn.toast.com; " +
        "font-src 'self' https://use.fontawesome.com data:; " +
        "img-src 'self' data: https:; " +
        "connect-src 'self' https://www.google-analytics.com https://region1.google-analytics.com https://storage.ko-fi.com; " +
        "frame-src https://storage.ko-fi.com; " +
        "base-uri 'self'; " +
        "form-action 'self' https://*.auth0.com; " +
        "frame-ancestors 'none'");
    await next();
});

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var safeReturnUrl = GetSafeReturnUrl(returnUrl);
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(safeReturnUrl)
            .Build();

    await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();

    await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static string GetSafeReturnUrl(string? returnUrl)
{
    if (string.IsNullOrWhiteSpace(returnUrl))
    {
        return "/";
    }

    // Local relative paths only: "/..." but not "//host" or "/\..."
    if (returnUrl[0] == '/'
        && (returnUrl.Length == 1 || (returnUrl[1] != '/' && returnUrl[1] != '\\'))
        && !returnUrl.Contains('\\', StringComparison.Ordinal))
    {
        return returnUrl;
    }

    return "/";
}

