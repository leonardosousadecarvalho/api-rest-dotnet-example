using System;
using App.Template.Domain.Entities.Shared;

namespace App.Template.Domain.Entities.User
{
    public class UserEntity
    {
        public UserEntity() { this.Id = new Id(Guid.NewGuid()); }
        public Id Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Email Email { get; private set; }
        public static UserEntityBuilder Builder() => new UserEntityBuilder();
        public class UserEntityBuilder
        {
            public string Id { get; private set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
            public UserEntityBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserEntityBuilder WithFirstName(string firstName)
            {
                this.FirstName = firstName;
                return this;
            }
            public UserEntityBuilder WithLastName(string lastName)
            {
                this.LastName = lastName;
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
                    FirstName = new Name(this.FirstName),
                    LastName = new Name(this.LastName),
                    Email = new Email(this.Email)
                };
            }
            public UserEntity BuildWithoutId()
            {
                return new UserEntity
                {
                    FirstName = new Name(this.FirstName),
                    LastName = new Name(this.LastName),
                    Email = new Email(this.Email)
                };
            }
        }
    }
}