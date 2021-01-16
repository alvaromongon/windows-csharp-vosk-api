using System;
using System.Threading.Tasks;
using Processor.Abstractions;
using Processor.Implementations;
using Processor.VoskApi.ConsoleApp.Configuration;
using Recorder.Abstractions;
using Recorder.Implementations;

namespace Processor.VoskApi.ConsoleApp
{
    class Program
    {

        private static readonly IRecorderConfiguration _recorderConfiguration
            = new RecorderConfiguration();
        private static readonly IProcessorConfiguration _processorConfiguration
            = new ProcessorConfiguration();

        private static readonly IRecorder _recorder
            = new OpenTkRecorder(_recorderConfiguration);
        private static readonly IProcessor _processor
            = new VoskProcessor(_processorConfiguration);

        static async Task Main(string[] args)
        {
            Console.WriteLine("Program starting");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Recorder will record for {_recorderConfiguration.SecondsToRecord} seconds, " +
                $"saving the wav file to folder '{_recorderConfiguration.WavFilesFolderName}' under the execution path.");
            Console.WriteLine($"Processor will run Python exe located in '{_processorConfiguration.PythonExeAbsolutePath}'.");
            Console.WriteLine("If you want to change this configuration, make the changes on the Configuration files in the ConsoleApp project.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press Esc to close the app");

            ConsoleKeyInfo pressedKey;
            do
            {
                Console.WriteLine("Press F2 to listen.");
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.F2)
                {
                    var wavPath = await _recorder.RecordToWav();
                    var wordArray = await _processor.ProcessFromWav(wavPath);

                    Console.WriteLine($"Words Listened: '{string.Join(",", wordArray)}'");
                }
            } while (pressedKey.Key != ConsoleKey.Escape);

            Console.WriteLine("Clossing app");
        }
    }
}
