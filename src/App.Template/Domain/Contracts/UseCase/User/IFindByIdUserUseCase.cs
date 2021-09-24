using System;
using  App.Template.Domain.Entities.User;

namespace  App.Template.Domain.Contracts.UseCase.User
{
    public interface IFindByIdUserUseCase
    {
        UserEntity FindById(Guid id);
    }
}