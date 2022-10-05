using NewsAggregator.InterfaceModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface IUserService
    {
        public AuthUserDto Authenticate(string loginProvider, string password);
        public List<UserDto> GetAll();
        public UserDto GetById(int id);
        public void Register(RegisterUserDto model);
        public void RegisterAdmin(RegisterUserDto model);
        public void Update(UpdateUserDto model , int userId);
        public void ChangePassword(ChangePasswordDto model , int userId);
        public void Delete(int id);
    }
}
