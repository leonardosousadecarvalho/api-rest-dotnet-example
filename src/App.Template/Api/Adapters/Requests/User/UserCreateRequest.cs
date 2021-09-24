namespace App.Template.Api.Adapters.Requests.User
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserCreateRequest(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}