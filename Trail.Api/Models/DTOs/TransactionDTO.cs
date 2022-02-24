using System.ComponentModel.DataAnnotations;

namespace Trail.Api.Models.DTOs
{
    public class TransactionDTO
    {
        [Required]
        public int AccountNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "field must be atleast 3 characters")]

        public string Currency { get; set; }
    }
}
