using System;
using App.Template.Domain.Commons;

namespace App.Template.Domain.Entities.Shared
{
    public class Id
    {
        public Guid Value { get; private set; }
        public Id(Guid value)
        {
            this.Value = value;
        }
        public Id(string value)
        {
            this.Validate(value);
            this.Value = ApiConverter.ToGuid(value);
        }
        private void Validate(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length < 5)
            {
                throw new ArgumentException("Id parameter cannot be empty.");
            }
        }
    }
}