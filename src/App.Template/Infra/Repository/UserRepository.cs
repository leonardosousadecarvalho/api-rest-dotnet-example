using System;
using System.Linq;
using System.Collections.Generic;
using App.Template.Infra.Models;
using App.Template.Infra.Context;
using App.Template.Domain.Entities.User;
using App.Template.Domain.Contracts.Repository;
using App.Template.Api.Adapters.Factories.User;

namespace App.Template.Infra.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        private ApiContext _context;
        public UserRepository(ApiContext context)
            : base(context) {}
        public IEnumerable<UserEntity> FindAllUsers()
        {
            try
            {
                return UserEntityFactory.Build(FindAll());
            }
            catch (Exception)
            {
                throw new Exception("Failed to find users.");
            }
        }
        public bool UserExists(Guid id)
        {
            if(this._findById(id) == null) return false;

            return true;
        }
        private UserModel _findById(Guid id)
        {
            try
            {
                UserModel userModel = FindById(id);
                return userModel;
            }
            catch (Exception)
            {
                throw new Exception("Failed to find user.");
            }
        }
        public UserEntity FindUserById(Guid id)
        {
            try
            {
                UserModel userModel = this._findById(id);

                return UserEntityFactory.Build(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CreateUser(UserEntity userEntity)
        {
            try
            {
                Create(UserModelFactory.Build(userEntity));   
            }
            catch (Exception)
            {
                throw new Exception("Failed to create user.");
            }
        }
        public void UpdateUser(Guid id, UserEntity userEntity)
        {
            try
            {
                UserModel userModel = this._findById(id);

                this._mergeProperties(userEntity, userModel);

                Update(userModel);
            }
            catch (Exception)
            {
                throw new Exception("Failed to update user.");
            }
        }
        private UserModel _mergeProperties(UserEntity userEntity, UserModel userModel)
        {
            userModel.SetFirstName(userEntity.FirstName.Value);
            userModel.SetLastName(userEntity.LastName.Value);
            userModel.SetEmail(userEntity.Email.Value);

            return userModel;
        }
        public void DeleteUser(Guid id)
        {
            try
            {
                UserModel userModel = this._findById(id);

                Delete(userModel);
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete user.");
            }
        }
    }
}