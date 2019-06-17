namespace HigoApi.Models.DTO
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}