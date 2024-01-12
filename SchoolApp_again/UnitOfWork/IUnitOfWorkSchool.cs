using School.Repository;
using SchoolApp_again.Models;


namespace SchoolApp.UnitOfWork
{
    internal interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }
        IStudentRepository StudentsRepository { get; }

    }
}
