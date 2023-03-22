using System.ComponentModel.DataAnnotations;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.DTOs.Responses
{
    public class Response
    {
        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string Status { set; get; }

        public string Message { set; get; }

        public object Data { get; set; }
    }

    public static class StatusResponse
    {
        public const string Success = "Success";
        public const string Failed = "Failed";
    }
}
