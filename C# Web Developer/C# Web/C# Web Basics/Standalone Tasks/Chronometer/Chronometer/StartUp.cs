namespace Chronometer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    break;
                }

                switch (command)
                {
                    case "start":   chronometer.Start();                        break;
                    case "stop":    chronometer.Stop();                         break;
                    case "reset":   chronometer.Reset(); break;

                    case "lap":     Console.WriteLine(chronometer.Lap());       break;
                    case "time":    Console.WriteLine(chronometer.GetTime);     break;

                    case "laps": 
                        Console.WriteLine($"Laps: {Environment.NewLine}" + 
                                         (chronometer.Laps.Count == 0 ? "no laps" : String.Join(Environment.NewLine, chronometer.Laps))); 
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
