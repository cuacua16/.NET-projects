using OBwebAPI.Models.DataModels;

namespace OBwebAPI.Services {
	public interface IStudentService {
		IEnumerable<Student> GetStudentsWithCourses();
		IEnumerable<Student> GetStudentsWithNoCourses();
	}
}
