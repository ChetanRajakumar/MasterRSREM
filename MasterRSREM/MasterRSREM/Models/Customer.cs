﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
 
        public string PhoneNumber { get; set; }

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
