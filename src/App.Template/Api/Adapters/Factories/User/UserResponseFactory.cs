using System.Collections.Generic;
using App.Template.Domain.Entities.User;
using App.Template.Api.Adapters.Responses;

namespace App.Template.Api.Adapters.Factories.User
{
    public class UserResponseFactory
    {
        public static UserResponse Build(UserEntity userEntity)
        {
            return UserResponse.Builder()
                        .WithId(userEntity.Id.Value.ToString())
                        .WithFirstName(userEntity.FirstName.Value)
                        .WithLastName(userEntity.LastName.Value)
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