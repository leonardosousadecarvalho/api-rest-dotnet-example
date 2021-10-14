using System;
using App.Template.Domain.Entities.User;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;
namespace App.Template.Domain.UseCases.User
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private IUserRepository _repository;
        public CreateUserUseCase(IUserRepository repository)
        {
            this._repository = repository;
        }
        public void Create(UserEntity userEntity)
        {
            try
            {
                if (userEntity == null) throw new Exception("Failed to create user.");
                
                _repository.Create(userEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}