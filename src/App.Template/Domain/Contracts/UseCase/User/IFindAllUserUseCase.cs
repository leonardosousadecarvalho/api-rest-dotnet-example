using  App.Template.Domain.Entities.User;
using System.Collections.Generic;

namespace  App.Template.Domain.Contracts.UseCase.User
{
    public interface IFindAllUserUseCase
    {
        IEnumerable<UserEntity> FindAll();
    }
}