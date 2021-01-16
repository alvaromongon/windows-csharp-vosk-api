namespace Recorder.Abstractions
{
    public interface IRecorderConfiguration
    {
        int SecondsToRecord { get; }
        string WavFilesFolderName { get; }
    }
}
