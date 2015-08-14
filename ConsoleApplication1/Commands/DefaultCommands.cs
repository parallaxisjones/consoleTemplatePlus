using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
// All console commands must be in the sub-namespace Commands: 
namespace ConsoleApplicationBase.Commands
{
    // Must be a public static class:
    public static class DefaultCommands
    {
        // Methods used as console commands must be public and must return a string

        public static string help() 
        {
            string output = "--------\r\n" + ConsoleFormatting.Indent(1) + "options\r\n--------";
            foreach (KeyValuePair<string, Dictionary<string, IEnumerable<ParameterInfo>>> kvp in Program._commandLibraries) {
                foreach (KeyValuePair<string, IEnumerable<ParameterInfo>> methods in kvp.Value) {
                    output += "\r\n" + ConsoleFormatting.Indent(1) + methods.Key;
                    if (methods.Value.Count() > 0) {
                        output += "\r\nParameters:";
                        foreach (ParameterInfo info in methods.Value)
                        {
                            output += "\r\n" + ConsoleFormatting.Indent(1) + "- " + info.Name;
                        }
                    }

                    output += "\r\n";
                }
            }
            return output;
        }

        public static string clear() 
        {
             Console.Clear();
             return "";
        }
        
        public static string testMeth(int test1, string test2)
        {
            Console.Clear();
            return "";
        }
    }
}
