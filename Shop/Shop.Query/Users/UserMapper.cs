using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Name = user.Name,
                Family = user.Family,
                AvatarName = user.AvatarName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Password = user.Password,
                Roles = user.Roles.Select(u => new UserRoleDto()
                {
                    RoleId = u.RoleId,
                    RoleTitle = ""
                }).ToList()
            };
        }

        public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
        {
            var roleIds = userDto.Roles.Select(u => u.RoleId);

            var result = await context.Roles
                .Where(r => roleIds.Contains(r.Id)).ToListAsync();

            var roles = new List<UserRoleDto>();

            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title
                });
            }

            userDto.Roles = roles;

            return userDto;
        }

        public static UserFilterDataDto MapFilterData(this User user)
        {
            return new UserFilterDataDto()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Name = user.Name,
                Family = user.Family,
                AvatarName = user.AvatarName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            };
        }

    }
}
