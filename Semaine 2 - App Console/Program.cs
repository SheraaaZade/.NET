
using LINQDataContext;

DataContext dc = new DataContext();
/*
//1
Student? jdepp = (
                    from student in dc.Students
                    where student.Login == "jdepp"
                    select student
                  )
                 .SingleOrDefault();
//2
var students = from student in dc.Students
               select new
               {
                   FullName = student.First_Name + " " + student.Last_Name,
                   Birthdate = student.BirthDate,
                   ID = student.Student_ID
               };

foreach (var student in students)
{
    Console.WriteLine("{0} {1} {2}", student.FullName, student.ID, student.Birthdate);
}
*/
//3.1

/*var students2 = from student in dc.Students
               where student.BirthDate.Year < 1955
               select new
               {
                   FullName = student.First_Name + " " + student.Last_Name,
                   Resultat = student.Year_Result,
                   Statut = student.Year_Result >= 12 ? "OK" : "KO"
               };

foreach (var student in students2)
{
    Console.WriteLine("{0} {1} {2}", student.FullName , student.Resultat , student.Statut);
}*/

//3.4
/*var results = (from student in dc.Students
               where student.Year_Result <= 3
               orderby student.Year_Result descending
               select new
               {
                   FullName = student.First_Name + " " + student.Last_Name,
                   Resultat = student.Year_Result,
               });

foreach (var student in results)
{
      Console.WriteLine(student.FullName + " " + student.Resultat);
}*/


//3.5

/*var results = from student in dc.Students
              where student.Section_ID == 1110
              orderby student.Last_Name ascending
              select new
              {
                  FullName = student.First_Name + " " + student.Last_Name,
                  Resultat = student.Year_Result,
                  categorie = student.Year_Result < 10 ? "inférieur" : student.Year_Result == 10 ? "neutre" : "supérieure"
              };

foreach (var result in results)
{
    Console.WriteLine(result);
}

*/

/*//4.1

Console.WriteLine("Résultat annuel moyen: "+ dc.Students.Average(s => s.Year_Result));

//4.5

Console.WriteLine("Nb lignes dans student: " + dc.Students.Count);
*/
//5.1

/*var sectionsResult = (from student in dc.Students
                      group student by student.Section_ID into groupedSection
                      select new
                      {
                          Category = groupedSection.Key,
                          Max_Result = groupedSection.Max(s => s.Year_Result),
                      }).ToList();

foreach (var s in sectionsResult)
{
    Console.WriteLine(s);
}

*/

//5.3
/*var resultAVG = from student in dc.Students
                where student.BirthDate.Year >= 1970 && student.BirthDate.Year <= 1985
                group student by student.BirthDate.Month into groupedStudent
                select new
                {
                    AVG_Result = groupedStudent.Average(s => s.Year_Result),
                    BirthMonth = groupedStudent.Key,
                };

foreach(var result in resultAVG)
{
    Console.WriteLine(result);
}*/

//5.5

/*var cours = from c in dc.Courses
            join p in dc.Professors on c.Professor_ID equals p.Professor_ID
            join s in dc.Sections on p.Section_ID equals s.Section_ID
            select new
            {
                c.Course_Name,
                s.Section_Name,
                p.Professor_Name,
            };

foreach(var unCours in cours)
{
    Console.WriteLine(unCours);
}*/

//5.7
var professorsSections = from s in dc.Sections
                         join p in dc.Professors on s.Section_ID equals p.Section_ID into professorsGroup
                         select new
                         {
                             Section = s.Section_ID + " " + s.Section_Name,
                             Professors = professorsGroup.Select(p => p.Professor_Name)
                         };

foreach (var section in professorsSections)
{
    Console.WriteLine("Section n°" + section.Section + ":");
    foreach (var prof in section.Professors)
    {
        Console.WriteLine("\t -" + prof);
    }
}