using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Freelancing.Models;
using System.ComponentModel.DataAnnotations;

namespace Freelancing.Pages.Contact
{
    public class ContactModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public ContactModel(FreelancingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? ServiceName { get; set; }

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

            [Required]
            [StringLength(1000)]
            public string Message { get; set; } = string.Empty;

            public string? ServiceInterest { get; set; }
        }

        public void OnGet(string? service)
        {
            if (!string.IsNullOrEmpty(service))
            {
                ServiceName = service;
                Input.ServiceInterest = service;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the contact inquiry as a user
            var user = new User
            {
                Name = Input.Name,
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                IsAdmin = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Message = "Thank you for your inquiry! I'll get back to you within 24 hours.";
            ModelState.Clear();
            Input = new();

            return Page();
        }
    }
}