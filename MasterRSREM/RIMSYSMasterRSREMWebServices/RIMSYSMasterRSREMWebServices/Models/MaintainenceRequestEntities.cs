using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIMSYSMasterRSREMWebServices.Models
{
    public class MaintainenceRequestEntities
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Category { get; set; }
        public string RequestDescription { get; set; }
        public string AccessInstructions { get; set; }
        public byte[] VoiceRequest { get; set; }
        public byte[] ImagesList { get; set; }

        public DateTime RequestDate { get; set; }

        public string Status { get; set; }
    }
}