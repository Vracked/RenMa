using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RenMa
{
    public enum DotnetCSType
    {
        Console,
        ClassLib,
        WinForms,
        WPF
    }

    public class DotnetCS
    {
        public string name;
        public string path;
        public DotnetCSType type;

        private Process cmd = new Process();

        public void Create()
        {
            switch (type)
            {
                case DotnetCSType.Console:
                    Console();
                    break;
                case DotnetCSType.ClassLib:
                    ClassLib();
                    break;
                case DotnetCSType.WinForms:
                    WinForms();
                    break;
                case DotnetCSType.WPF:
                    WPF();
                    break;
            }
        }

        private void Console()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new console --name {name} --language C# --no-update-check --use-program-main";

            cmd.Start();
        }

        private void ClassLib()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new classlib --name {name} --language C# --no-update-check";

            cmd.Start();
        }

        private void WinForms()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new winforms --name {name} --language C# --no-update-check";

            cmd.Start();
        }

        private void WPF()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new wpf --name {name} --language C# --no-update-check";

            cmd.Start();
        }
    }
}
