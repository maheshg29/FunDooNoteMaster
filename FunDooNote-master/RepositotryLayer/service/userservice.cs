using CommonLayer.model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositotryLayer.contest;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositotryLayer.service
{
    public class Userservice : iUserRlinterface
    {
        private readonly fundocontext _fundooContext;
        private readonly IConfiguration iconfiguration;
        public Userservice(fundocontext _fundooContext, IConfiguration iconfiguration)
        {
            this._fundooContext = _fundooContext;
            this.iconfiguration = iconfiguration;
        }
        public userentity UserRegestration(UserRegitrationModel userRegestartion)
        {
            try
            {
                var userEntity = new userentity();
                userEntity.FirstName = userRegestartion.FirstName;
                userEntity.LastName = userRegestartion.LastName;
                userEntity.Email = userRegestartion.Email;
                userEntity.Password = userRegestartion.Password;

                _fundooContext.usertable.Add(userEntity);
                int result = _fundooContext.SaveChanges();
                if (result > 0)

                    return userEntity;

                else

                    return null;


            }
            catch (Exception A)
            {

                throw A;

            }

        }

        //login//
        public string UserLogin(UserLoginModel userLoginModel)
        {
            try
            {
                var data = this._fundooContext.usertable.Where(x => x.Email == userLoginModel.Email && x.Password == userLoginModel.Password).FirstOrDefault();
                if (data != null)
                {

                    var token = GenerateSecurityToken(data.Email, data.UserId);
                    return token;

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GenerateSecurityToken(string email, long UserId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.iconfiguration[("JWT:Key")]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ForgetPassword(string email)
        {
            try
            {
                var singleuserentity= _fundooContext.usertable.Where(x => x.Email == email).FirstOrDefault();
                if (singleuserentity != null)
                {
                    var token = GenerateSecurityToken(singleuserentity.Email, singleuserentity.UserId);
                    MSMQModel mSMQ = new MSMQModel();
                    mSMQ.SendData(token);
                    return token.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ResetPassword(string email, string Password, string ConfirmPassword)
        {
            try
            {
                var singleUserEntity = _fundooContext.usertable.Where(x => x.Email == email).FirstOrDefault();
                if (Password == ConfirmPassword && singleUserEntity != null)
                {
                    singleUserEntity.Password = Password;
                    _fundooContext.SaveChanges();
                    return true;

                }
                else
                    return false;

            }
            catch (Exception)
            {

                throw;
            }

        }

      
        public IEnumerable<UserDetailsModel> UserDetails()
        {
            try
            {
                ///////////////////////output 3
                //var temp = _fundooContext.usertable;

                //if (temp != null)
                //{

                //    return temp;
                //}
                //else
                //{
                //    return null;
                //}


                ///////////////// output 2
                //var temp = _fundooContext.usertable.Select(x => new userentity() { UserId = x.UserId, Email = x.Email });
               
                //if (temp != null)
                //{

                //    return temp;
                //}
                //else
                //{
                //    return null;
                //}

                ///////////////// output 1

                var temp= _fundooContext.usertable.Select(x => new UserDetailsModel { userId = x.UserId, userEmail = x.Email }).ToList();
                
                return temp;


            }
            catch (Exception)
            {

                throw;
            }
        }       
    }

}
