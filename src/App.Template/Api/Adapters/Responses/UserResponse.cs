namespace App.Template.Api.Adapters.Responses
{
    public class UserResponse
    {
        public string Id { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public static UserResponseBuilder Builder() => new UserResponseBuilder();
        public class UserResponseBuilder
        {
            public string Id { get; private set;}
            public string FirstName { get; private set;}
            public string LastName { get; set;}
            public string Email { get; private set;}
            public UserResponseBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserResponseBuilder WithFirstName(string firstName)
            {
                this.FirstName = firstName;
                return this;
            }
            public UserResponseBuilder WithLastName(string lastName)
            {
                this.LastName = lastName;
                return this;
            }
            public UserResponseBuilder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }
            public UserResponse Build()
            {
                return new UserResponse
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Email = this.Email
                };
            }
        }
    }
}