namespace DTO
{
    public class UserDTO
    {

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
