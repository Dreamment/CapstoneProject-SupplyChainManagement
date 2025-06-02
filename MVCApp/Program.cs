using MVCApp.Infrastructure.Extensions;
using Repositories.Contracts;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureCustomServices();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var serviceProvider = app.Services.CreateScope().ServiceProvider;
ServiceExtensions.AddInitialPassword(serviceProvider.GetRequiredService<IRepositoryManager>()).Wait();

app.Run();
