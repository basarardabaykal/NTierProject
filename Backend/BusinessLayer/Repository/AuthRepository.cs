using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IDataResult<AppUser>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(email);
                if (user == null)
                {
                    throw new Exception("No user was found with this email.");
                }
                else
                {
                    return new SuccessDataResult<AppUser>(user, "User with this email has been found succesfully.");
                }
            }
            catch (Exception exception)
            {
                {
                    return new ErrorDataResult<AppUser>(500, exception.Message);
                }
            }
        }
        public async Task<IDataResult<bool>> CheckPassword(AppUser user, string password)
        {
            try
            {
                var hasMatchedPasswords = await _userManager.CheckPasswordAsync(user, password);
                if (hasMatchedPasswords)
                {
                    return new SuccessDataResult<bool>(hasMatchedPasswords, "Password is correct.");
                }
                else
                {
                    return new ErrorDataResult<bool>(hasMatchedPasswords, 500, "Password is not correct.");
                }

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<bool>(500, "An unexpected error has occured while checking the password.");
            }
        }

        public async Task<IDataResult<AppUser>> CreateUser(AppUser user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    return new SuccessDataResult<AppUser>(user, "User has been created successfully.");
                }
                else
                {
                    return new ErrorDataResult<AppUser>(400, "User creation failed");
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<AppUser>(500, "An unexpected error occurred while creating the user.");
            }
        }

        public async Task<IDataResult<List<string>>> GetUserRoles(string email)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(email);
                if (user == null)
                {
                    return new ErrorDataResult<List<string>>(404, "User not found.");
                }

                var roles = await _userManager.GetRolesAsync(user);
                return new SuccessDataResult<List<string>>(roles.ToList(), "User roles retrieved successfully.");
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<string>>(500, "An unexpected error occurred while retrieving user roles.");
            }
        }
        public async Task<IDataResult<bool>> AssignRole(AppUser user, string role)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                if (await _userManager.IsInRoleAsync(user, role))
                {
                    return new SuccessDataResult<bool>($"User already has role '{role}'.");
                }

                var result = await _userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                {
                    return new SuccessDataResult<bool>($"Role '{role}' has been assigned to user successfully.");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new ErrorDataResult<bool>(400, $"Role assignment failed: {errors}");
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<bool>(500, "An unexpected error occurred while assigning role.");
            }
        }
    }
}
