using CommandLine;

namespace PseudocodeInterpreter
{
    public class CommandLineOptions
    {
        [Option('f', "file", Required = true, HelpText = "The file which contains the code to be interpreted")]
        public string File { get; set; }
        
        [Option("lang", Default = "en", HelpText = "The language flavor of the pseudocode")]
        public string Language { get; set; }
        
        [Option("stats", Default = false, HelpText = "Displays aditional info about the interpreted program.")]
        public bool Stats { get; set; }
    }
}