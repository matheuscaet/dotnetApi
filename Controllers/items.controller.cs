using dotnetApi.Models;
using dotnetApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemService;

        public ItemsController(ItemsService itemService)
        {
            this._itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() =>
            this._itemService.Get();

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        public  ActionResult<Item> Get(string id)
        {
            var item = this._itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            this._itemService.Create(item);

            return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Item itemIn)
        {
            var item = this._itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            this._itemService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = this._itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            this._itemService.Remove(id);

            return NoContent();
        }
    }
}