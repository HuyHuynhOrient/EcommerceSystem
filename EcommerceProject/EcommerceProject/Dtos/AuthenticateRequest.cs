namespace EcommerceProject.API.Dtos
{
    public class AuthenticateRequest
    {
        public Guid CustomerId { get; init; }
        public string UserName { get; set; }
        public bool RememberMe { get; set; }
    }
}
