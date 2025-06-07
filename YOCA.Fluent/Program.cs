using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.FluentUI.AspNetCore.Components;
using YOCA.DataAccess.DataAccess;
using YOCA.Fluent.Components;
using YOCA.Fluent.Models;
using YOCA.Fluent.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

// Auth0 services
builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

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

builder.Services.AddSingleton<IMarkdownService, MarkdigService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMvcWithDefaultRoute();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(returnUrl)
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
