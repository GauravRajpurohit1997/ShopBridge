using Microsoft.AspNetCore.Mvc;
using ShopBridge.Model;
using ShopBridge.Repository;
using System.Net;

namespace ShopBridge.Controllers
{
    [Route("inventory")]
    public class InventoryController: ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public InventoryController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddItem(Item item)
        {

            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                Item addedItem = await _itemRepository.Add(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                Item _item = await _itemRepository.Get(item);
                if (_item == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                Item addedItem = await _itemRepository.Update(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                Item _item = await _itemRepository.Get(item);
                if (_item == null) 
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                await _itemRepository.Delete(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<List<Item>> GetItems()
        {
            List<Item> items = await _itemRepository.GetAllItems();
            return items;
        }
    }
}
