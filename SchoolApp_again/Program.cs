

using School.Repository;
using SchoolApp.Repository;
using SchoolApp.UnitOfWork;
using SchoolApp_again.Models;
using SchoolProject.Repository;

IRepository<Section> repoSect = new SectionRepositoryMemory();
Section sectInfo = new Section { Name = "Info" };
Section sectDiet = new Section { Name = "Diet" };

repoSect.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));
repoSect.Save(sectDiet, s => s.Name.Equals(sectDiet.Name));

//AFFICHAGE DE LA LISTE
Console.WriteLine("Affichage des sections: ");


foreach (var section in repoSect.GetAll())
{
    Console.WriteLine("\t" + section.Name);
}


SchoolContext context = new SchoolContext();

//Ajout 3 étudiants
IStudentRepository repoStu = new StudentRepositorySQLServer(context);


Student stud1 = new Student()
{
    Firstname = "SHERA",
    Name = "ZADE",
    Section = sectInfo,
    YearResult = 100
};

Student studdiet = new Student
{
    Firstname = "M",
    Name = "STUPID",
    Section = sectDiet,
    YearResult = 120
};

Student studinfo2 = new Student
{
    Firstname = "AYA",
    Name = "L ABEILLE",
    Section = sectInfo,
    YearResult = 110
};

repoStu.Save(stud1, s => s.Name.Equals(stud1.Name) && s.Firstname.Equals(stud1.Firstname));
repoStu.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));
repoStu.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
//AFFICHAGE DE LA LISTE
Console.WriteLine("Affichage des étudiants: ");

foreach (var section in repoStu.GetAll())
{
    Console.WriteLine("\t" + section.Firstname + " " + section.Name);
}


IList<Student> studs = repoStu.GetStudentBySectionOrderByYearResult();

foreach (Student s in studs)
{
    Console.WriteLine(s.Firstname + " " + s.Name);

}


//***************

IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSQLServer(context);
IStudentRepository repoStud = unitOfWorkSchool.StudentsRepository;


repoStud.Save(stud1, s => s.Name.Equals(stud1.Name) && s.Firstname.Equals(stud1.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
//AFFICHAGE DE LA LISTE
Console.WriteLine("Affichage des étudiants: ");

foreach (var section in repoStud.GetAll())
{
    Console.WriteLine("\t" + section.Firstname + " " + section.Name);
}