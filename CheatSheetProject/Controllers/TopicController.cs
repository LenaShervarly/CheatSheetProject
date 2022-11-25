using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CheatSheetProject.Models;
using CheatSheetProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheatSheetProject.Controllers
{
    [Route("api/topic")]
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Topic> GetAllTopics()
        {
            return TopicRepository.GetAllTopics();
        }

        [HttpGet("{topicId}")]
        public Topic? GetDetailedTopicData(string topicId)
        {
            return TopicRepository.GetTopicWithAllItems(topicId);
        }

        [HttpPost]
        public void CreateNewTopic([FromBody] Topic topic)
        {
            TopicRepository.AddNewTopic(topic.name);
        }

        [HttpDelete("{id}")]
        public void DeleteTopic(string id)
        {
            TopicRepository.DeleteTopicById(id);
        }

        [HttpPut("{id}")]
        public Topic? UpdateTopic(string id, [FromBody] string name)
        {
            TopicRepository.UpdateNameById(id, name);
            return TopicRepository.GetTopicWithAllItems(id);
        }
    }
}