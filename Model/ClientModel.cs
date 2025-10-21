using CrudJWT.DTOs;

namespace CrudJWT.Model
{
    public class ClientModel
    {
        public Guid Id { get; init; }
        protected string FirstName;
        protected string LastName;
        protected int Age;
        protected string PhoneNumber;

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

        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public int age
        {
            get { return Age; }
            set { Age = value; }
        }

        public string phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }
    }
}
