namespace App.Template.Api.Adapters.Response
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public static UserResponseBuilder Builder() => new UserResponseBuilder();
        public class UserResponseBuilder
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public UserResponseBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserResponseBuilder WithName(string name)
            {
                this.Name = name;
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
                    Name = this.Name,
                    Email = this.Email
                };
            }
        }
    }
}