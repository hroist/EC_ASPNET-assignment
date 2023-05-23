using merketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class ContactsViewModel
{
    [Required(ErrorMessage = "Enter your name")]
    [Display(Name = "Your name *")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Your email *")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Your phone number (optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Your company name (optional)")]
    public string? Company { get; set; }

    [Required(ErrorMessage = "Enter a message")]
    [Display(Name = "Message *")]
    public string Message { get; set; } = null!; 

    public bool SaveInfo { get; set; } = false;

    public static implicit operator MessageEntity(ContactsViewModel contactsViewModel)
    {
        return new MessageEntity
        {
            Name = contactsViewModel.Name,
            Email = contactsViewModel.Email,
            PhoneNumber = contactsViewModel.PhoneNumber,
            CompanyName = contactsViewModel.Company,
            Message = contactsViewModel.Message
        };
    }
}
