using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class AnnouncementItems
    {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            
    }
}
