using School.Repository;
using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolApp.UnitOfWork;
using SchoolProject.Repository;

IRepository<Section> repoSect = new SectionRepositoryMemory();
Section sectInfo = new Section { Name = "Info" };
Section sectDiet = new Section { Name = "Diet" };

//add sectInfo
repoSect.Save(sectInfo, s => s.Name.Equals(sectInfo.Name));

//add sectDiet
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
Student studinfo1 = new Student
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

repoStu.Save(studinfo1, s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname));
repoStu.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));
repoStu.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));

//AFFICHAGE DE LA LISTE
Console.WriteLine("Affichage des étudiants: ");

foreach (var section in repoStu.GetAll())
{
    Console.WriteLine("\t" + section.Firstname + " " + section.Name);
}

// Aller plus loin
IList<Student> students = repoStu.GetStudentBySectionOrderByYearResult();

foreach (var student in students)
{
    Console.WriteLine(student.Firstname + " " + student.Name);
}


//*********************VERSION UNITOFWORK***************************
Console.WriteLine("***************VERSION UNITOFWORK******************");

IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSQLServer(context);
IStudentRepository repoStud = unitOfWorkSchool.StudentsRepository;

repoStud.Save(studinfo1, s => s.Name.Equals(studinfo1.Name) && s.Firstname.Equals(studinfo1.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
//AFFICHAGE DE LA LISTE
Console.WriteLine("Affichage des étudiants: ");

foreach (var section in repoStud.GetAll())
{
    Console.WriteLine("\t" + section.Firstname + " " + section.Name);
}