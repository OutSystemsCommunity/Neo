using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DiveLog.Utility
{
    public static class DebugLogger
    {
        public static void Log(string message = null, [CallerMemberName] string methodName = null, [CallerFilePath] string filePath = null)
        {
            if (filePath == null || methodName == null)
            {
                return;
            }

            filePath = filePath.Substring(1 + filePath.LastIndexOf("/", StringComparison.CurrentCulture));
            filePath = filePath.Substring(0, filePath.IndexOf(".", StringComparison.CurrentCulture));

            if (methodName.Equals(".ctor"))
            {
                methodName = "Constructor";
            }
            if (message == null)
            {
                Debug.WriteLine($"{filePath} - {methodName}");
            }
            else
            {
                Debug.WriteLine($"{filePath} - {methodName} - {message}");
            }
        }
    }
}