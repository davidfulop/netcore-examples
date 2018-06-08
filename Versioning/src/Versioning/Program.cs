using System;
using System.Reflection;

namespace Versioning
{
    class Program
    {
        static void Main(string[] args)
        {
            var asm = typeof(Program).GetTypeInfo().Assembly;
            var infoVersion = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            var fileVersion = asm.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            Console.WriteLine($"Informational version: {infoVersion}{Environment.NewLine}FileVersion: {fileVersion}");
        }
    }
}
