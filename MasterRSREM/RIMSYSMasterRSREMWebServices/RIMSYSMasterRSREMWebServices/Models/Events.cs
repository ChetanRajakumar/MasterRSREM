using System;
using System.Collections.Generic;
using System.Text;

namespace RIMSYSMasterRSREMWebServices.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public byte[] EventPic1 { get; set; }
        public byte[] EventPic2 { get; set; }
        public byte[] EventPic3 { get; set; }
        public byte[] EventPic4 { get; set; }
        public byte[] EventPic5 { get; set; }

        

    }
}
