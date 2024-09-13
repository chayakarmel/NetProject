using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LecturerDTO
    {
        public int LecturerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
