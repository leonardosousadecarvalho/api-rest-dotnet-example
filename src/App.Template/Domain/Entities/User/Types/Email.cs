using System;

namespace App.Template.Domain.Entities.User.Types
{
    public class Email
    {
        public string Value { get; set; }
        public Email(string value)
        {

            if (this.Validate(value)) this.Value = value;
        }
        private bool Validate(string value)
        {
            if (value == null || value == "" || value.Length < 5)
            {
                throw new ArgumentException("Email field cannot be empty or less then 7 characters.");
            }

            return true;
        }
    }
}