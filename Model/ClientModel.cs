using CrudJWT.DTOs;

namespace CrudJWT.Model
{
    public class ClientModel
    {
        public Guid Id { get; init; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string PhoneNumber { get; private set; }

        public ClientModel()
        {
            
        }

        public ClientModel(ClientRequest req)
        {
            Id = Guid.NewGuid();
            FirstName = req.firstName;
            LastName = req.lastName;
            Age = req.age;
            PhoneNumber = req.phoneNumber;
        }
    }
}
