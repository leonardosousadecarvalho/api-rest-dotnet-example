using System;
using App.Template.Domain.Entities.User;
using App.Template.Domain.Contracts.UseCase.User;
using App.Template.Domain.Contracts.Repository;

namespace App.Template.Domain.UseCases.User
{
    public class FindByIdUserUseCase : IFindByIdUserUseCase
    {
        private IUserRepository _repository;
        public FindByIdUserUseCase(IUserRepository repository)
        {
            this._repository = repository;
        }
        public UserEntity FindById(Guid id)
        {
            try
            {
                return _repository.FindById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}