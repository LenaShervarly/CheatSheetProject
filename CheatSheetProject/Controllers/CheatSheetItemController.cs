using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheatSheetProject.Models;
using CheatSheetProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheatSheetProject.Controllers
{
    [Route("api/[controller]")]
    public class CheatSheetItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public CheatSheetItem? GetCheatSheetItem(string id)
        {
            var cheatSheetItem =  CheatSheetItemRepository.GetItem(id);
            if (cheatSheetItem != null)
            {
                var usefulLinks = UsefulLinksRepository.GetAllUsefulLinksByItemId(id);
                cheatSheetItem.usefulLinks = usefulLinks;
            }
            return cheatSheetItem;
        }

        [HttpGet]
        public List<CheatSheetItem> GetAllItems()
        {
            return CheatSheetItemRepository.GetAllItems();
        }

        [HttpGet("topics/{topicId}")]
        public List<CheatSheetItem> GetItemsByTopicId(string topicId)
        {
            return CheatSheetItemRepository.GetAllItemsByTopicId(topicId);
        }

        [HttpDelete("{id}")]
        public void DeleteItem(string id)
        {
            UsefulLinksRepository.DeleteByCheatSheetItemId(id);
            CheatSheetItemRepository.DeleteItemById(id);
        }

        [HttpPut("{id}")]
        public CheatSheetItem? UpdateItem(string id, [FromBody] CheatSheetItem cheatSheetItem)
        {
            CheatSheetItemRepository.UpdateItemById(id, cheatSheetItem);
            return CheatSheetItemRepository.GetItem(id);
        }

        [HttpPost]
        public void CreateNewItem([FromBody] CheatSheetItem cheatSheetItem, [FromQuery] string? topicId)
        {
            CheatSheetItemRepository.AddNewCheatSheetItem(cheatSheetItem, topicId);
            foreach(UsefulLink usefulLink in cheatSheetItem.usefulLinks)
            {
                UsefulLinksRepository.AddUsefulLink(usefulLink, cheatSheetItem.id);
            }
            
        }
    }
}