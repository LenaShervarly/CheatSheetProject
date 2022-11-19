using System;
using System.Data.SQLite;
using System.Linq;
using System.Xml.Linq;
using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class TopicRepository
    {
        private static readonly string topic = "Topic";
        public TopicRepository()
        {
        }

        public static void AddNewTopic(string topicName)
        {
            var id = Guid.NewGuid();
            SQLTableManagement.InsertData(topic, "Id, Name", $"\"{id}\", \"{topicName}\"");
        }

        public static List<Topic> GetAllTopics()
        {
            var allTopics = new List<Topic>();

            var sqlite_datareader = SQLTableManagement.ReadData(topic, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                allTopics.Add(new Topic
                {
                    id = id,
                    name = name
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allTopics;
        }

        public static Topic? GetTopic(string id)
        {
            var clause = $"id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(topic, clause);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);
                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new Topic
                {
                    id = id,
                    name = name
                };
            }

            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static Topic? GetTopicWithAllItems(string id)
        {
            var statement = "SELECT Topic.Id AS TopicId, Topic.Name, CheetSheetItem.Id AS ItemId, CheetSheetItem.Name, CheetSheetItem.CodeSnippet, " +
                "CheetSheetItem.AdditionalInfo, UsefulLink.Id AS LinkId, UsefulLink.LinkAddress, UsefulLink.LinkOrder" +
                "\nFROM Topic\nLEFT JOIN CheetSheetItem ON Topic.Id = CheetSheetItem.TopicId" +
                "\nLEFT JOIN UsefulLink ON CheetSheetItem.Id = UsefulLink.CheetSheetItemID " +
                $"WHERE Topic.Id = \"{id}\";";
            var sqlite_datareader = SQLTableManagement.ReadCusomData(statement);
            Topic topic = null;
            var cheatSheetItems = new LinkedList<CheatSheetItem>();
            while (sqlite_datareader.Read())
            {
                var topicId = sqlite_datareader.GetString(0);
                var topicName = sqlite_datareader.GetString(1);

                CheatSheetItem item = null;
                if (sqlite_datareader[2] != DBNull.Value)
                {
                    var itemId = sqlite_datareader.GetString(2);

                    if (cheatSheetItems.Where(i => i.id == itemId).Count() > 0)
                    {
                        item = cheatSheetItems.Where(i => i.id == itemId).First();
                    } else
                    {
                        var itemName = sqlite_datareader.GetString(3);
                        var itemCode = sqlite_datareader.GetString(4);
                        var aditionInfo = sqlite_datareader.GetString(5);

                        item = new CheatSheetItem
                        {
                            id = itemId,
                            name = itemName,
                            codeSnippet = itemCode,
                            additionalInfo = aditionInfo
                        };
                        cheatSheetItems.AddLast(item);
                    }
                    
                    UsefulLink link = null;
                    if (sqlite_datareader[6] != DBNull.Value)
                    {
                        var linkId = sqlite_datareader.GetString(6);
                        var address = sqlite_datareader.GetString(7);
                        var order = sqlite_datareader.GetInt32(8);
                        link = new UsefulLink
                        {
                            id = linkId,
                            linkAddress = address,
                            linkOrder = order
                        };
                        item.usefulLinks.Add(link);
                    }
                }

                if (topic == null)
                {
                    topic = new Topic
                    {
                        id = topicId,
                        name = topicName
                    };
                }
                if(item != null)
                {
                    if (!topic.cheetSheetItems.Contains(item))
                    {
                        topic.cheetSheetItems.Add(item);
                    }
                }
                
            }
            return topic;
        }

        public static void UpdateNameById(string id, string name)
        {
            var clause = $"id = \"{id}\"";
            var setName = $"name = \"{name}\"";
            SQLTableManagement.UpdatetData(topic, setName, clause);
        }

        public static void DeleteTopicById(string id)
        {
            var clause = $"id = \"{id}\"";
            SQLTableManagement.DeletetData(topic, clause);
        }

        public static void DeleteTopicByName(string name)
        {
            var clause = $"name = \"{name}\"";
            SQLTableManagement.DeletetData(topic, clause);
        }
    }
}

