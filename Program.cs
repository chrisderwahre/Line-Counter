using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Line_Counter
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine(@"Line Counter Help
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Usuage: 

linecounter.exe " + '"' + "Path to folder to check the files in" +'"' + @"

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ReadKey();
            }

            if (args.Length != 0)
            {
                var timer = Stopwatch.StartNew();
                timer.Start();
                string path = args[0].ToString().Replace(@"\", "/"); // splitting the args to grab the folder to check the files in.
                var totalLineCount = 0;
                var totalFiles = 0;

                //foreach (string d in Directory.GetDirectories(path))
                //{
                    //foreach (string f in Directory.GetFiles(d))
                foreach(string f in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    totalFiles++;
                    using (var reader = File.OpenText(f))
                    {
                        while (reader.ReadLine() != null)
                        {
                            totalLineCount++;
                        }
                    }
                }
                //}
                timer.Stop();
                var timerResult = timer.Elapsed.TotalSeconds;
                Console.WriteLine(@"Line Counter
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Total Lines: " + totalLineCount + @"

Total Files: " + totalFiles + @"

Folder Path: " + path + "\n\nTime spend while reading: " + timerResult + " seconds\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }
    }
}
