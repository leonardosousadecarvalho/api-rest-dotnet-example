using App.Template.Domain.Entities.User;
using App.Template.Api.Adapters.Response;
using System.Collections.Generic;

namespace App.Template.Api.Adapters.Factories
{
    public class UserResponseFactory
    {
        public static UserResponse Build(UserEntity userEntity)
        {
            return UserResponse.Builder()
                        .WithId(userEntity.Id.Value.ToString())
                        .WithName(userEntity.Name.Value)
                        .WithEmail(userEntity.Email.Value)
                        .Build();
        }
        public static IEnumerable<UserResponse> Build(IEnumerable<UserEntity> usersEntity)
        {
            foreach (UserEntity userEntity in usersEntity)
            {
                yield return UserResponseFactory.Build(userEntity);
            }
        }
    }
}