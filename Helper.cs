using LabsSchoolDBApp.Data;
using LabsSchoolDBApp.Models;
using System;
using System.Collections.Generic;
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
            Console.Write("Ange klass: ");
            newStudent.ClassCode = Console.ReadLine();

            if (context.Students.Any(s => s.PersonalNr == newStudent.PersonalNr))
            {
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
                Console.WriteLine("Eleven har lagts till.");
            }
            else
            {
                Console.WriteLine("Något gick fel, eleven kunde inte läggas till.");
            }


        }

        public static void ShowClasses()
        {
            
        }

        public static void SortStudents()
        {

        }

        public static void AddStaff()
        {

        }

        public static void ShowDepartments()
        {

        }

        public static void SortStaff()
        {

        }


    }
}
