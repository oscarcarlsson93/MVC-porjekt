﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Mvc02.Data;
using Mvc02.Models.ViewModels;
using Mvc02.Services;
using Mvc02.Controllers;

namespace Mvc02.Controllers
{

    public class AdminController : Controller
    {
        private readonly AuthService _auth;

        public AdminController(AuthService auth)
        {
            _auth = auth;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
        {
            if (!ModelState.IsValid)
                return View("Index");

            bool userExist = await _auth.UserExist(addrole.Email);

            if (!userExist)
            {
                ModelState.AddModelError("InvalidUser", "The user does not exist");
                return View("Index");
            }

            await _auth.AddRoleToUser(addrole);
            return View("SuccessAddRole", addrole);

        }

        public async Task<IActionResult> UserInfo()
        {
            List<IdentityUser> allUsers = await _auth.GetAllUsers();

            var vm = new UserTableVm();

            foreach (var x in allUsers)
            {
                List<string> roles = await _auth.GetRolesForUser(x);

                vm.Rows.Add(new Models.UserWithRoles
                {
                    IdentityUser = x,
                    Roles = roles,
                });
            }

            return View(vm);
        }

        public async Task<IActionResult> Edit(string email)
        {
            //if (email == null)
            //{
            //    return NotFound();
            //}

            IdentityUser user = await _auth.GetUserById(email);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            return View(user);

        }
    }
}
