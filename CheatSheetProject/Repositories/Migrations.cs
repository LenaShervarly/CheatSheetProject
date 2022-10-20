using System;
using System.Data.SQLite;

namespace CheatSheetProject.Repositories
{
    public class Migrations
    {
        public Migrations()
        {
        }

        public static void run()
        {
            SQLTableManagement.CreateTable("CREATE TABLE Topic (Id VARCHAR(20), Name VARCHAR(200))");
            SQLTableManagement.CreateTable("CREATE TABLE CheetSheetItem (Id VARCHAR(20), Name VARCHAR(200), CodeSnippet TEXT, AdditionalInfo  TEXT, TopicId VARCHAR(20))");
            SQLTableManagement.CreateTable("CREATE TABLE UsefulLink (Id VARCHAR(20), LinkAddress VARCHAR(200), LinkOrder INT, CheetSheetItemID VARCHAR(20))");
        }
    }
}

