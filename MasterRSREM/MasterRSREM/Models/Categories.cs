using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class Categories
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Category { get; set; }
    }
}
