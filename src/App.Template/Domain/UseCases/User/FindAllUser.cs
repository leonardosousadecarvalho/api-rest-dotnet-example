using System;
using App.Template.Domain.Entities.User;
using System.Collections.Generic;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;

namespace App.Template.Domain.UseCases.User
{
    public class FindAllUserUseCase : IFindAllUserUseCase
    {
        private IUserRepository _repository;
        public FindAllUserUseCase(IUserRepository repository)
        {
            this._repository = repository;
        }
        public IEnumerable<UserEntity> FindAll()
        {
            try
            {
                return _repository.FindAllUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}