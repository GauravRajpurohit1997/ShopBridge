using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Model
{
    public class ItemContext: DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options): base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
