using School.Repository;
using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolProject.Repository;

namespace SchoolApp.UnitOfWork
{
    internal class UnitOfWorkSchoolMemory : IUnitOfWorkSchool
    {
        private SectionRepositoryMemory _sectionsRepository;

        private StudentRepositoryMemory _studentsRepository;

        public UnitOfWorkSchoolMemory()
        {
            this._sectionsRepository = new SectionRepositoryMemory();
            this._studentsRepository = new StudentRepositoryMemory();
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentsRepository; }
        }

    }
}
