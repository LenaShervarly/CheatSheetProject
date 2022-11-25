using System;
using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class CheatSheetItemRepository
    {
        private static readonly string cheatSheetItemTable = "CheetSheetItem";
        public CheatSheetItemRepository()
        {
        }

        public static void AddNewCheatSheetItem(CheatSheetItem cheatSheetItem, string? topicId)
        {
            string id;
            if(cheatSheetItem.id == null)
            {
                id = Guid.NewGuid().ToString();
            } else
            {
                id = cheatSheetItem.id;
            }
      
            SQLTableManagement.InsertData(cheatSheetItemTable, "Id, Name, CodeSnippet, AdditionalInfo, TopicId",
                $"\"{id}\", \"{cheatSheetItem.name}\", \"{cheatSheetItem.codeSnippet}\", \"{cheatSheetItem.additionalInfo}\", \"{topicId}\"");
        }

        public static void DeleteItemById(string id)
        {
            var clause = $"id = \"{id}\"";
            SQLTableManagement.DeletetData(cheatSheetItemTable, clause);
        }


        public static void UpdateItemById(string id, CheatSheetItem cheatSheetItem)
        {
            var whereClause = $"id = \'{id}\'";
            var setClause = "";
            if(cheatSheetItem.name != null)
            {
                setClause += $"Name = \"{cheatSheetItem.name}\", ";
            }
            setClause += $"CodeSnippet = \"{cheatSheetItem.codeSnippet}\", ";
            setClause += $"AdditionalInfo = \"{cheatSheetItem.additionalInfo}\"";

            SQLTableManagement.UpdatetData(cheatSheetItemTable, setClause, whereClause);
        }

        public static List<CheatSheetItem> GetAllItems()
        {
            var allCheatSheetItems = new List<CheatSheetItem>();

            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);
                allCheatSheetItems.Add(new CheatSheetItem
                {
                    id = id,
                    name = name,
                    codeSnippet = codeSnippet,
                    additionalInfo = additionalInfo
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allCheatSheetItems;
        }

        public static CheatSheetItem? GetItem(string id)
        {
            var clause = $"id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, clause);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);
                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new CheatSheetItem
                {
                    id = id,
                    name = name,
                    codeSnippet = codeSnippet,
                    additionalInfo = additionalInfo
                };
            }

            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static List<CheatSheetItem> GetAllItemsByTopicId(string topicId)
        {
            var allCheatSheetItemsForTopic = new List<CheatSheetItem>();
            var clause = $"TopicId = \"{topicId}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, clause);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);
                allCheatSheetItemsForTopic.Add(new CheatSheetItem
                {
                    id = id,
                    name = name,
                    codeSnippet = codeSnippet,
                    additionalInfo = additionalInfo
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allCheatSheetItemsForTopic;
        }
    }
}

