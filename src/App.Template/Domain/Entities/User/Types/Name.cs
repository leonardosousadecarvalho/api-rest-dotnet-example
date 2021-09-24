
using System;

namespace App.Template.Domain.Entities.User.Types
{
    public class Name
    {
        public string Value { get; set; }
        public Name(string value)
        {
            if (this.Validate(value)) this.Value = value;
        }
        private bool Validate(string value)
        {
            if (value == null || value == "" || value.Length < 4) 
            {
                throw new ArgumentException("Name field cannot be empty or less then 4 characters.");
            }
            return true;
        }
    }
}