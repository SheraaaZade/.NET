using SchoolApp_again.Models;

namespace School.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {        IList<Student> GetStudentBySectionOrderByYearResult();
    }
}