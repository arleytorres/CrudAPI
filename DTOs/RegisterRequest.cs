namespace CrudJWT.DTOs
{
    public record RegisterRequest(string username, string password, string confirm_password, string role);
}
