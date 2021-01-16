using Recorder.Abstractions;

namespace Processor.VoskApi.ConsoleApp.Configuration
{
    public class RecorderConfiguration : IRecorderConfiguration
    {
        public int SecondsToRecord => 3;
        public string WavFilesFolderName => "WavFiles";
    }
}
