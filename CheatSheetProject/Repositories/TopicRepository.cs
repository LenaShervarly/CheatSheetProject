using System;
using System.Data.SQLite;
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
            CloseConnections(sqlite_datareader);
            return allTopics;
        }

        public static Topic? GetTopic(string id)
        {
            var clause = $"id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(topic, clause);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);
                CloseConnections(sqlite_datareader);
                return new Topic
                {
                    id = id,
                    name = name
                };
            }

            CloseConnections(sqlite_datareader);
            return null;
        }

        public static void UpdateNameById(string id, string name)
        {
            var clause = $"id = \"{id}\"";
            var setName = $"name = \"{name}\"";
            SQLTableManagement.UpdatetData(topic, setName, clause);
        }

        private static void CloseConnections(SQLiteDataReader sqlite_datareader)
        {
            sqlite_datareader.Close();
            SQLTableManagement.GetSQLiteConnection().Close();
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

