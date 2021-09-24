using System;
using App.Template.Domain.Commons;

namespace App.Template.Domain.Entities.User.Types
{
    public class Id
    {
        public Guid Value { get; set; }
        public Id(Guid value)
        {
            this.Value = value;
        }
        public Id(string value)
        {
            if (this.Validate(value)) this.Value = ApiConverter.ToGuid(value);
        }
        private bool Validate(string value)
        {
            if (value == null || value == "" || value.Length < 5)
            {
                throw new ArgumentException("Id parameter cannot be empty.");
            }

            return true;
        }
    }
}