using LabsSchoolDBApp.Data;
using LabsSchoolDBApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabsSchoolDBApp
{
    internal class Menu
    {
        public static void MainMenu()
        {

            while (true)
            {

                Console.WriteLine("1. Hantera elever");
                Console.WriteLine("2. Hantera personal");
                Console.WriteLine("3. Visa kurser");
                Console.WriteLine("4. Visa avdelningar");
                Console.WriteLine("5. Avsluta");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        StudentMainMenu();
                        break;
                    case "2":
                        Console.Clear();
                        StaffMainMenu();
                        break;
                    case "3":
                        Console.Clear();
                        Helper.ShowCourses();
                        break;
                    case "4":
                        Console.Clear();
                        Helper.ShowDepartments();
                        break;
                    case "5":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }

        public static void StudentMainMenu()
        {

            while (true)
            {

                Console.WriteLine("1. Visa elever");
                Console.WriteLine("2. Lägg till elev");
                Console.WriteLine("3. Gå tillbaka");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        ShowStudentsMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Helper.AddStudent();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }

        }

        public static void StaffMainMenu()
        {

            while (true)
            {
                Console.WriteLine("1. Visa personal");
                Console.WriteLine("2. Lägg till personal");
                Console.WriteLine("3. Gå tillbaka");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        ShowStaffMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Helper.AddStaff();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }


        public static void ShowStudentsMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Visa alla elever");
                Console.WriteLine("2. Visa klasser");
                Console.WriteLine("3. Gå tillbaka");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Helper.ShowStudents();
                        break;
                    case "2":
                        Console.Clear();
                        Helper.ShowClasses();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }


        public static void ShowStaffMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Visa all personal");
                Console.WriteLine("2. Visa avdelningar");
                Console.WriteLine("3. Gå tillbaka");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Helper.ShowStaff();
                        break;
                    case "2":
                        Console.Clear();
                        Helper.ShowDepartments();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }



        public static void StudentMenu(string student)
        {
            using var context = new LabsSchoolDBContext();
            var studentObject = context.Students.Where(s => s.PersonalNr == student).SingleOrDefault();
             
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Elev: {studentObject!.FirstName} {studentObject!.LastName}");
                Console.WriteLine("1. Visa kurser");
                Console.WriteLine("2. Sätt betyg");
                Console.WriteLine("3. Gå tillbaka");
                Console.WriteLine();
                string? userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Helper.ShowStudentCourses(student);
                        break;
                    case "2":
                        Console.Clear();
                        Helper.GradeStudent(student);
                        return;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\t\tOgiltigt val. Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                }
            
                Console.Clear();
            
            }

        }
        
    }
}
