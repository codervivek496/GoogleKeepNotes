using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
            public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult Registration(UserRegistrationModel userRegistrationModel)
        {
            var result = userBL.Register(userRegistrationModel);
            if (result != null)
            {
                return this.Ok(new {success=true,message="Registration is sucessfull", data=result});
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Registration  unsucessfull"});
            }

        }
    }
}
