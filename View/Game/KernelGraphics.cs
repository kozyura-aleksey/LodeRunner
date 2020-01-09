using Microsoft.Win32.SafeHandles;
using Model.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// Класс поле быстрой буферизации
    /// </summary>
    internal class KernelGraphics
    {
        short _width;
        short _height;

        SafeFileHandle _fileHandle;
        CharInfo[] _buf;
        SmallRect _rect;


        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        /// <summary>
        /// Создать представление быстрой графики
        /// </summary>
        public KernelGraphics()
        {
            _width = 32;
            _height = 22;

            _fileHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            _buf = new CharInfo[_width * _height];
            _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
        }

        /// <summary>
        /// Напечатать карту через быструю буферизацию
        /// </summary>
        /// <returns></returns>
        public bool PrintMap()
        {
            int x = 0;
            int y = 0;
            Console.BufferHeight = 410;
            Console.BufferWidth = 540;
            Console.SetWindowSize(70, 30);

            Console.CursorVisible = false;
            
            for (int i = 0; i < _buf.Length; ++i)
            {
                _buf[i].Attributes = 32;
                _buf[i].Char.AsciiChar = 22;
            }

            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects)
            {
                if (obj != null)
                {
                    if (obj.NameObject() == "Brick")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("#");
                        //a.Append("#");
                    }

                    if (obj.NameObject() == "Concrete")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("#");
                        //a.Append("#");
                    }

                    if (obj.NameObject() == "Enemy")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("O");
                        //a.Append("O");
                    }

                    if (obj.NameObject() == "Gold")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("$");
                        //a.Append("$");
                    }

                    if (obj.NameObject() == "Rope")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("-");
                        //a.Append("-");
                    }

                    if (obj.NameObject() == "Stairs")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("|");
                        //a.Append("||");
                    }
                }
                else
                {
                    System.Console.SetCursorPosition(0, 0);
                    Console.Write(" ");
                    //a.Append("");
                }
            }

            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects)
            {
                if (obj != null)
                {
                    if (obj.NameObject() == "Man")
                    {
                        x = obj.X;
                        y = obj.Y;
                        System.Console.SetCursorPosition(x, y);
                        Console.WriteLine("K");
                        //a.Append("K");
                    }
                }
            }

            System.Console.SetCursorPosition(x, y);


            return WriteConsoleOutput(_fileHandle, _buf,
                          new Coord() { X = _width, Y = _height },
                          new Coord() { X = 0, Y = 0 },
                          ref _rect);
        }
    }
}
