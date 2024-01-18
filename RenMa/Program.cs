/*
    Licensed under the GNU GPL Version 3, 29 June 2007
    Code by: @Vracked (https://github.com/Vracked)
 */

using System;
using System.IO;

namespace RenMa
{
    class Program
    {
        public static void Main(string[] args)
        {
            CppClass? cppClass = new CppClass();
            DotnetCS? dotnetCS = new DotnetCS();
            DotnetVB? dotnetVB = new DotnetVB();

            // Main loop
            while (true)
            {
                Console.WriteLine("Select any one of these (Enter 'quit()' to exit):");
                Console.WriteLine("1. C++ Class");
                Console.WriteLine("2. .NET C#");
                Console.WriteLine("3. .NET VB");
                string? genType = Console.ReadLine();

                if (genType == string.Empty || genType == null)
                {
                    Console.WriteLine("You have to select one.");
                    Console.WriteLine("Or if you wanted to quit the program then type 'quit()'.");
                    genType = Console.ReadLine();
                }

                if (genType == "quit()")
                {
                    break;
                }

                if (genType == "1")
                    CppClassGen();
                else if (genType == "2")
                    DotnetCS();
                else if (genType == "3")
                    DotnetVB();
            }

            void CppClassGen() 
            {
                // Get the path to create the class on
                Console.WriteLine("\nEnter the path to create this class in (Use forward slashes (/ this one)):");
                cppClass.path = Console.ReadLine();
                if (cppClass.path == null || cppClass.path == string.Empty)
                {
                    Console.WriteLine("\nPath is invalid");
                    Console.Write("Please enter a valid file path: ");
                    cppClass.path = Console.ReadLine();
                }
                else if (!Directory.Exists(cppClass.path))
                {
                    Directory.CreateDirectory(cppClass.path);
                }

                // Get the name of the class
                Console.Write("Enter the class name (No spaces): ");
                cppClass.name = Console.ReadLine();
                if (cppClass.name.Contains(' '))
                {
                    Console.WriteLine("Name contains spaces");
                    Console.Write("Enter the name again: ");
                    cppClass.name = Console.ReadLine();
                }
                else
                {
                    cppClass.Create();
                    Console.WriteLine("===========Done!===========");
                }
            }

            #region .NET Stuff
            void DotnetCS()
            {
                Console.WriteLine("\nSelect any one of these:");
                Console.WriteLine("1. Console app");
                Console.WriteLine("2. Class library");
                Console.WriteLine("3. WinForms");
                Console.WriteLine("4. WPF");
                string tempType = Console.ReadLine();

                if (tempType == null || tempType == string.Empty)
                {
                    Console.WriteLine("You have to select one.");
                    tempType = Console.ReadLine();
                }

                switch (tempType)
                {
                    case "1":
                        dotnetCS.type = DotnetCSType.Console;
                        break;
                    case "2":
                        dotnetCS.type = DotnetCSType.ClassLib;
                        break;
                    case "3":
                        dotnetCS.type = DotnetCSType.WinForms;
                        break;
                    case "4":
                        dotnetCS.type = DotnetCSType.WPF;
                        break;
                }

                Console.Write("Enter the folder to create this in: ");
                dotnetCS.path = Console.ReadLine();

                if (dotnetCS.path == null || dotnetCS.path == string.Empty)
                {
                    Console.WriteLine("\nPath is invalid");
                    Console.Write("Please enter a valid file path: ");
                    dotnetCS.path = Console.ReadLine();
                }
                else if (!Directory.Exists(dotnetCS.path))
                {
                    Directory.CreateDirectory(dotnetCS.path);
                }

                Console.Write("Enter the name of the project: ");
                dotnetCS.name = Console.ReadLine();

                if (dotnetCS.name == null || dotnetCS.name == string.Empty)
                {
                    Console.WriteLine("\nName is invalid");
                    Console.Write("Please enter a valid name: ");
                    dotnetCS.path = Console.ReadLine();
                }
                else
                {
                    dotnetCS.Create();
                    Console.WriteLine("===========Done!===========");
                }
            }

            void DotnetVB()
            {
                Console.WriteLine("\nSelect any one of these:");
                Console.WriteLine("1. Console app");
                Console.WriteLine("2. Class library");
                Console.WriteLine("3. Empty");
                Console.WriteLine("4. WinForms");
                Console.WriteLine("5. WPF");
                string tempType = Console.ReadLine();

                if (tempType == null || tempType == string.Empty)
                {
                    Console.WriteLine("You have to select one.");
                    tempType = Console.ReadLine();
                }

                switch (tempType)
                {
                    case "1":
                        dotnetVB.type = DotnetVBType.Console; 
                        break;
                    case "2":
                        dotnetVB.type = DotnetVBType.ClassLib;
                        break;
                    case "3":
                        dotnetVB.type = DotnetVBType.Empty;
                        break;
                    case "4":
                        dotnetVB.type = DotnetVBType.WinForms;
                        break;
                    case "5":
                        dotnetVB.type = DotnetVBType.WPF;
                        break;
                }

                if (dotnetVB.path == null || dotnetVB.path == string.Empty)
                {
                    Console.WriteLine("\nPath is invalid");
                    Console.Write("Please enter a valid file path: ");
                    dotnetVB.path = Console.ReadLine();
                }
                else if (!Directory.Exists(dotnetVB.path))
                {
                    Directory.CreateDirectory(dotnetVB.path);
                }

                Console.Write("Enter the name of the project: ");
                dotnetCS.name = Console.ReadLine();

                if (dotnetVB.name == null || dotnetVB.name == string.Empty)
                {
                    Console.WriteLine("\nName is invalid");
                    Console.Write("Please enter a valid name: ");
                    dotnetVB.path = Console.ReadLine();
                }
                else
                {
                    dotnetVB.Create();
                    Console.WriteLine("===========Done!===========");
                }
            }
            #endregion
        }
    }
}
