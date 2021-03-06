﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RIMSYSMasterRSREMWebServices.Models
{
    public class RIMSYSMasterRSREMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RIMSYSMasterRSREMContext() : base("name=RIMSYSMasterRSREMContext")
        {
        }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.Categories> Categories { get; set; }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.AnnouncementItems> AnnouncementItems { get; set; }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.MaintainenceRequestEntities> MaintainenceRequestEntities { get; set; }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.Events> Events { get; set; }

        public System.Data.Entity.DbSet<RIMSYSMasterRSREMWebServices.Models.ClubHouseTable> ClubHouseTables { get; set; }
    }
}
