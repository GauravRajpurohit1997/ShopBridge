using Microsoft.EntityFrameworkCore;
using ShopBridge.Model;

namespace ShopBridge.Repository
{
    public class ItemRepository : IItemRepository
    {
        private ItemContext _itemContext;

        public ItemRepository()
        {
        }

        public ItemRepository(ItemContext itemContext)
        {
            _itemContext = itemContext;
        }

        public async Task<Item> Add(Item item)
        {
            _itemContext.Items.Add(item);
            await _itemContext.SaveChangesAsync();
            return item;
        }

        public async Task Delete(Item item)
        {
            _itemContext.Items.Remove(item);
            await _itemContext.SaveChangesAsync();
        }

        public async Task<Item> Get(Item item)
        {
            return await _itemContext.Items.SingleOrDefaultAsync(x => x.Equals(item));
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemContext.Items.ToListAsync<Item>();
        }

        public async Task<Item> Update(Item item)
        {
            _itemContext.Items.Update(item);
            await _itemContext.SaveChangesAsync();
            return item;
        }
    }
}
