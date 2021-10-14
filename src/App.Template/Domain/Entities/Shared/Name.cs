
using System;

namespace App.Template.Domain.Entities.Shared
{
    public class Name
    {
        public string Value { get; private set; }
        public Name(string value)
        {
            this.Validate(value);
            this.Value = value;
        }
        private void Validate(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length < 4)
            {
                throw new ArgumentException("Name field cannot be empty or less then 4 characters.");
            }
        }
    }
}