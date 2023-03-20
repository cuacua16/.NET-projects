using System.ComponentModel.DataAnnotations;

namespace OBwebAPI.Models.DataModels {
	public class UserLogins {
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

	}
}
