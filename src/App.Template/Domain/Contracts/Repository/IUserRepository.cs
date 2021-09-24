using System;
using System.Collections.Generic;
using App.Template.Domain.Entities.User;

namespace App.Template.Domain.Contracts.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(Guid id);
        void Create(UserEntity userEntity);
        void Update(Guid id, UserEntity userEntity);
        void Delete(Guid id);
    }
}