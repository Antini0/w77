using wyk7;

var students = new List<Student>();
students.Add(new Student
{
    IdStudent = 1,
    lastName = "kowalski",
    Age = 22
});
students.Add(new Student
{
    IdStudent = 2,
    lastName = "nowak",
    Age = 30
});
students.Add(new Student
{
    IdStudent = 3,
    lastName = "kleski",
    Age = 24
});

//============================
//SELECT Age, COUNT(*) FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20

var results = new List<Student>();


//Query syntax (lepiej nie)
var results2 = from st in students
                                where st.Age > 20 && st.lastName.Contains("A")
                                select st;

//SELECT lastName FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20
var results3 = from st in students
                                where st.Age > 20 && st.lastName.Contains("A")
                                select st.lastName;

//SELECT Age, lastName FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20

var results4 = from st in students
                                        where st.Age > 20 && st.lastName.Contains("A")
                                        select new
                                        {
                                            Nazwikso = st.lastName,
                                            Wiek = st.Age
                                        };


//===========================
//Extension Methods, Anonymous types, lambda

//SELECT Age, COUNT(*) FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20
var result5 = students.Where(st => st.Age > 20 && st.lastName.Contains("A"));

//SELECT lastName FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20
var result6 = students
                                .Where(st => st.Age > 20 && st.lastName.Contains("A"))
                                .Select(st => st.lastName);

//SELECT Age, lastName FROM Students
//WHERE lastName like 'A%' and WHERE Age > 20 and lastname.length == 10
//ORDER by lastname 
var result7 = students
    .Where(st => st.Age > 20 && st.lastName.Contains("A"))
    .Select(st => new
    {
        Nazwikso = st.lastName,
        Wiek = st.Age
    })
    .OrderBy(s => s.Nazwikso)
    .Where(s => s.Nazwikso.Length == 10); //to moze byc w pierwszym where

//SELECT Max(Age) FROM Students
var result8 = students.Max(s => s.Age);










