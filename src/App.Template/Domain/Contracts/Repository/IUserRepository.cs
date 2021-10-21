using System;
using System.Collections.Generic;
using App.Template.Domain.Entities.User;

namespace App.Template.Domain.Contracts.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> FindAllUsers();
        UserEntity FindUserById(Guid id);
        void CreateUser(UserEntity userEntity);
        void UpdateUser(Guid id, UserEntity userEntity);
        void DeleteUser(Guid id);
        bool UserExists(Guid id);
    }
}