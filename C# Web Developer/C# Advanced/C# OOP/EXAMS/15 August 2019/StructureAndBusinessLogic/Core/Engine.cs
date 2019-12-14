using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        //-------------- Fields ---------------
        private IWriter writer;
        private IReader reader;
        private IController controller;

        //----------- Constructors ------------
        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        //------------- Methods ---------------
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        this.writer.WriteLine(this.controller.AddAstronaut(input[1], input[2]));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        List<string> items = new List<string>();
                        for (int i = 2; i < input.Length; i++)
                        {
                            items.Add(input[i]);
                        }
                        this.writer.WriteLine(this.controller.AddPlanet(input[1], items.ToArray()));

                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        this.writer.WriteLine(this.controller.RetireAstronaut(input[1]));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        this.writer.WriteLine(this.controller.ExplorePlanet(input[1]));
                    }
                    else if(input[0] == "Report")
                    {
                        this.writer.WriteLine(this.controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
