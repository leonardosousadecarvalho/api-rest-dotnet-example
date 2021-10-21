using System;

namespace App.Template.Domain.Contracts.UseCase.User
{
    public interface IUserExistsUseCase
    {
        bool Check(Guid id);
    }
}