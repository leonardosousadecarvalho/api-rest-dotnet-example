using System;
using System.Linq;
using App.Template.Infra.Models;
using App.Template.Infra.Context;
using App.Template.Domain.Entities.User;
using App.Template.Api.Adapters.Factories;
using System.Collections.Generic;
using App.Template.Domain.Contracts.Repository;

namespace App.Template.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApiContext _context;
        public UserRepository(ApiContext context)
        {
            this._context = context;
        }
        public IEnumerable<UserEntity> FindAll()
        {
            try
            {
                return UserEntityFactory.Build(this._context.Users);
            }
            catch (Exception)
            {
                throw new Exception("Failed to find users.");
            }
        }
        private UserModel _findById(Guid id)
        {
            try
            {
                UserModel userModel = this._context.Users.FirstOrDefault(user => user.Id == id);
                if (userModel == null) return null;

                return userModel;
            }
            catch (Exception)
            {
                throw new Exception("Failed to find user.");
            }
        }
        public UserEntity FindById(Guid id)
        {
            try
            {
                UserModel userModel = this._findById(id);
                if (userModel == null) throw new Exception("User not found!");

                return UserEntityFactory.Build(userModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Create(UserEntity userEntity)
        {
            try
            {
                this._context.Users.Add(UserModelFactory.Build(userEntity));
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to create user.");
            }
        }
        public void Update(Guid id, UserEntity userEntity)
        {
            try
            {
                UserModel userModel = this._findById(id);
                if (userModel == null) throw new Exception("User not found!");

                this._mergeProperties(userEntity, userModel);

                this._context.Users.Update(userModel);
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to update user.");
            }
        }
        private UserModel _mergeProperties(UserEntity userEntity, UserModel userModel)
        {
            userModel.Name = userEntity.Name.Value;
            userModel.Email = userEntity.Email.Value;

            return userModel;
        }
        public void Delete(Guid id)
        {
            try
            {
                UserModel userModel = this._findById(id);
                if (userModel == null) throw new Exception("User not found!");

                this._context.Users.Remove(userModel);
                this._context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete user.");
            }
        }
    }
}