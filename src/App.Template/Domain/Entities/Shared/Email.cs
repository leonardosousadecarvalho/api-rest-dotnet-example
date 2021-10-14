using System;

namespace App.Template.Domain.Entities.Shared
{
    public class Email
    {
        public string Value { get; private set; }
        public Email(string value)
        {
            this.Validate(value);
            this.Value = value;
        }
        private void Validate(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length < 7)
            {
                throw new ArgumentException("Email field cannot be empty or less then 7 characters.");
            }
        }
    }
}