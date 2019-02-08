using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc02.Models.ViewModels;
using System.Web;

namespace Mvc02.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        internal async Task<bool> UserExist(string email)
        {
            

            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        internal async Task AddRoleToUser(AddRoleVm addrole)
        {
            if (!await _roleManager.RoleExistsAsync(addrole.Role))
                await CreateRolesAsync(addrole.Role);

                IdentityUser user = await _userManager.FindByEmailAsync(addrole.Email);

            await _userManager.AddToRoleAsync(user, addrole.Role);
        }

        internal async Task<List<IdentityUser>> GetAllUsers()
        {

            List<IdentityUser> users = await _userManager.Users.ToListAsync();
           var hejsan =  await _userManager.GetRolesAsync(users[0]);
            List<string> rolesList = new List<string>();
            //rolesList.Add(hejsan);
            //return  users[0].Email.ToString();
            return users;

        }

        internal async Task CreateRolesAsync(string role)
        {
            
                var newRole = new IdentityRole();
                newRole.Name = role;
                await _roleManager.CreateAsync(newRole);
            
        }

        // din kod här
    }

}