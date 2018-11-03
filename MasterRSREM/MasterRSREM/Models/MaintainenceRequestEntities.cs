using System;
using System.Collections.Generic;
using System.Text;

namespace MasterRSREM.Models
{
    public class MaintainenceRequestEntities
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Category { get; set; }
        public string RequestDescription { get; set; }
        public string AccessInstructions { get; set; }
        public byte[] VoiceRequest { get; set; }
        public byte[] RequestImage1 { get; set; }

        public byte[] RequestImage2 { get; set; }
        public byte[] RequestImage3 { get; set; }
        public byte[] RequestImage4 { get; set; }
        public byte[] RequestImage5 { get; set; }


        public DateTime RequestDate { get; set; }

        public string Status { get; set; }
    }
}
