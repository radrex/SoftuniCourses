namespace Chronometer
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Chronometer class with methods and properties for time measurements and laps.
    /// </summary>
    public class Chronometer : IChronometer
    {
        //------------------------ FIELDS ------------------------
        private readonly List<string> laps;
        private long milliseconds;
        private bool isRunning;

        //--------------------- CONSTRUCTORS ---------------------
        /// <summary>
        /// Creates a new instance of the Chronometer also initializes a collection of Laps.
        /// </summary>
        public Chronometer()
        {
            this.laps = new List<string>();
        }

        //---------------------- PROPERTIES ----------------------
        /// <summary>
        /// Gets the total time of all laps summed together as string.
        /// </summary>
        public string GetTime => $"{milliseconds / 60_000:D2}:{milliseconds / 1000:D2}:{(milliseconds % 1000):D4}";

        /// <summary>
        /// Collection of laps.
        /// </summary>
        public IReadOnlyCollection<string> Laps => this.laps.AsReadOnly();

        //----------------------- METHODS ------------------------
        /// <summary>
        /// Creates a lap, adds it to the collection of laps, and returns the lap time as string.
        /// </summary>
        /// <returns>Lap time string</returns>
        public string Lap()
        {
            string lap = this.GetTime;
            this.laps.Add($"{this.Laps.Count + 1}. {lap}");
            return lap;
        }

        /// <summary>
        /// Stops the Chronometer, resets the currently recorded time and deletes all of the currently recoded laps.
        /// </summary>
        public void Reset()
        {
            this.Stop();
            this.milliseconds = 0;
            this.laps.Clear();
        }

        /// <summary>
        /// Starts the chronometer counting.
        /// </summary>
        public void Start()
        {
            this.isRunning = true;
            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1); // 1 millisecond
                    this.milliseconds++;
                }
            });
        }

        /// <summary>
        /// Stops the chronometer counting.
        /// </summary>
        public void Stop() => this.isRunning = false;
    }
}
