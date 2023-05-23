using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace merketo.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }

    public DbSet<ProfileEntity> AspNetProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var userId = Guid.NewGuid().ToString();
        var roleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = roleId,
            Name = "SystemAdministrator",
            NormalizedName = "SYSTEMADMINISTRATOR"

        });

        var passwordHasher = new PasswordHasher<AppUser>();
        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = userId,
            FirstName = "system",
            LastName = "admin",
            UserName = "admin",
            NormalizedUserName ="ADMIN",
            Email = "admin",
            NormalizedEmail = "ADMIN",
            PasswordHash = passwordHasher.HashPassword(null!, "Password123")

        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = roleId,
            UserId = userId
        });

        builder.Entity<ProfileEntity>().HasData(new ProfileEntity
        {
            UserId = userId,
            StreetName = "admin",
            PostalCode = "admin",
            City = "admin",

        });
    }
}
