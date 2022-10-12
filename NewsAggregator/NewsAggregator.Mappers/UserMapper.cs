using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Email = model.Email,
                IsAdmin = model.IsAdmin
            };
        }

        public static CommentOwnerDto ToCommentOwnerDto(this User model)
        {
            return new CommentOwnerDto
            {
                Id = model.Id,
                Username = model.Username
            };
        }
    }
}
