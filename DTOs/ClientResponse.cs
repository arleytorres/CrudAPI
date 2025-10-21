namespace CrudJWT.DTOs
{
    public record ClientResponse(Guid Id, string firstName, string lastName, int age, string phoneNumber);
}
