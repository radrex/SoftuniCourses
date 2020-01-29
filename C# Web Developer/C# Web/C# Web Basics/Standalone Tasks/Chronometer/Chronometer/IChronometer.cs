using System.Collections.Generic;

namespace Chronometer
{
    public interface IChronometer
    {
        string GetTime { get; }
        IReadOnlyCollection<string> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}
