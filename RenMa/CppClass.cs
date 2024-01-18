/*
    Licensed under the GNU GPL Version 3, 29 June 2007
    Code by: @Vracked (https://github.com/Vracked)
 */

using System;
using System.IO;

namespace RenMa
{
    // ===================================
    // For creating/generating a C++ class
    // ===================================
    public class CppClass
    {
        // Name and path is set to nullable because of some warnings (These variable can't be null in any ways in my knowledge)
        public string? name;
        public string? path;

        // Add the header contents/code in an array because C# needs an array of string in the File.WriteAllLines method
        private readonly string[] headerContents = new string[6];
        private readonly string[] headerContentsUnnamed = new string[6];

        public void Create()
        {
            SetupHeaderContents();

            if (name == string.Empty)
            {
                File.WriteAllLines($"{path}/CppClass.h", headerContentsUnnamed);
                File.WriteAllText($"{path}/CppClass.cpp", $"#include \"CppClass.h\"\n");
            }
            else
            {
                File.WriteAllLines($"{path}/{name}.h", headerContents);
                File.WriteAllText($"{path}/{name}.cpp", $"#include \"{name}.h\"");
            }
        }

        // Header files being set up in another method for readability
        private void SetupHeaderContents()
        {
            /*                                      
                                                     
             If the name variable isn't empty:      If the name variable is empty:
               
             #pragma once                           #pragma once
             
             class NAME                             class CppClass
             {                                      {
                
             };                                     };

             */
            headerContents[0] = "#pragma once"; headerContentsUnnamed[0] = "#pragma once";
            headerContents[1] = ""; headerContentsUnnamed[1] = "";
            headerContents[2] = $"class {name}"; headerContentsUnnamed[2] = "class CppClass";
            headerContents[3] = "{"; headerContentsUnnamed[3] = "{";
            headerContents[4] = "   "; headerContentsUnnamed[4] = "   ";
            headerContents[5] = "};"; headerContentsUnnamed[5] = "};";
        }
    }
}
