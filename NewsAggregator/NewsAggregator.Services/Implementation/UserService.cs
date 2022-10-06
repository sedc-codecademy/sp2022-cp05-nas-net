using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsAggregator.Configurations;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.Helpers;
using NewsAggregator.InterfaceModels.Models.User;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _appSettings;

        public UserService(IRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public AuthUserDto Authenticate(string loginProvider, string password)
        {
            var hashedPassword = PasswordHasher.HashPassword(password);
            var user = _userRepository.GetAll().FirstOrDefault(x => (x.Username == loginProvider || x.Email == loginProvider) && x.Password == hashedPassword);
            if (user == null)
            {
                throw new UserException(400, "Invalid username or password.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                       new[]
                       {
                            new Claim(ClaimTypes.Name , user.Username),
                            new Claim(ClaimTypes.GivenName , user.FirstName),
                            new Claim(ClaimTypes.Surname , user.LastName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Role , user.IsAdmin ? "admin" : "user")
                       }
                   ),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public void Register(RegisterUserDto model)
        {
            ValidateUserDetails(model.FirstName, model.LastName, model.Username, model.Email);
            ValidateUserPassword(model.Password, model.ConfirmPassword);
            var user = new User(model.FirstName, model.LastName, model.Username, model.Email, PasswordHasher.HashPassword(model.Password));
            _userRepository.Create(user);
        }

        public void RegisterAdmin(RegisterUserDto model)
        {
            ValidateUserDetails(model.FirstName, model.LastName, model.Username, model.Email);
            ValidateUserPassword(model.Password, model.ConfirmPassword);
            var user = new User(model.FirstName, model.LastName, model.Username, model.Email, PasswordHasher.HashPassword(model.Password)) { IsAdmin = true };
            _userRepository.Create(user);

        }

        public void ChangePassword(ChangePasswordDto model, int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new UserException(404, userId, "User does not exist");
            }
            if (PasswordHasher.HashPassword(model.OldPassword) != user.Password)
            {
                throw new UserException(400, "Something went wrong");
            }
            ValidateUserPassword(model.NewPassword, model.ConfirmNewPassword);
            user.ChangePassword(PasswordHasher.HashPassword(model.NewPassword));
            _userRepository.Update(user);
        }
        public void Update(UpdateUserDto model, int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new UserException(404, userId, "User does not exist");
            }
            if (user.Password != PasswordHasher.HashPassword(model.Password))
            {
                throw new UserException(400, "Something went wrong");
            }
            ValidateUserDetails(model.FirstName, model.LastName, model.Username, model.Email, userId);
            user.Update(model);
            _userRepository.Update(user);

        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new UserException(404, id, $"User with Id:{id} does not exist");
            }
            _userRepository.Delete(user);
            List<int> nums = new List<int> { 1, 2, 3, 4 };
            
        }



        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll().Select(x => x.ToUserDto()).ToList();
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new UserException(404, id, $"User with Id:{id} does not exist");

            }
            return user.ToUserDto();
        }


        private bool IsUsernameUsed(string username)
        {
            return _userRepository.GetAll().Any(x => x.Username == username);
        }
        private bool IsUsernameValid(string username)
        {
            var usernameRegex = new Regex(@"^[A-z][A-z0-9-_]{5,24}$");
            var match = usernameRegex.Match(username);
            return match.Success;
        }
        private bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        private bool IsEmailUsed(string email)
        {
            return _userRepository.GetAll().Any(x => x.Email == email);
        }

        private bool IsPasswordValid(string password)
        {
            var passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }

        private void ValidateUserPassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new UserException(400, "Password cannot be empty");
            }
            if (password != confirmPassword)
            {
                throw new UserException(400, "Passwords do not match");
            }
            if (!IsPasswordValid(password))
            {
                throw new UserException(400, "Please enter a valid password format");
            }
        }

        private void ValidateUserDetails(string firstName, string lastName, string username, string email, int userId = 0)
        {
            var users = _userRepository.GetAll();
            if (string.IsNullOrEmpty(firstName))
            {
                throw new UserException(400, "First name is requiered.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new UserException(400, "Last name is requiered.");
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new UserException(400, "Username is requiered.");
            }
            if (IsUsernameUsed(username) && users.Any(x => x.Username == username && x.Id != userId))
            {
                throw new UserException(400, "Username is already used.");
            }
            if (!IsUsernameValid(username))
            {
                throw new UserException(400, "Please enter a valid username");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new UserException(400, "Email is requiered.");
            }
            if (!IsEmailValid(email))
            {
                throw new UserException(400, "Please enter a valid email format.");
            }
            if (IsEmailUsed(email) && users.Any(x => x.Email == email && x.Id != userId))
            {
                throw new UserException(400, "Email is already used.");
            }
        }


    }
}
