using System.ComponentModel.DataAnnotations;

namespace Freelancing.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Info { get; set; } = string.Empty;
        
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
        
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed
        
        [StringLength(100)]
        public string PaymentMethod { get; set; } = string.Empty;
        
        // Navigation properties
        public User User { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}