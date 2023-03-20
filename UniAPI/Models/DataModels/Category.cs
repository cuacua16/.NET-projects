using System.ComponentModel.DataAnnotations;

namespace OBwebAPI.Models.DataModels {
	public class Category : BaseEntity {
		[Required, StringLength(50)]
		public string Name { get; set; } = string.Empty;

		public ICollection<Course> Courses { get; set; } = new List<Course>();
	}
}
