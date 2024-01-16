using System;
using System.IO;

namespace RenMa
{
    public class CppClass
    {
        public string? name;
        public string? path;

        private readonly char doubleQuote = '"';
        private readonly string[] headerContents = new string[6];
        private readonly string[] headerContentsUnnamed = new string[6];

        public void Create()
        {
            SetupHeaderContents();

            if (name == string.Empty)
            {
                File.WriteAllLines($"{path}/CppClass.h", headerContentsUnnamed);
                File.WriteAllText($"{path}/CppClass.cpp", $"#include {doubleQuote}CppClass.h{doubleQuote}\n");
            }
            else
            {
                File.WriteAllLines($"{path}/{name}.h", headerContents);
                File.WriteAllText($"{path}/{name}.cpp", $"#include {doubleQuote}{name}.h{doubleQuote}");
            }
        }

        private void SetupHeaderContents()
        {
            headerContents[0] =                "#pragma once";     headerContentsUnnamed[0] =                "#pragma once";
            headerContents[1] =                "";                 headerContentsUnnamed[1] =                "";
            headerContents[2] =               $"class {name}";     headerContentsUnnamed[2] =                "class CppClass";
            headerContents[3] =                "{";                headerContentsUnnamed[3] =                "{";
            headerContents[4] =                "   ";              headerContentsUnnamed[4] =                "   ";
            headerContents[5] =                "};";               headerContentsUnnamed[5] =                "};";
        }
    }
}
