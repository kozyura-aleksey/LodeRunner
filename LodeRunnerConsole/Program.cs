using System;
using System.IO;
using System.Runtime.InteropServices;
using Controller;
using Microsoft.Win32.SafeHandles;
using View.Game;

namespace LodeRunnerConsole
{
    class Program
    {    
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            MainControllerConsole game = new MainControllerConsole();
            game.InitConsole();
        }
    }
}