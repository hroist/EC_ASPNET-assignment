using merketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace merketo.Contexts;

public class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {

    }

    public DbSet<MessageEntity> Messages { get; set; }
    
}
