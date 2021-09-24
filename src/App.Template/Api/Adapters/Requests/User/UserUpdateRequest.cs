using System;

namespace App.Template.Api.Adapters.Requests.User
{
    public class UserUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserUpdateRequest(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}