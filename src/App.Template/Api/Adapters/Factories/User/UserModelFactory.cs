using App.Template.Infra.Models;
using System.Collections.Generic;
using App.Template.Domain.Entities.User;

namespace App.Template.Api.Adapters.Factories.User
{
    public class UserModelFactory
    {
        public static UserModel Build(UserEntity userEntity)
        {
            return UserModel.Builder()
                    .WithId(userEntity.Id.Value.ToString())
                    .WithFirstName(userEntity.FirstName.Value)
                    .WithLastName(userEntity.LastName.Value)
                    .WithEmail(userEntity.Email.Value)
                    .Build();
        }
        public static IEnumerable<UserModel> Build(IEnumerable<UserEntity> usersEntity)
        {
            foreach (UserEntity userEntity in usersEntity)
            {
                yield return UserModelFactory.Build(userEntity);
            }
        }
    }
}