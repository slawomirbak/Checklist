using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.Abstract.Validation;
using Checklist.DataLogic.Entities;
using Checklist.DataLogic.Repository.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Services.Services.UserService
{
    public class UserService: ServiceBase, IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<BasePlainResponse> Add(UserDto userDto)
        {
            var plainResponse = new BasePlainResponse();
            var user = _mapper.Map<User>(userDto);
            var doesUserExist = await _unitOfWork.userRepository.IsEmailExist(user.Email);

            if (doesUserExist)
            {
                plainResponse.IsSuccessful = false;
                plainResponse.ErrorMessage = "The e-mail address already exists in database";
                return plainResponse;
            }
            user.CreatedDate = DateTime.UtcNow;
            user.PasswordHash(userDto.Password);

            await _unitOfWork.userRepository.Create(user);
            await _unitOfWork.Save();

            return plainResponse;
        }
        public async Task<BasePlainResponse> Login(CredentialDto credentials)
        {
            var loginResponse = new LoginPlainResponse();
            loginResponse.IsSuccessful = false;
            loginResponse.ErrorMessage = "Email or password are incorrect. Try again.";
            var user = await _unitOfWork.userRepository.GetByEmial(credentials.Email);
            if(user == null)
            {
                return loginResponse;
            }
            if(user.VerifyPassword(credentials.Password))
            {
                loginResponse.IsSuccessful = true;
                loginResponse.ErrorMessage = "";
                loginResponse.Data = GenerateToken(user);
                return loginResponse;
            }
            return loginResponse;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
        }
    }
}
