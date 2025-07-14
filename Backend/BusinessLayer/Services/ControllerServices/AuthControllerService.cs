using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using BusinessLayer.Dto.Auth;
using BusinessLayer.Services.DbServices;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ControllerServices
{
    public class AuthControllerService : IAuthControllerService
    {
        private readonly IAuthDbService _authDbService;
        private readonly IConfiguration _configuration;
        public AuthControllerService(IAuthDbService authDbService, IConfiguration configuration)
        {
            _authDbService = authDbService;
            _configuration = configuration;
        }

        public async Task<IDataResult<LoginResponseDTO>> Login(LoginRequestDTO loginDTO) 
        { 
            var result = await _authDbService.Login(loginDTO.Email, loginDTO.Password);
            var user = result.Data;
            if (!result.Success)
            {
                return new ErrorDataResult<LoginResponseDTO>(result.StatusCode, result.Message);
            }
            var token = GenerateJwtToken(user);

            var data =  new LoginResponseDTO
            {
                Token = token,
                userDTO = new UserDTO
                {
                    Email = user.Email
                }
            };

            return new SuccessDataResult<LoginResponseDTO>(data);
        }

        public async Task<IDataResult<RegisterResponseDTO>> Register(RegisterRequestDTO registerDTO)
        {
            if (registerDTO.ConfirmPassword != registerDTO.Password)
            {
                return new ErrorDataResult<RegisterResponseDTO>(400, "Passwords do not match.");
            }

            string userName = registerDTO.Email;

            var result = await _authDbService.Register(registerDTO.Email, registerDTO.Password, registerDTO.FirstName, registerDTO.LastName, registerDTO.TcNumber, userName);
            var user = result.Data;
            if (!result.Success)
            {
                return new ErrorDataResult<RegisterResponseDTO>(result.StatusCode, result.Message);
            }

            var token = GenerateJwtToken(user);

            var data = new RegisterResponseDTO
            {
                Message = result.Message,
                userDTO = new UserDTO
                {
                    Email = user.Email
                },
                Token = token
            };

            return new SuccessDataResult<RegisterResponseDTO>(data);
        }

        private string GenerateJwtToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email)
        };

            var expiresAt = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return (new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
