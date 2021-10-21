using System;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;

namespace App.Template.Domain.UseCases.User
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private IUserRepository _repository;
        public DeleteUserUseCase(IUserRepository repository)
        {
            this._repository = repository;
        }
        public void Delete(Guid id)
        {
            try
            {
                _repository.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}