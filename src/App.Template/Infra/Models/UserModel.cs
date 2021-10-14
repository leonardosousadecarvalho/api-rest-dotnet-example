using System;
using App.Template.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Template.Infra.Models
{
    public class UserModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; private set; }

        [Column("firstName")]
        public string FirstName { get; private set; }

        [Column("lastName")]
        public string LastName { get; private set; }

        [Column("email")]
        public string Email { get; private set; }
        public void SetFirstName(string firstName)
        {
            this.FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            this.LastName = lastName;
        }
        public void SetEmail(string email)
        {
            this.Email = email;
        }
        public static UserModelBuilder Builder() => new UserModelBuilder();
        public class UserModelBuilder
        {
            public string Id { get; private set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
            public UserModelBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserModelBuilder WithFirstName(string firstName)
            {
                this.FirstName = firstName;
                return this;
            }

            public UserModelBuilder WithLastName(string lastName)
            {
                this.LastName = lastName;
                return this;
            }
            public UserModelBuilder WithEmail(string email)
            {
                this.Email = email;
                return this;
            }
            public UserModel Build()
            {
                return new UserModel
                {
                    Id = ApiConverter.ToGuid(this.Id),
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Email = this.Email,
                };
            }
            public UserModel BuildWithoutId()
            {
                return new UserModel
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Email = this.Email,
                };
            }
        }
    }
}