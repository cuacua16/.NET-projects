using Microsoft.IdentityModel.Tokens;
using OBwebAPI.Models.DataModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OBwebAPI.Helpers {
	public static class JwtHelpers {
		public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, Guid id) {
			List<Claim> claims = new List<Claim>() {
				new Claim("Id", userAccounts.Id.ToString()),
				new Claim(ClaimTypes.Name, userAccounts.UserName),
				new Claim(ClaimTypes.Email, userAccounts.EmailId),
				new Claim(ClaimTypes.NameIdentifier, id.ToString()),
				new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
			};

			if(userAccounts.UserName == "Admin") {
				claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
			} else if(userAccounts.UserName == "User 1") {
				claims.Add(new Claim(ClaimTypes.Role, "User"));
				claims.Add(new Claim("UserOnly", "User 1"));
			}
			return claims;
		}



		public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, out Guid Id) {
			Id = Guid.NewGuid();
			return GetClaims(userAccounts, Id);
		}



		public static UserToken GenTokenKey(UserToken model, JwtSettings jwtSettings) {
			try {
				var userToken = new UserToken();
				if(model is null) {
					throw new ArgumentNullException(nameof(model));
				}

				//obtener clabe secreta:
				var key = System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey);
				//generar id
				Guid Id;
				//Expira en un dia
				DateTime expireTime = DateTime.UtcNow.AddDays(1);

				//validacion:
				userToken.Validity = expireTime.TimeOfDay;

				//generar jwt con esta informacion:
				var jwToken = new JwtSecurityToken(
					issuer: jwtSettings.ValidIssuer,
					audience: jwtSettings.ValidAudience,
					claims: GetClaims(model, out Id),
					notBefore: new DateTimeOffset(DateTime.Now).DateTime,
					expires: new DateTimeOffset(expireTime).DateTime,
					signingCredentials: new SigningCredentials(
						new SymmetricSecurityKey(key),
						SecurityAlgorithms.HmacSha256));

				userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
				userToken.UserName = model.UserName;
				userToken.Id = model.Id;
				userToken.GuidId = Id;

				return userToken;


			} catch(Exception ex) {
				throw new Exception("Error generating the JWT", ex);
			}
		}




	}
}
