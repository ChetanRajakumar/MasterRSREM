using MasterRSREM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRSREM.Models
{

    public class MasterHomePageMenuItem
    {
        public MasterHomePageMenuItem()
        {
            TargetType = typeof(MasterHomePageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        
    }
}