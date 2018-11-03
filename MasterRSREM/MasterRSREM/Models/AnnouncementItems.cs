﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class AnnouncementItems
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public string EmailId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            
    }
}
