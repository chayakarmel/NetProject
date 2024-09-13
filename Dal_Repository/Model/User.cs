using System;
using System.Collections.Generic;

namespace Dal_Repository.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
