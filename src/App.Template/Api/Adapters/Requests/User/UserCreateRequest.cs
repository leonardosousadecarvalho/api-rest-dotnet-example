namespace App.Template.Api.Adapters.Requests.User
{
    public class UserCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserCreateRequest(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;

        }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.FirstName) || string.IsNullOrEmpty(this.LastName) || string.IsNullOrEmpty(this.Email))
            {
                return false;
            }
            return true;
        }
    }
}