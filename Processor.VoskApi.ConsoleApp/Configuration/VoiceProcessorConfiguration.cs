using Processor.Abstractions;

namespace Processor.VoskApi.ConsoleApp.Configuration
{
    public class ProcessorConfiguration : IProcessorConfiguration
    {
        public string PythonExeAbsolutePath => @"C:\Python38\python.exe";
    }
}
