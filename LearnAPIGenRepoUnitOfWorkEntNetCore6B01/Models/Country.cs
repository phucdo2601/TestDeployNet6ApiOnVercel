using System;
using System.Collections.Generic;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models
{
    public partial class Country
    {
        public int Id { get; set; }
        public string? Ccode { get; set; }
        public string? Cname { get; set; }
        public string? Ctype { get; set; }
        public long? Cflag { get; set; }
    }
}
