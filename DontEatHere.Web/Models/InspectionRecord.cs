using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DontEatHere.Web.Models
{
    public class InspectionRecord
    {
        public int InspectionRecordId { get; set; }
        public string FacilityName { get; set; }
        public string InspectionDate { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
    }
}
