using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using System.ComponentModel.DataAnnotations;

namespace Freelancing.Pages.Services
{
    public class RequestPaymentModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public RequestPaymentModel(FreelancingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Service Service { get; set; } = default!;
        public string? Message { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [Phone]
            public string PhoneNumber { get; set; } = string.Empty;

            [StringLength(500)]
            public string ProjectDetails { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string PaymentMethod { get; set; } = string.Empty;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id && m.IsActive);
            if (service == null)
            {
                return NotFound();
            }

            Service = service;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            
            Service = service;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find or create user
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
            if (user == null)
            {
                user = new User
                {
                    Name = Input.Name,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    IsAdmin = false
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            // Create payment record
            var payment = new Payment
            {
                Info = $"Service: {Service.Name}. Details: {Input.ProjectDetails}",
                UserId = user.Id,
                ServiceId = Service.Id,
                Amount = Service.Price,
                Status = "Pending",
                PaymentMethod = Input.PaymentMethod
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            Message = "Your payment request has been submitted! I'll contact you within 24 hours to discuss the project details and payment process.";
            ModelState.Clear();
            Input = new();

            return Page();
        }
    }
}