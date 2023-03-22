using System;
using System.Collections.Generic;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models
{
    public partial class BookingInfo
    {
        public int CbId { get; set; }
        public DateTime? CbStartDate { get; set; }
        public DateTime? CbEndDate { get; set; }
        public string? CbStaff { get; set; }
        public string? CbStaffNo { get; set; }
        public string? CbOrg { get; set; }
        public int? CbCostCenterId { get; set; }
        public string? CbCustomer { get; set; }
        public int? CbNumberofPassenger { get; set; }
        public string? CbDeparrturePlace { get; set; }
        public string? CbDestinationPlace { get; set; }
        public int? CbUserId { get; set; }
        public int? CbCarId { get; set; }
        public int? CbBucid { get; set; }
        public int? CbDriverId { get; set; }
        public DateTime? CbCreatedOn { get; set; }
        public DateTime? CbLastUpdate { get; set; }
        public string? CbStatus { get; set; }
        public string? CbRemarks { get; set; }
    }
}
