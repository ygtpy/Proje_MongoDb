using AkademiQMongoDb.Services.AdminServices;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.BannerServices;
using AkademiQMongoDb.Services.ContactServices;
using AkademiQMongoDb.Services.FeatureServices;
using AkademiQMongoDb.Services.GalleryServices;
using AkademiQMongoDb.Services.MessageServices;
using AkademiQMongoDb.Services.ServiceServices;
using AkademiQMongoDb.Services.TeamServices;
using AkademiQMongoDb.Services.TeamsSocialLinkServices;
using AkademiQMongoDb.Services.TestimonialServices;
using AkademiQMongoDb.Services.WhyUsServices;
using AkademiQMongoDb.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));


// Service Registration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamsSocialLinkService, TeamsSocialLinkService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IWhyUsService, WhyUsService>();


builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.LoginPath = "/Login/Index";
        config.LogoutPath = "/Login/Logout";
        config.Cookie.Name = "LezzetMutfagiCookie";
        config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        config.SlidingExpiration = true;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
