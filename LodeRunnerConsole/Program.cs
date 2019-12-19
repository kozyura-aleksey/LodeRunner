using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodeRunnerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainController game = new MainController();
            game.InitConsole();
        }
    }
}
