using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.Versioning;
using System.IO;

namespace Athi.Whippet
{
    /// <summary>
    /// Wrapper instance for <see cref="Console"/>. Adds extra functionality used by Whippet applications.
    /// </summary>
    public class WhippetConsole
    {
        /// <summary>
        /// Stores the current background color.
        /// </summary>
        private static ConsoleColor __BackgroundColor
        { get; set; }

        /// <summary>
        /// Stores the current foreground color.
        /// </summary>
        private static ConsoleColor __ForegroundColor
        { get; set; }

        /// <summary>
        /// Occurs when the <see cref="ConsoleModifiers.Control"/> modifier key (Ctrl) and either the <see cref="ConsoleKey.C"/> 
        /// console key (C) or the Break key are pressed simulatneously (Ctrl+C or Ctrl+Break).
        /// </summary>
        [UnsupportedOSPlatform("browser")]
        public static event ConsoleCancelEventHandler CancelKeyPress
        {
            add
            {
                Console.CancelKeyPress += value;
            }
            remove
            {
                Console.CancelKeyPress -= value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether input has been redirected from the standard input stream. This property is read-only.
        /// </summary>
        public static bool IsInputRedirected 
        { 
            get
            {
                return Console.IsInputRedirected;
            }
        }

        /// <summary>
        /// Gets or sets the height of the buffer area.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int BufferHeight 
        { 
            get
            {
                return Console.BufferHeight;
            }
            set
            {
                Console.BufferHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the buffer area.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int BufferWidth
        {
            get
            {
                return Console.BufferWidth;
            }
            set
            {
                Console.BufferWidth = value;
            }
        }


        //
        // Summary:
        //     Gets a value indicating whether the CAPS LOCK keyboard toggle is turned on or
        //     turned off.
        //
        // Returns:
        //     true if CAPS LOCK is turned on; false if CAPS LOCK is turned off.
        //
        // Exceptions:
        //   T:System.PlatformNotSupportedException:
        //     The get operation is invoked on an operating system other than Windows.
        [SupportedOSPlatform("windows")]
        public static bool CapsLock 
        { 
            get
            {
                return Console.CapsLock;
            }
        }

        /// <summary>
        /// Gets or sets the column position of the cursor within the buffer area.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static int CursorLeft 
        { 
            get
            {
                return Console.CursorLeft;
            }
            set
            {
                Console.CursorLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the cursor within a character cell.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int CursorSize 
        { 
            get
            {
                return Console.CursorSize;
            }
            set
            {
                Console.CursorSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the row position of the cursor within the buffer area.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static int CursorTop 
        { 
            get
            {
                return Console.CursorTop;
            }
            set
            {
                Console.CursorTop = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible.
        /// </summary>
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static bool CursorVisible 
        { 
            get
            {
                return Console.CursorVisible;
            }
            set
            {
                Console.CursorVisible = value;
            }
        }

        /// <summary>
        /// Gets the standard error output stream. This property is read-only.
        /// </summary>
        public static TextWriter Error 
        { 
            get
            {
                return Console.Error;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the console.
        /// </summary>
        /// <exception cref="ArgumentException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static ConsoleColor ForegroundColor 
        { 
            get
            {
                return Console.ForegroundColor;
            }
            set
            {
                Console.ForegroundColor = value;
            }
        }

        /// <summary>
        /// Gets the standard input stream. This property is read-only.
        /// </summary>
        [UnsupportedOSPlatform("browser")]
        public static TextReader In 
        { 
            get
            {
                return Console.In;
            }
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to read input.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="IOException" />
        /// <exception cref="SecurityException" />
        [UnsupportedOSPlatform("browser")]
        public static Encoding InputEncoding 
        { 
            get
            {
                return Console.InputEncoding;
            }
            set
            {
                Console.InputEncoding = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the error output stream has been redirected from the standard error stream.
        /// </summary>
        public static bool IsErrorRedirected 
        { 
            get
            {
                return Console.IsErrorRedirected;
            }
        }

        /// <summary>
        /// Gets or sets the width of the console window.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int WindowWidth 
        { 
            get
            {
                return Console.WindowWidth;
            }
            set
            {
                Console.WindowWidth = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether output has been redirected from the standard output stream. This property is read-only.
        /// </summary>
        public static bool IsOutputRedirected 
        { 
            get
            {
                return Console.IsOutputRedirected;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a key press is available in the input stream. This property is read-only.
        /// </summary>
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        public static bool KeyAvailable 
        { 
            get
            {
                return Console.KeyAvailable;
            }
        }

        /// <summary>
        /// Gets the largest possible number of console window rows, based on the current font and screen resolution. This property is read-only.
        /// </summary>
        [UnsupportedOSPlatform("browser")]
        public static int LargestWindowHeight 
        {
            get
            {
                return Console.LargestWindowHeight;
            }
        }

        /// <summary>
        /// Gets the largest possible number of console window columns, based on the current font and screen resolution. This property is read-only.
        /// </summary>
        [UnsupportedOSPlatform("browser")]
        public static int LargestWindowWidth 
        { 
            get
            {
                return Console.LargestWindowWidth;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the NUM LOCK keyboard toggle is turned on or turned off.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static bool NumberLock 
        { 
            get
            {
                return Console.NumberLock;
            }
        }

        /// <summary>
        /// Gets the standard output stream. This property is read-only.
        /// </summary>
        public static TextWriter Out 
        { 
            get
            {
                return Console.Out;
            }
        }

        /// <summary>
        /// Gets or sets the encoding the console uses to write output.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="IOException" />
        /// <exception cref="SecurityException" />
        public static Encoding OutputEncoding 
        { 
            get
            {
                return Console.OutputEncoding;
            }
            set
            {
                Console.OutputEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets the title to display in the console title bar.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static string Title 
        { 
            get
            {
                return Console.Title;
            }
            set
            {
                Console.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the combination of the <see cref="ConsoleModifiers.Control"/> modifier key and 
        /// <see cref="ConsoleKey.C"/> console key (Ctrl+C) is treated as ordinary input or as an interruption that is handled by the operating system.
        /// </summary>
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static bool TreatControlCAsInput 
        { 
            get
            {
                return Console.TreatControlCAsInput;
            }
            set
            {
                Console.TreatControlCAsInput = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the console window area.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int WindowHeight 
        { 
            get
            {
                return Console.WindowHeight;
            }
            set
            {
                Console.WindowHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the leftmost position of the console window area relative to the screen buffer.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int WindowLeft 
        { 
            get
            {
                return Console.WindowLeft;
            }
            set
            {
                Console.WindowLeft = value;
            }
        }

        /// <summary>
        /// Gets or sets the top position of the console window area relative to the screen buffer.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static int WindowTop 
        { 
            get
            {
                return Console.WindowTop;
            }
            set
            {
                Console.WindowTop = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color of the console.
        /// </summary>
        /// <exception cref="ArgumentException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static ConsoleColor BackgroundColor 
        { 
            get
            {
                return Console.BackgroundColor;
            }
            set
            {
                Console.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetConsole"/> class with no arguments.
        /// </summary>
        protected WhippetConsole()
        { }

        /// <summary>
        /// Plays the sound of a beep through the console speaker.
        /// </summary>
        /// <exception cref="HostProtectionException" />
        [UnsupportedOSPlatform("browser")]
        public static void Beep()
        {
            Console.Beep();
        }

        /// <summary>
        /// Plays the sound of a beep of a specified frequency and duration through the console speaker.
        /// </summary>
        /// <param name="frequency">The frequency of the beep, ranging from 37 to 32767 hertz</param>
        /// <param name="duration">The duration of the beep measured in milliseconds.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="HostProtectionException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void Beep(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
        }

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information.
        /// </summary>
        /// <exception cref="IOException" />
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Gets the position of the cursor.
        /// </summary>
        /// <returns>The column and row position of the cursor.</returns>
        [UnsupportedOSPlatform("browser")]
        public static (int Left, int Top) GetCursorPosition()
        {
            return Console.GetCursorPosition();
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area.
        /// </summary>
        /// <param name="sourceLeft">The leftmost column of the source area.</param>
        /// <param name="sourceTop">The topmost row of the source area.</param>
        /// <param name="sourceWidth">The number of columns in the source area.</param>
        /// <param name="sourceHeight">The number of rows in the source area.</param>
        /// <param name="targetLeft">The leftmost column of the destination area.</param>
        /// <param name="targetTop">The topmost row of the destination area.</param>
        /// <param name="sourceChar">The character used to fill the source area.</param>
        /// <param name="sourceForeColor">The foreground color used to fill the source area.</param>
        /// <param name="sourceBackColor">The background color used to fill the source area.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
        }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area.
        /// </summary>
        /// <param name="sourceLeft">The leftmost column of the source area.</param>
        /// <param name="sourceTop">The topmost row of the source area.</param>
        /// <param name="sourceWidth">The number of columns in the source area.</param>
        /// <param name="sourceHeight">The number of rows in the source area.</param>
        /// <param name="targetLeft">The leftmost column of the destination area.</param>
        /// <param name="targetTop">The topmost row of the destination area.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
        {
            Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }

        /// <summary>
        /// Acquires the standard error stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">The internal stream buffer size.</param>
        /// <returns>The standard error stream.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static Stream OpenStandardError(int bufferSize)
        {
            return Console.OpenStandardError(bufferSize);
        }

        /// <summary>
        /// Acquires the standard error stream.
        /// </summary>
        /// <returns>The standard error stream.</returns>
        public static Stream OpenStandardError()
        {
            return Console.OpenStandardError();
        }

        /// <summary>
        /// Acquires the standard input stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">The internal stream buffer size.</param>
        /// <returns>The standard input stream.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        [UnsupportedOSPlatform("browser")]
        public static Stream OpenStandardInput(int bufferSize)
        {
            return Console.OpenStandardInput(bufferSize);
        }

        /// <summary>
        /// Acquires the standard input stream.
        /// </summary>
        /// <returns>The standard input stream.</returns>
        [UnsupportedOSPlatform("browser")]
        public static Stream OpenStandardInput()
        {
            return Console.OpenStandardInput();
        }

        /// <summary>
        /// Acquires the standard standard output stream, which is set to a specified buffer size.
        /// </summary>
        /// <param name="bufferSize">The internal stream buffer size.</param>
        /// <returns>The standard output stream.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static Stream OpenStandardOutput(int bufferSize)
        {
            return Console.OpenStandardOutput(bufferSize);
        }

        /// <summary>
        /// Acquires the standard standard output stream.
        /// </summary>
        /// <returns>The standard output stream.</returns>
        public static Stream OpenStandardOutput()
        {
            return Console.OpenStandardOutput();
        }

        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read.</returns>
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static int Read()
        {
            return Console.Read();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is optionally displayed in the console window.
        /// </summary>
        /// <param name="intercept">Determines whether to display the pressed key in the console window. <see langword="true"/> to not display the pressed key; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// An object that describes the <see cref="ConsoleKey"/> constant and Unicode character, if any, that correspond to the pressed console key. The <see cref="ConsoleKeyInfo"/> object also 
        /// describes, in a bitwise combination of <see cref="ConsoleModifiers"/> values, whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously with the console key.
        /// </returns>
        /// <exception cref="InvalidOperationException" />
        [UnsupportedOSPlatform("browser")]
        public static ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        /// <summary>
        ///  Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window.
        /// </summary>
        /// <returns>
        /// An object that describes the <see cref="ConsoleKey"/> constant and Unicode character, if any, that correspond to the pressed console key. The <see cref="ConsoleKeyInfo"/>
        /// object also describes, in a bitwise combination of <see cref="ConsoleModifiers"/> values, whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously
        /// with the console key.
        /// </returns>
        /// <exception cref="InvalidOperationException" />
        [UnsupportedOSPlatform("browser")]
        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
        /// <exception cref="IOException" />
        /// <exception cref="OutOfMemoryException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        [UnsupportedOSPlatform("browser")]
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Sets the foreground and background console colors to their defaults.
        /// </summary>
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// Sets the height and width of the screen buffer area to the specified values.
        /// </summary>
        /// <param name="width">The width of the buffer area measured in columns.</param>
        /// <param name="height">The height of the buffer area measured in rows.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }

        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left">The column position of the cursor. Columns are numbered from left to right starting at 0.</param>
        /// <param name="top">The row position of the cursor. Rows are numbered from top to bottom starting at 0.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        [UnsupportedOSPlatform("browser")]
        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Sets the <see cref="Error"/> property to the specified <see cref="TextWriter"/> object.
        /// </summary>
        /// <param name="newError">A stream that is the new standard error output.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SecurityException" />
        public static void SetError(TextWriter newError)
        {
            Console.SetError(newError);
        }

        /// <summary>
        /// Sets the <see cref="In"/> property to the specifeid <see cref="TextReader"/> object.
        /// </summary>
        /// <param name="newIn">A stream that is the new standard input.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SecurityException" />
        [UnsupportedOSPlatform("browser")]
        public static void SetIn(TextReader newIn)
        {
            Console.SetIn(newIn);
        }

        /// <summary>
        /// Sets the <see cref="Out"/> property to target the <see cref="TextWriter"/> object.
        /// </summary>
        /// <param name="newOut">A text writer to be used as the new standard output.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SecurityException" />
        public static void SetOut(TextWriter newOut)
        {
            Console.SetOut(newOut);
        }

        /// <summary>
        /// Sets the position of the console window relative to the screen buffer.
        /// </summary>
        /// <param name="left">The column position of the upper left corner of the console window.</param>
        /// <param name="top">The row position of the upper left corner of the console window.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void SetWindowPosition(int left, int top)
        {
            Console.SetWindowPosition(left, top);
        }

        /// <summary>
        /// Sets the height and width of the console window to the specified values.
        /// </summary>
        /// <param name="width">The width of the console window measured in columns.</param>
        /// <param name="height">The height of the console window measured in rows.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="SecurityException" />
        /// <exception cref="IOException" />
        /// <exception cref="PlatformNotSupportedException" />
        [SupportedOSPlatform("windows")]
        public static void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit unsigned integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(ulong value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified Boolean value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(bool value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified Unicode character value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(char value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified array of Unicode characters to the standard output stream.
        /// </summary>
        /// <param name="buffer">A Unicode character array.</param>
        /// <exception cref="IOException" />
        public static void Write(char[] buffer)
        {
            Console.Write(buffer);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit signed integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(int value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified <see cref="Decimal"/> value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(decimal value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit signed integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(long value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write or <see langword="null"/>.</param>
        /// <exception cref="IOException" />
        public static void Write(object value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified single-precision floating-point value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(float value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(string value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void Write(string format, object arg0)
        {
            Console.Write(format, arg0);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void Write(string format, object arg0, object arg1)
        {
            Console.Write(format, arg0, arg1);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void Write(string format, object arg0, object arg1, object arg2)
        {
            Console.Write(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to write using format.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void Write(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit unsigned integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(uint value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the specified subarray of Unicode characters to the standard output stream.
        /// </summary>
        /// <param name="buffer">An array of Unicode characters.</param>
        /// <param name="index">The starting position in buffer.</param>
        /// <param name="count">The number of characters to write.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="IOException" />
        public static void Write(char[] buffer, int index, int count)
        {
            Console.Write(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of the specified double-precision floating-point value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void Write(double value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        /// <exception cref="IOException" />
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit unsigned integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(ulong value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified Boolean value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(bool value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified Unicode character value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(char value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified array of Unicode characters to the standard output stream.
        /// </summary>
        /// <param name="buffer">A Unicode character array.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(char[] buffer)
        {
            Console.WriteLine(buffer);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit signed integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(int value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified <see cref="Decimal"/> value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(decimal value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified 64-bit signed integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(long value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write or <see langword="null"/>.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(object value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified single-precision floating-point value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(float value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void WriteLine(string format, object arg0)
        {
            Console.WriteLine(format, arg0);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void WriteLine(string format, object arg0, object arg1)
        {
            Console.WriteLine(format, arg0, arg1);
        }

        /// <summary>
        /// Writes the text representation of the specified objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg1">An object to write using <paramref name="format"/>.</param>
        /// <param name="arg2">An object to write using <paramref name="format"/>.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            Console.WriteLine(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard output stream using the specified format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to write using format.</param>
        /// <exception cref="IOException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        public static void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        /// <summary>
        /// Writes the text representation of the specified 32-bit unsigned integer value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(uint value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the specified subarray of Unicode characters to the standard output stream.
        /// </summary>
        /// <param name="buffer">An array of Unicode characters.</param>
        /// <param name="index">The starting position in buffer.</param>
        /// <param name="count">The number of characters to write.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="IOException" />
        public static void WriteLine(char[] buffer, int index, int count)
        {
            Console.WriteLine(buffer, index, count);
        }

        /// <summary>
        /// Writes the text representation of the specified double-precision floating-point value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <exception cref="IOException" />
        public static void WriteLine(double value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Saves the current value of <see cref="BackgroundColor"/>.
        /// </summary>
        public static void SaveCurrentBackgroundColor()
        {
            __BackgroundColor = BackgroundColor;
        }

        /// <summary>
        /// Saves the current value of <see cref="ForegroundColor"/>.
        /// </summary>
        public static void SaveCurrentForegroundColor()
        {
            __ForegroundColor = ForegroundColor;
        }

        /// <summary>
        /// Restores <see cref="BackgroundColor"/> to the value it was when <see cref="SaveCurrentBackgroundColor"/> was called.
        /// </summary>
        public static void RestoreBackgroundColor()
        {
            BackgroundColor = __BackgroundColor;
        }

        /// <summary>
        /// Restores <see cref="ForegroundColor"/> to the value it was when <see cref="SaveCurrentForegroundColor"/> was called.
        /// </summary>
        public static void RestoreForegroundColor()
        {
            ForegroundColor = __ForegroundColor;
        }
    }
}
