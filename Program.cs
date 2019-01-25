using System;
using System.IO;
using CommandLine;
using word_counter.core;

namespace word_counter
{
    class Program
    {
        public class Options
        {
            [Option('s', "source", Required = true, HelpText = "Filename to count words in.")]
            public string FileName { get; set; }

            [Option('w', "word", Required = true, HelpText = "Word to count.")]
            public string Word { get; set; }
        }
        static void Main(string[] args)
        {
            var config = Parser.Default.ParseArguments<Options>(args);

            config.WithParsed<Options>(o => 
            {
                if (!File.Exists(o.FileName)) throw new ArgumentException("File doesn't exist");
            });

            config.WithParsed<Options>(o => 
            {
                var originText = File.ReadAllText(o.FileName);

                var wordCount = originText.CountWordInText(o.Word);

                Console.WriteLine($"Word '{o.Word}' occurred {wordCount} time(s) in the text");
            });
        }
    }
}
