using System;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;
using App.Template.Domain.Entities.User;

namespace App.Template.Domain.UseCases.User
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private IUserRepository _repository;
        public UpdateUserUseCase(IUserRepository repository)
        {
            this._repository = repository;
        }
        public void Update(Guid id, UserEntity userEntity)
        {
            try
            {
                if (userEntity == null) throw new Exception("Failed to update user.");
                _repository.UpdateUser(id, userEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}