using System;
using System.Collections.Generic;
using System.Text;

namespace RIMSYSMasterRSREMWebServices.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
 
        public string PhoneNumber { get; set; }

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public string GovernmentIdentityType { get; set; }
        public string GovernmentIdentityNumber { get; set; }
        public byte[] ProfilePic { get; set; }
        public byte[] RentalAgreementDocument { get; set; }

        

    }
}
