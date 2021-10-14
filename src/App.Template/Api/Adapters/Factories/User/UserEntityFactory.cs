using App.Template.Infra.Models;
using System.Collections.Generic;
using App.Template.Domain.Entities.User;
using App.Template.Api.Adapters.Requests.User;

namespace App.Template.Api.Adapters.Factories.User
{
    public class UserEntityFactory
    {
        public static UserEntity Build(UserModel userModel)
        {
            return UserEntity.Builder()
                    .WithId(userModel.Id.ToString())
                    .WithFirstName(userModel.FirstName)
                    .WithLastName(userModel.LastName)
                    .WithEmail(userModel.Email)
                    .Build();
        }
        public static UserEntity Build(UserCreateRequest userCreateRequest)
        {
            return UserEntity.Builder()
                    .WithFirstName(userCreateRequest.FirstName)
                    .WithLastName(userCreateRequest.LastName)
                    .WithEmail(userCreateRequest.Email)
                    .BuildWithoutId();
        }
        public static UserEntity Build(UserUpdateRequest userUpdateRequest)
        {
            return UserEntity.Builder()
                    .WithFirstName(userUpdateRequest.FirstName)
                    .WithLastName(userUpdateRequest.LastName)
                    .WithEmail(userUpdateRequest.Email)
                    .BuildWithoutId();
        }
        public static IEnumerable<UserEntity> Build(IEnumerable<UserModel> usersModel)
        {
            foreach (UserModel userModel in usersModel)
            {
                yield return UserEntityFactory.Build(userModel);
            }
        }
    }
}