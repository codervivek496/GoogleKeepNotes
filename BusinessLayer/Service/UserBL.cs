using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserEntity Register(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                return userRL.Register(userRegistrationModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(LoginModel loginModel)
        {
            try
            {
                return userRL.Login(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
