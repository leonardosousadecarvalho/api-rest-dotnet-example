using System.Collections.Generic;
using App.Template.Domain.Entities.User;
using App.Template.Infra.Models;
using App.Template.Api.Adapters.Requests.User;

namespace App.Template.Api.Adapters.Factories
{
    public class UserEntityFactory
    {
        public static UserEntity Build(UserModel userModel)
        {
            return UserEntity.Builder()
                    .WithId(userModel.Id.ToString())
                    .WithName(userModel.Name)
                    .WithEmail(userModel.Email)
                    .Build();
        }
        public static UserEntity Build(UserCreateRequest userCreateRequest)
        {
            return UserEntity.Builder()
                    .WithName(userCreateRequest.Name)
                    .WithEmail(userCreateRequest.Email)
                    .BuildWithoutId();
                    // .Build();
        }
        public static UserEntity Build(UserUpdateRequest userUpdateRequest)
        {
            return UserEntity.Builder()
                    .WithName(userUpdateRequest.Name)
                    .WithEmail(userUpdateRequest.Email)
                    .BuildWithoutId();
                    // .Build();
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