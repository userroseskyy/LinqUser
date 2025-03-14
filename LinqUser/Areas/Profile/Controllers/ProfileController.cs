﻿using LinqUser.Areas.Profile.Models;
using LinqUser.Areas.Services.ProfileService.AddUserProfile;
using LinqUser.Areas.Services.ProfileService.CreateProfileUser;
using LinqUser.Areas.Services.ProfileService.EditeProfileUser;
using LinqUser.Areas.Services.ProfileService.UserProfile;
using LinqUser.Migrations;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Controllers
{
    [Authorize]
    [Area("profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserProfileService _userProfileService;
        private readonly DataBaseContext _context;
        private readonly ICreateProfileUserService  _createProfileUserService;
        private readonly IEditeProfileUserService _editeProfileUserService;

        public ProfileController( IUserProfileService userProfileService, ICreateProfileUserService createProfileUserService, IEditeProfileUserService editeProfileUserService)
        {
           
            _userProfileService=userProfileService;
            _createProfileUserService=createProfileUserService;
            _editeProfileUserService=editeProfileUserService;
        }
        public async  Task<IActionResult> Index()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var profileDto = await _userProfileService.ProfileUserAsync(User);
            
            return View(profileDto);
          }
        [HttpGet]
        public async Task<IActionResult> CreateProfile() 
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateProfileDto createProfileDto) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createProfileDto);
                }
                await _createProfileUserService.CreateProfile(createProfileDto, User);

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(createProfileDto);
            }
            
           
        }
        [HttpGet]
        public async Task<IActionResult> EditeProfile()
        {
            var profileDto =await  _editeProfileUserService.GetProfileForEdit(User);

            return View(profileDto);
        }
        [HttpPost]
        public async Task<IActionResult> EditeProfile(EditeProfileUserDto editeProfileUserDto) 
        {
           
            await _editeProfileUserService.EditeProfileUser(editeProfileUserDto,User);
            return RedirectToAction("Index");
        }


        

    }
}