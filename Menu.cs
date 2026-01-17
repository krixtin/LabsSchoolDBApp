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
                Console.WriteLine("3. Avsluta");
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
                        ShowStudentsMenu();
                        break;
                    case "2":
                        AddStudent();
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
                        ShowStaffMenu();
                        break;
                    case "2":
                        AddStaff();
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
            Console.Clear();
            Console.WriteLine("Visa elever - Funktionalitet ej implementerad än.");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
        }

        public static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Lägg till elev - Funktionalitet ej implementerad än.");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
        }

        public static void ShowStaffMenu()
        {
            Console.Clear();
            Console.WriteLine("Visa personal - Funktionalitet ej implementerad än.");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
        }

        public static void AddStaff()
        {
            Console.Clear();
            Console.WriteLine("Lägg till personal - Funktionalitet ej implementerad än.");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();

        }

    }
}
