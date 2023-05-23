using merketo.Contexts;
using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels;

namespace merketo.Services;

public class MessageService
{

    private readonly MessageContext _messageContext;

    public MessageService(MessageContext messageContext)
    {
        _messageContext = messageContext;
    }

    public async Task<bool> SaveMessageAsync(ContactsViewModel contactsViewModel)
    {
        try
        {
            MessageEntity messageEntity = contactsViewModel;
            _messageContext.Messages.Add(messageEntity);
            await _messageContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<MessageEntity>> GetAllAsync()
    {
        try
        {
            var messages = await _messageContext.Messages.ToListAsync();

            return messages;
        }
        catch { return Enumerable.Empty<MessageEntity>(); }

    }
}
