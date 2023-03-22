using System.ComponentModel.DataAnnotations;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.DTOs.Request
{
    public class UserRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string UserName { get; set; }
        public int? UserTypeId { get; set; }
        public long? BlackListed { get; set; }
        public string? BcId { get; set; }
        public string? MobileNo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string? EmailAddress { get; set; }
    }
}
