using System;
using System.Data.SQLite;
using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class Migrations
    {
        public Migrations()
        {
        }

        public static void run()
        {
            SQLTableManagement.ExecuteSQL("DROP TABLE Topic");
            SQLTableManagement.ExecuteSQL("CREATE TABLE Topic (Id VARCHAR(20), Name VARCHAR(200), PRIMARY KEY (ID));");
            SQLTableManagement.ExecuteSQL("DROP TABLE CheetSheetItem");
            SQLTableManagement.ExecuteSQL("CREATE TABLE CheetSheetItem (Id VARCHAR(20) not null, Name VARCHAR(200), CodeSnippet TEXT, AdditionalInfo  TEXT, TopicId VARCHAR(20), \nPRIMARY KEY (ID),\nFOREIGN KEY(TopicId) REFERENCES Topic(Id));");
            SQLTableManagement.ExecuteSQL("DROP TABLE UsefulLink");
            SQLTableManagement.ExecuteSQL("CREATE TABLE UsefulLink (Id VARCHAR(20) NOT NULL, LinkAddress VARCHAR(200), LinkOrder INT, CheetSheetItemID VARCHAR(20),\nPRIMARY KEY (Id), FOREIGN KEY (CheetSheetItemID) REFERENCES CheetSheetItem(Id));");
        }
    }
}

