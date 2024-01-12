using School.Repository;
using SchoolApp.Models;

namespace SchoolApp.Repository
{
    public class StudentRepositorySQLServer : BaseRepositorySQL<Student>, IStudentRepository
    {

        public StudentRepositorySQLServer(SchoolContext dbcontext) : base(dbcontext) { }

        public IList<Student> GetStudentBySectionOrderByYearResult()
        {
            IList<Student> students = (from Student s in _dbContext.Set<Student>()
                                       orderby s.Section.Name, s.YearResult descending
                                       select s).ToList();

            return students;
        }
    }

}
