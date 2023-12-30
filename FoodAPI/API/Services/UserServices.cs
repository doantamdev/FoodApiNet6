using API.Identity;
using Core.Configurations;
using Core.Inferstructer;
using Core.Models;
using Core.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserServices(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest registerRequest)
        {
            var user = new AppUser()
            {
                LastName = registerRequest.LastName,
                FirstName = registerRequest.FirstName,
                PhoneNumber = registerRequest.PhoneNumber,
                Email = registerRequest.Email,
                UserName = registerRequest.Email,
                SecurityStamp = new Guid().ToString(),
            };
            var rs = await _userManager.CreateAsync(user, registerRequest.Password);
            if (!rs.Succeeded)
            {
                String error = "";
                foreach (var item in rs.Errors)
                {
                    error += item.Description + "\n";
                }
                return new FailedResult<bool>(error);
            }
            await _userManager.AddToRoleAsync(user, PolicyType.User);
            return new SuccessedResult<bool>(true);
        }

        public async Task<ApiResult<string>> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return new FailedResult<string>("Invalid login credentials");
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginRequest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new SuccessedResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
