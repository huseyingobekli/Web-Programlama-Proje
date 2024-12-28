using System;
using System.ComponentModel.DataAnnotations;

namespace webprogramlama4.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Role { get; set; } = "User"; // Varsayılan olarak "User" rolü veriyoruz.
    }

}

