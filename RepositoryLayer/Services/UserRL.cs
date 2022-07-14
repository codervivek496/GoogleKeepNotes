using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly FundooContext fundooContext;
        public UserRL(FundooContext fundooContext)
        {
                this.fundooContext = fundooContext;
        }
        public UserEntity Register(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                UserEntity userEntiry = new UserEntity();
                userEntiry.FirstName = userRegistrationModel.FirstName;
                userEntiry.LastName = userRegistrationModel.LastName;
                userEntiry.Email = userRegistrationModel.Email;
                userEntiry.Password = userRegistrationModel.Password;
                fundooContext.User.Add(userEntiry);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return userEntiry;
                }
                else
                {
                    return null;
                }
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
                UserEntity user = new UserEntity();
                user = this.fundooContext.User.SingleOrDefault(x => x.Email == loginModel.Email);
                if(user != null)
                {
                    return "Sucessfull";
                }
                else
                {
                    return null ;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
