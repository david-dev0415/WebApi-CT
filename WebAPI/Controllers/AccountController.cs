using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.ViewsModel;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {

        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Register(AccountViewModel accountView)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = accountView.UserName, Email = accountView.Email };
            user.FirstName = accountView.FirstName;
            user.LastName = accountView.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };

            //var  

            IdentityResult result = manager.Create(user, accountView.Password);
            if (result.Succeeded)
            {
                Reply reply = new Reply()
                {
                    Code = 400,
                    Message = "Ocurrió un error."
                };
            }

            if (accountView.Roles != null)
            {
                manager.AddToRoles(user.Id, accountView.Roles);
            }
                
            return Ok(result);
        }

        [Route("api/User/Edit")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult PutAccount([FromBody]AccountViewModel accountView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Solicitud incorrecta: el módelo recibido no es válido.");
            }

            try
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());

                using (var manager = new UserManager<ApplicationUser>(userStore))
                {
                    var existingAccount = manager.Users.Where(a => a.UserName == accountView.UserName).FirstOrDefault();
                    if (existingAccount != null)
                    {
                        existingAccount.FirstName = accountView.FirstName;
                        existingAccount.LastName = accountView.LastName;
                        existingAccount.Email = accountView.Email;
                        manager.PasswordValidator = new PasswordValidator { RequiredLength = 3 };
                        manager.RemovePassword(existingAccount.Id);
                        manager.AddPassword(existingAccount.Id, accountView.Password);
                        return Ok(existingAccount);
                    }
                    else
                    {
                        Reply reply = new Reply
                        {
                            Code = 400,
                            Message = "El usuario no se encontró, problamente porque no está registrado en la base de datos."
                        };
                        return Content(HttpStatusCode.BadRequest, reply);
                    }
                }

            }
            catch (HttpResponseException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/User/Get/{userName}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAccount([FromUri]string userName)
        {
            try
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());

                using (var manager = new UserManager<ApplicationUser>(userStore))
                {
                    var user = manager.Users.Where((a) => (userName.Contains(a.UserName.ToString()))).ToList();

                    if (user.Count > 0)
                    {
                        foreach (var data in user)
                        {
                            return Ok(data);
                        }
                    }

                    Reply reply = new Reply()
                    {
                        Code = 400,
                        Message = "El usuario no se encontró, problamente porque no está registrado en la base de datos."
                    };
                    return Content(HttpStatusCode.BadRequest, reply);
                }
            }
            catch (HttpResponseException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        //[Route("api/User/GetCheckPassword/{userName}/{password}")]
        [Route("api/User/CheckPassword")]
        //[Route("api/User/GetCheckPassword")]
        [Authorize]
        public IHttpActionResult CheckPassword([FromBody]AccountViewModel accountView)
        {
            var verifyPassword = false;
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            using (var manager = new UserManager<ApplicationUser>(userStore))
            {
                try
                {
                    var passwordData = accountView.Password;
                    var user = manager.FindByName(accountView.UserName);
                    bool check = manager.CheckPassword(user, passwordData);
                    verifyPassword = check;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return Ok(verifyPassword);
        }

        [HttpPut]
        [Route("api/User/PutPassword")]
        [Authorize]
        public IHttpActionResult PutPassword([FromBody]AccountViewModel accountView)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            using (var manager = new UserManager<ApplicationUser>(userStore))
            {
                try
                {
                    var passwordData = accountView.CurrentPassword;
                    var user = manager.FindByName(accountView.UserName);
                    //bool check = manager.CheckPassword(user, passwordData);
                    if (accountView.NewPassword != null)
                    {
                        var changePassword = manager.ChangePassword(user.Id, passwordData, accountView.NewPassword);
                        if (!changePassword.Succeeded)
                        {
                            Reply reply = new Reply()
                            {
                                Code = 401,
                                Message = "La contraseña actual es incorrecta."
                            };
                            return Ok(reply);
                        }
                        else
                        {
                            return Ok(changePassword);
                        }
                    }
                    else
                    {
                        return Ok("El campo 'nueva contraseña' está vacío.");
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }


        [Route("api/GetUserClaims")]
        [HttpGet]
        public async Task<AccountViewModel> GetUserClaims()
        {
            try
            {
                var identityClaims = (ClaimsIdentity)User.Identity;
                IEnumerable<Claim> claims = identityClaims.Claims;
                AccountViewModel model = new AccountViewModel()
                {
                    UserName = identityClaims.FindFirst("Username").Value,
                    Email = identityClaims.FindFirst("Email").Value,
                    FirstName = identityClaims.FindFirst("FirstName").Value,
                    LastName = identityClaims.FindFirst("LastName").Value,
                    LoggedOn = identityClaims.FindFirst("LoggedOn").Value
                };
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        [Route("api/ForAuthorRole")]
        public string ForAuthorRole()
        {
            return "For author role";
        }

        [HttpGet]
        [Authorize(Roles = "Author,Reader")]
        [Route("api/ForAuthorOrReader")]
        public string ForAuthorOrReader()
        {
            return "For author/reader role";
        }
    }
}
