/*
    Licensed under the GNU GPL Version 3, 29 June 2007
    Code by: @Vracked (https://github.com/Vracked)
 */

using System.Diagnostics;

namespace RenMa
{
    public enum DotnetVBType
    {
        Console,
        ClassLib,
        Empty,
        WinForms,
        WPF
    }

    public class DotnetVB
    {
        public string name;
        public string path;
        public DotnetVBType type;

        private Process cmd = new Process();

        public void Create()
        {
            switch(type)
            {
                case DotnetVBType.Console:
                    Console();
                    break;
                case DotnetVBType.ClassLib:
                    ClassLib();
                    break;
                case DotnetVBType.Empty:
                    Empty();
                    break;
                case DotnetVBType.WinForms:
                    WinForms();
                    break;
                case DotnetVBType.WPF:
                    WPF();
                    break;
            }
        }

        private void Console()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new console --name {name} --language VB --no-update-check";

            cmd.Start();
        }

        private void ClassLib()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new classlib --name {name} --language VB --no-update-check";

            cmd.Start();
        }

        private void Empty()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new empty --name {name} --language VB --no-update-check";

            cmd.Start();
        }

        private void WinForms()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new winforms --name {name} --language VB --no-update-check";

            cmd.Start();
        }

        private void WPF()
        {
            cmd.StartInfo.UseShellExecute = true;
            cmd.StartInfo.WorkingDirectory = path;
            cmd.StartInfo.FileName = "dotnet";
            cmd.StartInfo.Arguments = $"new wpf --name {name} --language VB --no-update-check";

            cmd.Start();
        }
    }
}
