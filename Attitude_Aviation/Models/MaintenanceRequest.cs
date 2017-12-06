using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attitude_Aviation.Models
{
    public class MaintenanceRequest
    {
        public int ID { get; set; }
        public string Plane_name { get; set; }
        public string Problem { get; set; }
        public string Description { get; set; }
    }
}