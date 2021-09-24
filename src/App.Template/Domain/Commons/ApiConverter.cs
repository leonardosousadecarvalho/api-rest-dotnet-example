using System;

namespace App.Template.Domain.Commons
{
    public class ApiConverter
    {
        public static Guid ToGuid(string payload)
        {
            try
            {
                return Guid.Parse(payload);
            }
            catch (FormatException)
            {
                throw new FormatException("Id is invalid.");
            }
        }
    }
}