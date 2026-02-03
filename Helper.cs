using LabsSchoolDBApp.Data;
using LabsSchoolDBApp.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LabsSchoolDBApp
{
    internal class Helper
    {

        public static void AddStudent()
        {
            using var context = new LabsSchoolDBContext();

            var newStudent = new Student();
            Console.Write("Ange förnamn: ");
            newStudent.FirstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            newStudent.LastName = Console.ReadLine();
            Console.Write("Ange personnummer (ÅÅMMDDXXXX): ");
            newStudent.PersonalNr = Console.ReadLine();
            if (newStudent.PersonalNr.Length != 10)
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Personnumret måste anges i formatet ÅÅMMDDXXXX.");
                Console.ReadKey();
                return;
            }
            Console.Write("Ange klass: ");
            newStudent.ClassCode = Console.ReadLine();
            if (newStudent.ClassCode.Length != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Klasskoden måste ha exakt fyra (4) tecken.");
                Console.ReadKey();
                return;
            }
            if (!context.Classes.Any(c => c.ClassCode == newStudent.ClassCode))
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Det finns ingen klass med det namnet.");
                Console.ReadKey();
                return;
            }

            if (context.Students.Any(s => s.PersonalNr == newStudent.PersonalNr))
            {
                Console.WriteLine();
                Console.WriteLine("En elev med detta personnummer finns redan.");
                Console.ReadKey();
                return;
            }
            else
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            if (context.Students.Any(s => s.PersonalNr == newStudent.PersonalNr))
            {
                Console.WriteLine();
                Console.WriteLine("Eleven har lagts till.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Något gick fel, eleven kunde inte läggas till.");
                Console.ReadKey();
                return;
            }
        }

        public static void ShowClasses()
        {
            using var context = new LabsSchoolDBContext();
            var classes = context.Classes.ToList();
            Console.WriteLine("Klasser:");
            foreach (var c in classes)
            {
                Console.WriteLine($"{c.ClassCode}");
            }
            Console.WriteLine("Vilken klass vill du visa?");
            var classToView = Console.ReadLine();
            
            if (context.Classes.Any(c => c.ClassCode == classToView))
            {
                ShowStudents(classToView);
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Det finns ingen klass med det namnet.");
            }

            Console.ReadKey();
        }

        

        public static void ShowStudents()
        {
            Console.WriteLine("Välj sortering:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            string? sortName = Console.ReadLine();
            Console.WriteLine("1. Stigande");
            Console.WriteLine("2. Fallande");
            string? sortDesc = Console.ReadLine();
            Console.Clear();
            if (sortName != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortName)
                {
                    case "1":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .OrderBy(s => s.FirstName)
                                .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }   
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                                .OrderByDescending(s => s.FirstName)
                                .ToList();

                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    case "2":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .OrderBy(s => s.LastName)
                                .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                            .OrderByDescending(s => s.LastName)
                            .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att gå tillbaka.");
                        Console.ReadKey();
                        return;
                }

                Console.WriteLine();
                ShowStudent();
                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
                Console.ReadKey();
            }
        }

        private static void ShowStudents(string? classToView)
        {
            Console.WriteLine("Välj sortering:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            string? sortName = Console.ReadLine();
            Console.WriteLine("1. Stigande");
            Console.WriteLine("2. Fallande");
            string? sortDesc = Console.ReadLine();
            Console.Clear();
            if (sortName != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortName)
                {
                    case "1":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode== classToView)
                                .OrderBy(s => s.FirstName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode == classToView)
                                .OrderByDescending(s => s.FirstName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    case "2":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode == classToView)
                                .OrderBy(s => s.LastName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                            .Where(students => students.ClassCode == classToView)
                            .OrderByDescending(s => s.LastName)
                            .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att gå tillbaka.");
                        Console.ReadKey();
                        return;
                }
                Console.WriteLine();
                ShowStudent();
                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
                Console.ReadKey();
            }
        }



        public static void AddStaff()
        {
            using var context = new LabsSchoolDBContext();
            var newEmployee = new Employee();
            Console.Write("Ange förnamn: ");
            newEmployee.FirstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            newEmployee.LastName = Console.ReadLine();
            Console.Write("Ange avdelnings-ID: \n1. Rektor\n2. Lärare\n3. HR\n");
            string? userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    newEmployee.DepartmentId = 1;
                    break;
                case "2":
                    newEmployee.DepartmentId = 2;
                    break;
                case "3":
                    newEmployee.DepartmentId = 3;
                    break;
                default:
                    Console.WriteLine("\n\n\t\tFel. Ange avdelnings-ID med en siffra.\n\t\tTryck på valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    return;
            }
            Console.WriteLine("Ange anställningsdatum (ÅÅÅÅ-MM-DD): ");
            try 
            {
                newEmployee.EmploymentDate = DateOnly.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n\t\tFel. Anställningsdatum måste anges i formatet ÅÅÅÅ-MM-DD.\n\t\tTryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Ange lön: ");
            try
            {
                newEmployee.Salary = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n\t\tFel. Lön måste anges som ett heltal.\n\t\tTryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
                return;
            }

            if (context.Employees.Any(s => (s.FirstName == newEmployee.FirstName) && (s.LastName == newEmployee.LastName)))
            {
                Console.WriteLine();
                Console.WriteLine("En anställd med detta namn finns redan. Kontakta IT-avdelningen om du ändå vill lägga till hen.");
                Console.ReadKey();
                return;
            }
            else
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }

            if (context.Employees.Any(s => (s.FirstName == newEmployee.FirstName) && (s.LastName == newEmployee.LastName)))
            {
                Console.WriteLine();
                Console.WriteLine("Den anställda har lagts till.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Något gick fel, den anställda kunde inte läggas till.");
                Console.ReadKey();
                return;
            }

        }

        public static void ShowDepartments()
        {
            using var context = new LabsSchoolDBContext();
            var departments = context.Departments.ToList();
            Console.WriteLine("Avdelningar:");
            foreach (var d in departments)
            {
                Console.WriteLine($"{d.DepartmentName} - Antal anställda: {context.Employees.Count(e => e.DepartmentId == d.DepartmentId)}");
            }
            Console.WriteLine("\nVilken avdelning vill du visa? ");
            var deptToView = Console.ReadLine();
            if (context.Departments.Any(d => d.DepartmentName == deptToView))
            {
                ShowStaff(deptToView);
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Det finns ingen avdelning med det namnet.");
                Console.ReadKey();
                return;
            }
        }

        private static void ShowStaff(string? deptToView)
        {
            using var context = new LabsSchoolDBContext();
            var employees = context.Employees
                .Where(e => e.Department.DepartmentName == deptToView)
                .ToList();
            Console.WriteLine($"Avdelning: {deptToView}");
            foreach (var e in employees)
            {
                Console.WriteLine($"Namn: {e.FirstName} {e.LastName} - Anställningsdatum: {e.EmploymentDate} - Lön: {e.Salary} SEK");
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
            Console.ReadKey();
        }

        public static void ShowStaff()
        {
            using var context = new LabsSchoolDBContext();
            var employees = context.Employees
                .Join(context.Departments,
                      e => e.DepartmentId,
                      d => d.DepartmentId,
                      (e, d) => new { e.FirstName, e.LastName, e.EmploymentDate, e.Salary, Department = d })
                .ToList();
            foreach (var e in employees)
            {
                Console.WriteLine($"Namn: {e.FirstName} {e.LastName} - Avdelning: {e.Department.DepartmentName} - Anställningsdatum: {e.EmploymentDate} - Lön: {e.Salary} SEK");
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
            Console.ReadKey();
        }

        public static void ShowCourses()
        {
            using var context = new LabsSchoolDBContext();
            var courses = context.Courses.ToList();
            Console.WriteLine("Kurser:");
            foreach (var c in courses)
            {
                Console.WriteLine($"{c.CourseName}");
            }
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
            Console.ReadKey();

        }

        public static void ShowStudent()
        {
            using var context = new LabsSchoolDBContext();
            Console.WriteLine("\nVilken elev vill du visa? ");
            var student = Console.ReadLine();
            if (context.Students.Any(s => (s.FirstName + ' ' + s.LastName) == student))
            {
                Menu.StudentMenu(student);
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Det finns ingen elev med det namnet.");
                Console.ReadKey();
                return;
            }
        }


    }
}
