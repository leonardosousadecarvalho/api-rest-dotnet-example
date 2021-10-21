using System;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;

namespace App.Template.Domain.UseCases.User
{
    public class UserExistsUseCase: IUserExistsUseCase
    {
        private readonly IUserRepository _repository;
        public UserExistsUseCase(IUserRepository repository)
        {
            _repository = repository;
        }
        public bool Check(Guid id)
        {
            if(_repository.UserExists(id)) return true;

            return false;
        }
    }
}