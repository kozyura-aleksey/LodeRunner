using System;
using System.IO;
using System.Runtime.InteropServices;
using Controller;
using Microsoft.Win32.SafeHandles;

namespace LodeRunnerConsole
{
    class Program
    {    
        [STAThread]
        static void Main(string[] args)
        {
            MainController game = new MainController();
            game.InitConsole();
        }
    }
}