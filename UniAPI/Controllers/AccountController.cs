using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBwebAPI.DataAccess;
using OBwebAPI.Helpers;
using OBwebAPI.Models.DataModels;

namespace OBwebAPI.Controllers {
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase {

		private readonly UniversityDBContext _context;
		private readonly JwtSettings _jwtSettings;

		public AccountController(JwtSettings jwtSettings, UniversityDBContext context) {
			_jwtSettings = jwtSettings;
			_context = context;
		}


		//private IEnumerable<User> Logins = new List<User>() {
		//	new User {
		//		Id= 1,
		//		Email = "asd@asd.com",
		//		Name = "Admin",
		//		Password = "Admin",
		//	},
		//	new User {
		//		Id= 2,
		//		Email = "asd2@asd2.com",
		//		Name = "User1",
		//		Password = "pepe",
		//	}
		//};




		[HttpPost]
		public IActionResult GetToken(UserLogins userLogins) {
			try {
				var token = new UserToken();

				//search user in context with LINQ
				var user = (from u in _context.Users
										where userLogins.Username == u.Name
										&& userLogins.Password == u.Password
										select u).FirstOrDefault();

				var valid = user != null;

				if(valid) {

					token = JwtHelpers.GenTokenKey(new UserToken() {
						EmailId = user.Email,
						UserName = user.Name,
						Id = user.Id,
						GuidId = Guid.NewGuid(),

					}, _jwtSettings);
				} else {
					return BadRequest("Wrong Credentials");
				}

				return Ok(token);

			} catch(Exception ex) {
				throw new Exception("GetToken Error", ex);
			}

		}


		[HttpGet]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
		public IActionResult GetUsersList() {
			return Ok();
		}




	}
}
