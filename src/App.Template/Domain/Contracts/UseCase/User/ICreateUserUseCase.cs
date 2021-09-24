using  App.Template.Domain.Entities.User;

namespace  App.Template.Domain.Contracts.UseCase.User
{
    public interface ICreateUserUseCase
    {
        void Create(UserEntity userEntity);
    }
}