using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulCS
{
    /// <summary>
    /// Methods for making process in the window OS using the default DLL's
    /// </summary>
    public static class WindowHelper
    {
        /// <summary>
        /// Bring a window process to the top front of the desktop view
        /// </summary>
        /// <param name="process"></param>
        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        const int SW_RESTORE = 9;
        /// <summary>
        /// Get the main window for handle it from a process
        /// </summary>
        /// <param name="handle">IntPtr window handle</param>
        /// <returns>True/False</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <param name="nCmdShow">Command const  for show the handle #https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow#parameters</param>
        /// <returns>If the window was previously visible</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        /// <summary>
        /// Determines whether the specified window is minimized (iconic).
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the window is iconic</returns>
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
    }
}
