using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;
using ViceCity.Core.Factories;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;
        private GunRepository<IGun> gunRepository;
        private GunFactory gunFactory;
        private GangNeighbourhood neighbourhood;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            this.gunRepository = new GunRepository<IGun>();
            this.gunFactory = new GunFactory();
            this.neighbourhood = new GangNeighbourhood();

            //gunRepository, gunFactory, neighbourhood
            this.controller = new Controller();
        }
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
                    if (input[0] == "AddPlayer")
                    {
                        this.writer.WriteLine(this.controller.AddPlayer(input[1]));
                    }
                    else if (input[0] == "AddGun")
                    {
                        this.writer.WriteLine(this.controller.AddGun(input[1], input[2]));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        this.writer.WriteLine(this.controller.AddGunToPlayer(input[1]));
                    }
                    else if (input[0] == "Fight")
                    {
                        this.writer.WriteLine(this.controller.Fight());
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
