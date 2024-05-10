using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.DAL.Repositories;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IApiRepository, ApiRepository>();
builder.Services.AddScoped<StationsService>();
builder.Services.AddScoped<TripsService>();
builder.Services.AddScoped<SingleTripService>();

builder.Services.Configure<CookiePolicyOptions>(options => {
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

// SASS watcher
#if DEBUG
builder.Services.AddSassCompiler();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Index}/{action=Index}/{id?}"
);

app.Run();