using System;
using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class UsefulLinksRepository
    {
        private static readonly string usefulLinkTable = "UsefulLink";
        public UsefulLinksRepository()
        {
        }

        public static void AddUsefulLink(UsefulLink usefulLink, string? cheatSheetItemId)
        {
            var id = Guid.NewGuid();
            SQLTableManagement.InsertData(usefulLinkTable, "Id, LinkAddress, LinkOrder, CheetSheetItemID",
                $"\"{id}\", \"{usefulLink.linkAddress}\", \"{usefulLink.linkOrder}\", \"{cheatSheetItemId}\"");
        }

        public static void DeleteLinkById(string id)
        {
            var clause = $"id = \"{id}\"";
            SQLTableManagement.DeletetData(usefulLinkTable, clause);
        }


        public static void UpdateLinkById(string id, UsefulLink link)
        {
            var whereClause = $"id = \"{id}\"";
            var setClause = "";
            if (link.linkOrder != null)
            {
                setClause += $"LinkOrder = \"{link.linkOrder}\", ";
            }
            if (link.cheatSheetItemId != null)
            {
                setClause += $"CheetSheetItemID = \"{link.cheatSheetItemId}\", ";
            }
            setClause += $"LinkAddress = \"{link.linkAddress}\"";
           
            SQLTableManagement.UpdatetData(usefulLinkTable, setClause, whereClause);
        }

        public static List<UsefulLink> GetAllLinks()
        {
            var allUsefulLinks = new List<UsefulLink>();

            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinkTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheetSheetItemID = sqlite_datareader.GetString(3);
                allUsefulLinks.Add(new UsefulLink
                {
                    id = id,
                    linkAddress = linkAddress,
                    linkOrder = linkOrder,
                    cheatSheetItemId = cheetSheetItemID
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allUsefulLinks;
        }

        public static UsefulLink? GetItem(string id)
        {
            var clause = $"id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinkTable, clause);
            while (sqlite_datareader.Read())
            {
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheetSheetItemID = sqlite_datareader.GetString(3);
                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new UsefulLink
                {
                    id = id,
                    linkAddress = linkAddress,
                    linkOrder = linkOrder,
                    cheatSheetItemId = cheetSheetItemID
                };
            }

            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static List<UsefulLink> GetAllUsefulLinksByItemId(string cheatSheetItemId)
        {
            var linksByItem = new List<UsefulLink>();
            var clause = $"CheetSheetItemID = \"{cheatSheetItemId}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinkTable, clause);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheetSheetItemID = sqlite_datareader.GetString(3);
                linksByItem.Add(new UsefulLink
                {
                    id = id,
                    linkAddress = linkAddress,
                    linkOrder = linkOrder,
                    cheatSheetItemId = cheetSheetItemID
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return linksByItem;
        }

        public static void DeleteByCheatSheetItemId(string cheatSheetItemId)
        {
            var clause = $"cheatSheetItemId = \"{cheatSheetItemId}\"";
            SQLTableManagement.DeletetData(usefulLinkTable, clause);
        }
    }
}

