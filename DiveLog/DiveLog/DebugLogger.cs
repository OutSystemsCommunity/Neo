using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DiveLog
{
    public static class DebugLogger
    {
        public static void Log([CallerFilePath] string filePath = null, [CallerMemberName] string methodName = null)
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

            Debug.WriteLine(filePath + " - " + methodName);
        }
    }
}
