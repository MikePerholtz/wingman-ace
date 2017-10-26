//using AlbumViewerBusiness;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using WingmanFleet.Lockdown;

namespace AlbumViewerAspNetCore
{
    //[ServiceFilter(typeof(ApiExceptionFilter))]    
    [EnableCors("CorsPolicy")]
    public class AccountController : Controller
    {
        //private AccountRepository accountRepo;

        // public AccountController(AccountRepository actRepo)            
        // {
        //     accountRepo = actRepo;
        // }

           
		// [AllowAnonymous]                    
		// [HttpPost]
		// [Route("api/login")]
		// public async Task<bool> Login([FromBody]  ApplicationUser loginUser)
		// {            
		// 	var user = await accountRepo.AuthenticateAndLoadUser(loginUser.UserName, loginUser.Password);
		// 	if (user == null)
		// 		throw new ApiException("Invalid Login Credentials", 401);

		// 	var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
		// 	identity.AddClaim(new Claim(ClaimTypes.Name, user.Username))    ;
           
		// 	if (user.Fullname == null)
		// 		user.Fullname = string.Empty;
		// 	identity.AddClaim(new Claim("FullName", user.Fullname));
								
		// 	await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
		// 		new ClaimsPrincipal(identity));

		// 	return true;
		// }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/logout")]
        public async Task<bool> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);            
            return true;
        }

        [HttpGet]
        [Route("api/isAuthenticated")]
        public bool IsAuthenthenticated()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}
