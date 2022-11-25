using System;
namespace CheatSheetProject.Models
{
    public class CheatSheetItem
    {
        public string id { get; set; }

        public string name { get; set; }

        public string codeSnippet { get; set; }

        public string additionalInfo { get; set; }

        public List<UsefulLink> usefulLinks { get; set; }

        public DateTime dateCreated { get; set; }

        public CheetSheetItem()
        {
            usefulLinks = new List<UsefulLink>();
        }
    }
}

