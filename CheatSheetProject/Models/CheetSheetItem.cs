using System;
namespace CheatSheetProject.Models
{
    public class CheetSheetItem
    {
        public string id { get; set; }

        public string name { get; set; }

        public string codeSnippet { get; set; }

        public string additionalInfo { get; set; }

        public List<UsefulLink> usefulLinks { get; set; }

        public int orderNumber { get; set; }


        public CheetSheetItem()
        {
            usefulLinks = new List<UsefulLink>();
        }
    }
}

