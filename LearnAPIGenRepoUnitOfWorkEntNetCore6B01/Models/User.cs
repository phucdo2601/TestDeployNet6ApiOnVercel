using System;
using System.Collections.Generic;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models
{
    public partial class User
    {
        public int Uid { get; set; }
        public string? UserName { get; set; }
        public int? UserTypeId { get; set; }
        public long? BlackListed { get; set; }
        public string? BcId { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailAddress { get; set; }
    }
}
