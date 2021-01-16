using System.Threading.Tasks;

namespace Recorder.Abstractions
{
    public interface IRecorder
    {
        Task<string> RecordToWav();
    }
}
