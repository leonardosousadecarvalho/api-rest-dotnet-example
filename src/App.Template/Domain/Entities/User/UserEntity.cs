using App.Template.Domain.Entities.User.Types;

namespace App.Template.Domain.Entities.User
{
    public class UserEntity
    {
        public Id Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public static UserEntityBuilder Builder() => new UserEntityBuilder();
        public class UserEntityBuilder
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public UserEntityBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserEntityBuilder WithName(string name)
            {
                this.Name = name;
                return this;
            }
            public UserEntityBuilder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }
            public UserEntity Build()
            {
                return new UserEntity
                {
                    Id = new Id(this.Id),
                    Name = new Name(this.Name),
                    Email = new Email(this.Email)
                };
            }
            public UserEntity BuildWithoutId()
            {
                return new UserEntity
                {
                    Name = new Name(this.Name),
                    Email = new Email(this.Email)
                };
            }
        }
    }
}