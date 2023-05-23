using merketo.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{

    private readonly MessageService _messageService;

    public ContactsController(MessageService messageService)
    {
        _messageService = messageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactsViewModel contactsViewModel)
    {
        if(ModelState.IsValid)
        {
            var messageEntity = await _messageService.SaveMessageAsync(contactsViewModel);
            if(messageEntity)
            {
                return RedirectToAction("Message", "Contacts");
            }

            ModelState.AddModelError("", "Something went wrong when trying to send your message.");
        }
        return View(contactsViewModel);
    }

    public IActionResult Message()
    {
        return View();
    }
}
