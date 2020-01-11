using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CLIViews
{
    public class KernelGraphics
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
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
        private struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        private const char BLANK_SYMBOL = ' ';

        private readonly SafeFileHandle _consoleHandle;

        private short _width;
        private short _height;

        private SmallRect _screenRect;

        private CharInfo[] _buffer;

        private static KernelGraphics _instance = null;

        /// <summary>
        /// 
        /// </summary>
        public static KernelGraphics Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KernelGraphics();
                }
                return _instance;
            }
        }

        private KernelGraphics()
        {
            _width = 32;
            _height = 22;

            Console.CursorVisible = false;

            _consoleHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            _buffer = new CharInfo[_width * _height];
            _screenRect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };

            Clear();
        }

        public void Fill(char parSymbol, ConsoleColor parColor = ConsoleColor.White)
        {
            byte symbolByte = Console.OutputEncoding.GetBytes(new char[] { parSymbol })[0];

            for (int i = 0; i < _buffer.Length; i++)
            {
                _buffer[i].Attributes = (short)parColor;
                _buffer[i].Char.AsciiChar = symbolByte;
            }
        }

        public void Clear()
        {
            Fill(BLANK_SYMBOL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        /// <param name="parStr"></param>
        /// <param name="parColor"></param>
        public void PrintString(short parX, short parY, string parStr, ConsoleColor parColor = ConsoleColor.White)
        {
            byte[] strBytes = Console.OutputEncoding.GetBytes(parStr);

            int strToPrintLength = Math.Min(_width - parX, strBytes.Length);
            int initialPrintPosition = parY * _width + parX;
            for (int i = 0; i < strToPrintLength; i++)
            {
                _buffer[initialPrintPosition + i].Attributes = (short)parColor;
                _buffer[initialPrintPosition + i].Char.AsciiChar = strBytes[i];
            }
        }

        /// <summary>
        /// Напечатать строки через быструю буферизацию
        /// </summary>
        /// <param name="parStrings">Подаваемое поле строк</param>
        /// <returns></returns>
        public void Printstrings(StringBuilder[] parStrings)
        {
            //Console.CursorVisible = false;
            for (int i = 0; i < _buffer.Length; ++i)
            {
                _buffer[i].Attributes = 32;
                _buffer[i].Char.AsciiChar = 22;
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
                    _buffer[i * _width + j].Char.AsciiChar = (byte)str[j];
                }
            }
            Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parClearBuffer"></param>
        /// <returns></returns>
        public bool Flush(bool parClearBuffer = true)
        {
            bool success = WriteConsoleOutput(_consoleHandle, _buffer,
                    new Coord() { X = _width, Y = _height },
                    new Coord() { X = 0, Y = 0 },
                    ref _screenRect);
            if (parClearBuffer)
            {
                Clear();
            }
            return success;
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);
    }
}
