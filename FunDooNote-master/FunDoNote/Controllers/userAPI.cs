using CommonLayer.model;
using LogicLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Net.WebSockets;
using System.Security.Claims;
using RepositotryLayer.contest;
using RepositotryLayer.entity;
using RepositotryLayer.service;
using RepositotryLayer.Interface;

namespace FunDoNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBlinterface _userBlinterface;

        private readonly fundocontext _fundocontext;

        private readonly iUserRlinterface _iUserRlinterface;

        public UserController(UserBlinterface _userBlinterface, fundocontext _fundocontext, iUserRlinterface _iUserRlinterface)
        {
            this._userBlinterface = _userBlinterface;
            this._fundocontext = _fundocontext;
          this._iUserRlinterface = _iUserRlinterface;

        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserRegitrationModel userRegestartion)
        {
            try
            {
                var result = _userBlinterface.UserRegestration(userRegestartion);
                if (result != null)
                {

                    return this.Ok(new { success = true, msg = "Regestration Successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, msg = "Regestration unSuccessful", });
                }
            }
            catch (System.Exception C)
            {
                throw C;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser(UserLoginModel userLoginModel)
        {
            try
            {
                var result = _userBlinterface.UserLogin(userLoginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login denied." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = _userBlinterface.ForgetPassword(email);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Email Send Sucessfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Email not send" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("ResetPassord")]
        public IActionResult ResetPassord(string Password, string ConfirmPassward)
        {
            try
            {
                var email=User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = _userBlinterface.ResetPassword(email, Password, ConfirmPassward);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Password has been Reset Sucessfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Password Not change" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
       //[Authorize]
        [HttpGet]
        [Route("UserDetails")]
        public IActionResult UserDetails()
        {
            try
            {
                //  var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                //var temp = _userBlinterface.UserDetails(userId);

                //var temp = _userBlinterface.UserDetails();

                // var temp = _fundocontext.usertable; // Type 3 output

                // var temp = _fundocontext.usertable.Select(x => new userentity { UserId= x.UserId,Email= x.Email}); // type 2

                // var temp = _fundocontext.usertable.Select(x => new UserDetailsModel { userId = x.UserId, userEmail = x.Email }); //type 1

                var temp = _iUserRlinterface.UserDetails();

                if (temp != null)
                {
                    return Ok(new { success = true, message = "view all user", data = temp });
                }
                else
                {
                    return BadRequest(new { success = false, message = "some thing wrong" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
