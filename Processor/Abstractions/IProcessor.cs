using System.Threading.Tasks;

namespace Processor.Abstractions
{
    public interface IProcessor
    {
        Task<string[]> ProcessFromWav(string wavFilePath);
    }
}
