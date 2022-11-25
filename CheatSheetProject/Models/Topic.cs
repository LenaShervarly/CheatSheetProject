using System;
namespace CheatSheetProject.Models
{
    public class Topic
    {

        public string id { get; set; }

        public string name { get; set; }

        public List<CheetSheetItem> cheetSheetItems { get; set; }

        public int orderNumber { get; set; }

        public Topic()
        {
            cheetSheetItems = new List<CheetSheetItem>();
        }
    }
}

