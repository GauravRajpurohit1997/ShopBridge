using ShopBridge.Controllers;
using ShopBridge.Repository;
using Xunit;

namespace ShopBridge__Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ItemRepository itemRepository = new ItemRepository();
            InventoryController inventory = new InventoryController(itemRepository);
        }
    }
}