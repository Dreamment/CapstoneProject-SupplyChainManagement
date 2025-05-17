using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.DataTransferObjects.Create
{
    public record CreateBidDTO
    {
        [Required]
        public int TenderId { get; set; } = default;

        [AllowNull]
        public string? SupplierName { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; } = default;
    }
}
