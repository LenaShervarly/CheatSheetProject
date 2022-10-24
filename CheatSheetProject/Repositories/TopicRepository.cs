using System;
using System.Data.SQLite;
using System.Xml.Linq;
using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class TopicRepository
    {
        public TopicRepository()
        {
        }

        public static void AddNewTopic(string topicName)
        {
            var id = Guid.NewGuid();
            SQLTableManagement.InsertData("Topic", "Id, Name", $"\"{id}\", \"{topicName}\"");
        }

        public static List<Topic> GetAllTopics()
        {
            var allTopics = new List<Topic>();

            var sqlite_datareader = SQLTableManagement.ReadData("Topic", null);
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
            SQLTableManagement.GetSQLiteConnection().Close();
            return allTopics;
        }

        public static Topic? GetTopic(string id)
        {
            SQLTableManagement.GetSQLiteConnection().Open();
            var clause = $"id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData("Topic", clause);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);
                SQLTableManagement.GetSQLiteConnection().Close();
                return new Topic
                {
                    id = id,
                    name = name
                };
            }
            SQLTableManagement.GetSQLiteConnection().Close();
            return null;
        }
    }
}

