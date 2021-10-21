using System;

namespace App.Template.Api.Adapters.Responses
{
    public class ErrorResponse
    {
        public string Type { get; private set;}
        public string Message { get; private set;}
        public ErrorResponse(string type, string message)
        {
            Type = type;
            Message = message;
        }
        public static ErrorResponse BuildValidationError()
        {
            return new ErrorResponse("Validation error", "The fields could not be null or empty");
        }
        public static ErrorResponse BuildNotFound()
        {
            return new ErrorResponse("Not found", "User not found");
        }
        public static ErrorResponse BuildException(Exception ex)
        {
            return new ErrorResponse(ex.GetType().Name, ex.Message);
        }
    }
}