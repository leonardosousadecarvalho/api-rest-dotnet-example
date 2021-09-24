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
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }
        public static UserModelBuilder Builder() => new UserModelBuilder();
        public class UserModelBuilder
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public UserModelBuilder WithId(string id)
            {
                this.Id = id;
                return this;
            }
            public UserModelBuilder WithName(string name)
            {
                this.Name = name;
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
                    Name = this.Name,
                    Email = this.Email
                };
            }
        }
    }
}