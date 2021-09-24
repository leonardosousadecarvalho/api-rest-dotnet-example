using System;
using  App.Template.Domain.Entities.User;

namespace  App.Template.Domain.Contracts.UseCase.User
{
    public interface IUpdateUserUseCase
    {
        void Update(Guid id, UserEntity userEntity);
    }
}