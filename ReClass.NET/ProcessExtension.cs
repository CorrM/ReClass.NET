using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReClassNET
{
    public static class ProcessExtension
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr processHandle, [Out, MarshalAs(UnmanagedType.Bool)] out bool wow64Process);

        public static bool Is64BitProcess(this Process process)
        {
            if (!Environment.Is64BitOperatingSystem)
                return false;

            if (!IsWow64Process(process.Handle, out bool isWow64Process))
                throw new Win32Exception(Marshal.GetLastWin32Error());

            return !isWow64Process;
        }
    }
}
