using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;
            // We will add some set-up stuff here later...

            Run();
        }


        static void Run()
        {
            while (true)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;
                try
                {
                    // Create a ConsoleCommand instance:
                    var cmd = new ConsoleCommand(consoleInput);

                    // Execute the command:
                    string result = Execute(cmd);

                    // Write out the result:
                    WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    WriteToConsole(ex.Message);
                }
            }
        }


        static string Execute(ConsoleCommand command)
        {
            // We'll make this more interesting shortly. 
            // For now, output the command details:
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Executed the {0}.{1} Command",
                command.LibraryClassName, command.Name));
            for (int i = 0; i < command.Arguments.Count(); i++)
            {
                sb.AppendLine("    " +
                    string.Format("Argument{0} value: {1}", i, command.Arguments.ElementAt(i)));
            }
            return sb.ToString();
        }


        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }


        const string _readPrompt = "Moniverse> ";
        public static string ReadFromConsole(string promptMessage = "")
        {
            // Show a prompt, and get input:
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }
    }
}
