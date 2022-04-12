namespace EcommerceProject.API.Dtos
{
    public class AuthenticateRequest
    {
        public string UserName { get; set; }
        public bool RememberMe { get; set; }
    }
}
