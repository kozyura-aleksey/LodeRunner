using Microsoft.Win32.SafeHandles;
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
            _width = 50;
            _height = 50;

            _fileHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            _buf = new CharInfo[_width * _height];
            _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
        }

        /// <summary>
        /// Напечатать строки через быструю буферизацию
        /// </summary>
        /// <param name="parStrings">Подаваемое поле строк</param>
        /// <returns></returns>
        public bool PrintStrings(StringBuilder[] parStrings)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < _buf.Length; ++i)
            {
                _buf[i].Attributes = 15;
                _buf[i].Char.AsciiChar = 32;
            }
            for (int i = 0; i < Math.Min(parStrings.Length, _height); i++)
            {
                StringBuilder sb = parStrings[i];
                if (sb == null)
                {
                    break;
                }

                string str = sb.ToString();
                for (int j = 0; j < Math.Min(str.Length, _width); j++)
                {
                    _buf[i * _width + j].Char.AsciiChar = (byte)str[j];
                }

            }
            return WriteConsoleOutput(_fileHandle, _buf,
                          new Coord() { X = _width, Y = _height },
                          new Coord() { X = 0, Y = 0 },
                          ref _rect);
        }
    }
}
