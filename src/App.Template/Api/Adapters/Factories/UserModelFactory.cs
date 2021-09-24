using System.Collections.Generic;
using App.Template.Domain.Entities.User;
using App.Template.Infra.Models;

namespace App.Template.Api.Adapters.Factories
{
    public class UserModelFactory
    {
        public static UserModel Build(UserEntity userEntity)
        {
            return UserModel.Builder()
                    .WithId(userEntity.Id.Value.ToString())
                    .WithName(userEntity.Name.Value)
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