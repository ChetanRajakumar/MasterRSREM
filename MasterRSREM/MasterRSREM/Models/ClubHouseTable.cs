using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class ClubHouseTable
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }

        public string PaymentStatus { get; set; }

    }
}
