using System;
namespace CheatSheetProject.Models
{
    public class UsefulLink
    {

        public string id { get; set; }

        public string linkAddress { get; set; }

        public int? linkOrder { get; set; }

        public string cheatSheetItemId { get; set; }

        public DateTime dateCreated { get; set; }

        public UsefulLink()
        {
        }
    }
}

