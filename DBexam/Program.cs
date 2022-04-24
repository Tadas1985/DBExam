using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq;

namespace DBexam
{
    internal class Program
    {
        public static UniversityContext UC;
        
        public static UniversityContext GetContext()
        {
            if (UC == null)
            {
                RegenerateContext();
            }
            return UC;   
        }
        public static void RegenerateContext()
        {
            UC = new UniversityContext();
        }
        public static void PrintAllDepartments()
        {
            Console.WriteLine("Departments:");           
            foreach (var department in GetContext().DepartmentSet)
                Console.WriteLine(department.Name);
        }

        public static IQueryable<Lecture> GetLectureByName(string name)
        {
            return GetContext().LectureSet.Where(x => x.Name == name);
        }
        public static IQueryable<Department> GetDepartmentByName(string name)
        {
            return GetContext().DepartmentSet.Where(x => x.Name == name);
        }
        public static void ShowAllStudentsInDepartment()
        {
            PrintAllDepartments();
            var departmentName = AskQuestion("What department you are intereted in:");
            
            
            foreach (var department in GetDepartmentByName(departmentName).Include(x => x.Students))
            {
                Console.WriteLine($"{department.Name} department students:");
                foreach (var student in department.Students)
                {
                    Console.WriteLine($"    {student.FirstName} {student.LastName}");
                }
            }
        }
        public static void ShowAllLecturesInDepartment()
        {
            PrintAllDepartments();
            Console.WriteLine("What department you are intereted in:");
            var departmentName = Console.ReadLine();
            foreach (var department in GetContext().DepartmentSet.Where(x => x.Name == departmentName).Include(x => x.Lectures))
            {
                Console.WriteLine($"{department.Name} department lectures:");
                foreach (var lecture in department.Lectures)
                {
                    Console.WriteLine($"    {lecture.Name}");
                }
            }
        }
        public static void PrintAllLectures()
        {
            Console.WriteLine("Lectures:");
            foreach (var l in GetContext().LectureSet)
                Console.WriteLine(l.Name);

        }
        public static void PrintAllStudents()
        { 
            Console.WriteLine("Students:");
            foreach (var s in GetContext().StudentSet)
                Console.WriteLine($"Name {s.FirstName} Lastname {s.LastName} ");
            
        }
        public static IQueryable<Student> GetStudentsByFirstAndLastName(string name, string lastname)
        {
            return GetContext().StudentSet.Where(x => x.FirstName == name && x.LastName == lastname);
        }
        public static void ShowAllLecturesThatBelongsToStudent()
        {
            PrintAllStudents();
            var firstName = AskQuestion("Enter student Firstname:");
            var lastName = AskQuestion("Enter student Lastname:");
            
            foreach (var student in GetStudentsByFirstAndLastName(firstName, lastName).Include(x => x.LecturesList))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} has lectures:");
                foreach (var lecture in student.LecturesList)
                {
                    Console.WriteLine($"    {lecture.Name}");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Information System");

            while (true) 
            {
                RegenerateContext();
                switch (Menu.SystemMenuOptions())
                {
                    case 1:
                        AddDepartment();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        AddLecture();
                        break;
                    case 4:
                        CreateRelationshipBetweenDepartmentAndStudent();
                        break;
                    case 5:
                        CreateRelationshipBetweenDepartmentAndLecture();
                        break;
                    case 6:
                        CreateRelationshipBetweenStudentAndLecture();
                        break;
                    case 7:
                        ShowAllStudentsInDepartment();
                        break;
                    case 8:
                        ShowAllLecturesInDepartment();
                        break;
                    case 9:
                        ShowAllLecturesThatBelongsToStudent();
                        break;
                    case 10:
                        MoveStudentToAnotherDepartment();
                        break;
                    case 11:
                        Menu.Exit();
                        break;
                    




        
                }
            }
        }

        private static void CreateRelationshipBetweenDepartmentAndStudent()
        {
            PrintAllDepartments();
            var departmentName = AskQuestion("In which department you would like to add?");
            PrintAllStudents();
            var studentName = AskQuestion($"Enter student name would you like to relate to {departmentName} department");
            var studentLastName = AskQuestion($"Enter student last name would you like to relate to {departmentName} department");
        
            foreach (var student in GetStudentsByFirstAndLastName(studentName, studentLastName))
            {
                foreach (var department in GetDepartmentByName(departmentName))
                {
                    student.DP = department;
                    Console.WriteLine("Adding relationship");
                    
                }
            }
            GetContext().SaveChanges();


        }

        private static void AddLecture()
        {
            using var db = GetContext();
            db.LectureSet.Add(
                new Lecture(
                    AskQuestion("What lecture would you like to add?")
                )
            );
            db.SaveChanges();
        }

        public static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        private static void AddDepartment()
        {
            using var db = GetContext();
            db.DepartmentSet.Add(
                new Department(
                    AskQuestion("What department you would like to create")
                )
            );
            db.SaveChanges();
        }
        private static void AddStudent()
        {
            using var db = GetContext();
            db.StudentSet.Add(
                new Student(
                    AskQuestion("Name?"),
                    AskQuestion("Lastname?")
                )
            );
            db.SaveChanges();
        }

        private static void CreateRelationshipBetweenDepartmentAndLecture()
        {
            PrintAllDepartments();
            var departmentName = AskQuestion("In which department you would like to add?");
            PrintAllLectures();
            var lectureTitle = AskQuestion($"Enter lecture name would you like to relate to {departmentName} department");
            

            foreach (var lecture in GetLectureByName(lectureTitle))
            {
                foreach (var department in GetDepartmentByName(departmentName))
                {
                    lecture.Deparetments.Add(department);
                    Console.WriteLine("Adding relationship");

                }
            }
            GetContext().SaveChanges();


        }

        private static void CreateRelationshipBetweenStudentAndLecture()
        {
            PrintAllLectures();
            var lectureName = AskQuestion("In which lecture you would like to add?");
            PrintAllStudents();
            var studentName = AskQuestion($"Enter student name would you like to relate to {lectureName} lecture");
            var studentLastName = AskQuestion($"Enter student last name would you like to relate to {lectureName} lecture");

            foreach (var student in GetStudentsByFirstAndLastName(studentName, studentLastName))
            {
                foreach (var lecture in GetLectureByName(lectureName))
                {
                    student.LecturesList.Add(lecture);
                    Console.WriteLine("Adding relationship");

                }
            }
            GetContext().SaveChanges();


        }
        private static void MoveStudentToAnotherDepartment()
        {
            PrintAllDepartments();
            var departmentName = AskQuestion("To which department you would like to move?");
            PrintAllStudents();
            var studentName = AskQuestion($"Enter student name would you like to move to {departmentName} department");
            var studentLastName = AskQuestion($"Enter student last name would you like to move to {departmentName} department");

            foreach (var student in GetStudentsByFirstAndLastName(studentName, studentLastName).Include(y => y.LecturesList))
            {
                foreach (var department in GetDepartmentByName(departmentName).Include(x => x.Lectures))
                {
                    student.DP = department;
                    student.LecturesList.Clear();
                    foreach (var lecture in department.Lectures)
                    {
                        student.LecturesList.Add(lecture);
                    }
                    Console.WriteLine("Adding relationship");

                }
            }
            GetContext().SaveChanges();


        }
    }
}
