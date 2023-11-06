using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __Gui = Terminal.Gui;
using NStack;
using Athi.Whippet.Environment.Windows;

namespace Athi.Whippet.Environment.Terminal
{
    /// <summary>
    /// Base class for all Whippet terminal window applications that use the <a href="https://github.com/migueldeicaza/gui.cs">Terminal.Gui</a> package. This class must be inherited.
    /// </summary>
    public abstract class WhippetTerminalApplicationWindowBase : __Gui.Window
    {
        private static __Gui.Point? _center;
        
        /// <summary>
        /// Gets the default coordinate from which a <see cref="__Gui.Rect"/> is drawm for the center of the screen. This property is read-only.
        /// </summary>
        protected static __Gui.Point DefaultCenter
        {
            get
            {
                if(!_center.HasValue)
                {
                    _center = new __Gui.Point(50, 7);
                }

                return _center.Value;
            }
        }

        /// <summary>
        /// Gets or sets the previous top-level view.
        /// </summary>
        protected __Gui.Toplevel PreviousTopLevel
        { get; set; }

        /// <summary>
        /// Gets the top-level element of the application view. This property is read-only.
        /// </summary>
        public virtual __Gui.Toplevel TopLevel
        { 
            get
            {
                return __Gui.Application.Top;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationWindowBase"/> class using <see cref="__Gui.LayoutStyle.Computed"/> positioning.
        /// </summary>
        protected WhippetTerminalApplicationWindowBase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationWindowBase"/> class with an optional title using <see cref="__Gui.LayoutStyle.Computed"/> positioning.
        /// </summary>
        /// <param name="title">Title to display in the terminal window.</param>
        protected WhippetTerminalApplicationWindowBase(string title)
            : base(title)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationWindowBase"/> class with an optional title using <see cref="__Gui.LayoutStyle.Absolute"/> positioning.
        /// </summary>
        /// <param name="frame">Superview-relative rectangle specifying the location and size.</param>
        /// <param name="title">Title to display in the terminal window.</param>
        protected WhippetTerminalApplicationWindowBase(__Gui.Rect frame, string title)
            : base(frame, title)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationWindowBase"/> class using <see cref="__Gui.LayoutStyle.Absolute"/> positioning with the specified frame for its location, frame padding, and optional title.
        /// </summary>
        /// <param name="frame">Superview-relative rectangle specifying the location and size.</param>
        /// <param name="title">Title to display in the terminal window.</param>
        /// <param name="padding">Number of characters to use for padding of the drawn frame.</param>
        /// <param name="border"><see cref="__Gui.Window.Border"/> style to apply.</param>
        protected WhippetTerminalApplicationWindowBase(__Gui.Rect frame, string title, int padding, __Gui.Border border)
            : base(frame, title, padding, border)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationWindowBase"/> class with an optional title using <see cref="__Gui.LayoutStyle.Computed"/> positioning.
        /// </summary>
        /// <param name="title">Title to display in the terminal window.</param>
        /// <param name="padding">Number of characters to use for padding of the drawn frame.</param>
        /// <param name="border"><see cref="__Gui.Window.Border"/> style to apply.</param>
        protected WhippetTerminalApplicationWindowBase(string title, int padding, __Gui.Border border)
            : base(title, padding, border)
        { }

        /// <summary>
        /// Configures the current window to be the main view of the application.
        /// </summary>
        public virtual void ConfigureForMainView()
        {
            X = 0;
            Y = 1;
            Width = __Gui.Dim.Fill();
            Height = __Gui.Dim.Fill();

            TopLevel.Add(this);
        }

        /// <summary>
        /// Initializes the view by adding its controls and updating necessary layouts. This method must be overridden.
        /// </summary>
        /// <param name="previousTopLevelView">Previous <see cref="__Gui.Toplevel"/> view if the current view is a child.</param>
        public abstract void Initialize(__Gui.Toplevel previousTopLevelView = null);

        /// <summary>
        /// Prompts the user if they wish to quit the application.
        /// </summary>
        /// <returns><see langword="true"/> if the user selects the "OK" or "Yes" prompt; otherwise, <see langword="false"/>.</returns>
        public virtual bool QuitApplicationPrompt()
        {
            return QuitApplicationPrompt(50, 7, "Exit", "Are you sure you wish to exit?", "Yes", "No");
        }

        /// <summary>
        /// Prompts the user if they wish to quit the application.
        /// </summary>
        /// <param name="width">Width of the dialog box.</param>
        /// <param name="height">Height of the dialog box.</param>
        /// <param name="title">Title to display in the dialog box.</param>
        /// <param name="message">Message to display in the dialog box.</param>
        /// <param name="yesOption">"Yes" option to display.</param>
        /// <param name="noOption">"No" option to display.</param>
        /// <returns><see langword="true"/> if the user selects <paramref name="yesOption"/>; otherwise, <see langword="false"/>.</returns>
        public virtual bool QuitApplicationPrompt(int width, int height, string title, string message, string yesOption, string noOption)
        {
            return __Gui.MessageBox.Query(width, height, title, message, yesOption, noOption) == 0;
        }

        /// <summary>
        /// Adds the specified value to the clipboard, overwriting any object currently stored there.
        /// </summary>
        /// <param name="value">Value to write to the clipboard.</param>
        protected virtual void AddToClipboard(string value)
        {
            Clipboard.AddToClipboard(value);
        }

        /// <summary>
        /// Adds the specified value to the clipboard, overwriting any object currently stored there.
        /// </summary>
        /// <param name="value">Value to write to the clipboard.</param>
        protected virtual void AddToClipboard(ustring value)
        {
            AddToClipboard(value.ToString());
        }
    }
}
