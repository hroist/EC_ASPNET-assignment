using merketo.Contexts;
using merketo.Models.Identity;
using merketo.Repositories;
using merketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Services;
using WebApp.Contexts;
using WebApp.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketoDB")));
builder.Services.AddDbContext<ProductContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketoDB")));


builder.Services.AddScoped<ProfileRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<CollectionService>();
builder.Services.AddScoped<ProfileService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddRoles<IdentityRole>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();
    
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/account/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
