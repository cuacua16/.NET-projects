using OBwebAPI.Models.DataModels;

namespace OBwebAPI.Services {
	public static class Services {

		public static User FindUserByEmail(string email) {
			User[] users = { };
			User user1 = users.First(x => x.Email == email);
			return user1;
		}

		public static List<Student>? FindAllAdultStudents() {
			Student[] students = { };
			var adultStudents = students.Where(x => DateTime.Now.Year - x.Dob.Year > 17).ToList();
			return adultStudents;

		}

		public static List<Student> FindAllStudentsWithCourses() {
			Student[] students = { };
			var studentsWithCourses = students.Where(x => x.Courses.Count > 0).ToList();
			return studentsWithCourses;
		}

		public static List<Course> FindAllCoursesWithStudents() {
			Course[] courses = { };
			var coursesWithStudents = courses.Where(x => x.Students.Count > 0).ToList();
			return coursesWithStudents;

		}

		public static List<Course> FindAllCoursesWithCategory() {
			Course[] courses = { };
			var coursesWithCategory = courses.Where(x => x.Categories.Count > 0).ToList();
			return coursesWithCategory;

		}

		public static List<Course> FindAllEmptyCourses() {
			Course[] courses = { };
			var emptyCourses = courses.Where(x => x.Students.Count == 0).ToList();
			return emptyCourses;
		}
	}
}
