using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStationsRepository, StationsRepository>();
builder.Services.AddScoped<ITripsRepository, TripsRepository>();
builder.Services.AddScoped<ISingleTripRepository, SingleTripRepository>();

builder.Services.AddScoped<StationsService>();
builder.Services.AddScoped<TripsService>();
builder.Services.AddScoped<SingleTripService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Index}/{action=Index}/{id?}"
);

app.Run();