﻿using System;
using CommandLine;

namespace Cultures.CmdLine
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            Console.WriteLine();

            //args = new[] { "remove", "-c", "ru-ua" };
            //args = new[] { "remove", "-c", "ru-zz" };
            //args = new[] { "import", "-c", "c:\\temp\\cult\\ru-zz.culture" };
            //args = new[] { "import", "-c", "ru-zz.culture" };
            //args = new[] { "importfolder", "c:\\temp\\cult" };

            var result = Parser.Default.ParseArguments<List, Export, Import, ImportFolder, Remove>(args);
            var exitCode = result.MapResult<List, Export, Import, ImportFolder, Remove, object>(
                list => list.Action(),
                export => export.Action(),
                import => import.Action(),
                importFolder => importFolder.Action(),
                remove => remove.Action(),
                errors => 1);

            Console.WriteLine();

#if DEBUG
            Console.ReadKey();
#endif

            return (int)exitCode;
        }
    }
}
