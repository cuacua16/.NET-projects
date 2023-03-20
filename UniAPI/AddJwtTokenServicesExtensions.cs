﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OBwebAPI.Models.DataModels;

namespace OBwebAPI {
	public static class AddJwtTokenServicesExtensions {

		public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration) {
			//add jwt settings
			var bindJwtSettings = new JwtSettings();
			configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

			//add singleton of Jwt Settings
			services.AddSingleton(bindJwtSettings);

			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => {
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters() {
					ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
					IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
					ValidateIssuer = bindJwtSettings.ValidateIssuer,
					ValidIssuer = bindJwtSettings.ValidIssuer,
					ValidateAudience = bindJwtSettings.ValidateAudience,
					ValidAudience = bindJwtSettings.ValidAudience,
					RequireExpirationTime = bindJwtSettings.RequiredExpirationTime,
					ValidateLifetime = bindJwtSettings.ValidateLifetime,
					ClockSkew = TimeSpan.FromDays(1)
				};
			});
		}
	}
}
