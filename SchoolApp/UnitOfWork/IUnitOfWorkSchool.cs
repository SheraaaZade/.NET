using School.Repository;
using SchoolApp.Models;

namespace SchoolApp.UnitOfWork
{
    internal interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }
        IStudentRepository StudentsRepository { get; }

    }
}
