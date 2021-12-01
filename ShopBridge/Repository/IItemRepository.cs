using ShopBridge.Model;

namespace ShopBridge.Repository
{
    public interface IItemRepository
    {
        public Task<Item> Add(Item item);
        public Task<Item> Update(Item item);
        public Task Delete(Item item);
        public Task<Item> Get(Item item);
        public Task<List<Item>> GetAllItems();
    }
}
