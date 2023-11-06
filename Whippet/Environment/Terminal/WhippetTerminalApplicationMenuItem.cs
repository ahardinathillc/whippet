using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __Gui = Terminal.Gui;
using NStack;

namespace Athi.Whippet.Environment.Terminal
{
    /// <summary>
    /// Represents an item that is selectable inside a terminal menu.
    /// </summary>
    public class WhippetTerminalApplicationMenuItem : __Gui.MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationMenuItem"/> class with the specified key.
        /// </summary>
        /// <param name="shortcut">Key to handle when pressed.</param>
        public WhippetTerminalApplicationMenuItem(__Gui.Key shortcut = __Gui.Key.Null)
            : base(shortcut)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTerminalApplicationMenuItem"/> class.
        /// </summary>
        /// <param name="title">Title for the menu item.</param>
        /// <param name="help">Help text to display.</param>
        /// <param name="action">Action to invoke when the menu item is activated.</param>
        /// <param name="canExecute">Function to determine if the action can currently be exeucted.</param>
        /// <param name="parent">The parent of the menu item.</param>
        /// <param name="shortcut">Key to handle when pressed.</param>
        public WhippetTerminalApplicationMenuItem(string title, string help, Action action, Func<bool> canExecute = null, WhippetTerminalApplicationMenuItem parent = null, __Gui.Key shortcut = __Gui.Key.Null)
            : base(title, help, action, canExecute, parent, shortcut)
        { }

        /// <summary>
        /// Creates a <see cref="WhippetTerminalApplicationMenuItem"/> that will exit the application.
        /// </summary>
        /// <param name="quitCallback">Callback to invoke that exits the application.</param>
        /// <param name="quitPrompt">Prompt dialog function that allows the user to confirm their choice.</param>
        /// <returns><see cref="WhippetTerminalApplicationMenuItem"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static WhippetTerminalApplicationMenuItem CreateQuitMenuItem(Action quitCallback, Func<bool> quitPrompt = null)
        {
            if (quitCallback == null)
            {
                throw new ArgumentNullException(nameof(quitCallback));
            }
            else
            {
                return new WhippetTerminalApplicationMenuItem(
                    "_Quit",
                    String.Empty,
                    () =>
                    {
                        if (((quitPrompt != null) && quitPrompt()) || quitPrompt == null)
                        {
                            quitCallback();
                        }
                    });
            }
        }
    }
}
