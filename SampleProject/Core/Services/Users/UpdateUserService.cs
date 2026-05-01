using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            //Only update when the value is provided:
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (!string.IsNullOrWhiteSpace(email))
                user.SetEmail(email);

            if (!string.IsNullOrWhiteSpace(name))
                user.SetName(name);

            user.SetType(type);

            if (annualSalary.HasValue)
                user.SetMonthlySalary(annualSalary.Value / 12);

            if (tags != null)
                user.SetTags(tags);
        }
    }
}