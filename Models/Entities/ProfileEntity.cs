using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

public class ProfileEntity
{
    [Key, ForeignKey("User")]
    public string UserId { get; set; } = null!;

    public string StreetName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? CompanyName { get; set; }

    public string? ProfilePictureURL { get; set; }

    public AppUser User { get; set; } = null!;
}
