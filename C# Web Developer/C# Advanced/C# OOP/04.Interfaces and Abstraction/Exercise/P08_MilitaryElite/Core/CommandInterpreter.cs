namespace P08_MilitaryElite.Core
{
    using Contracts;
    using Models;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        //------------- Fields ---------------
        private ISoldier soldier;
        private ICollection<ISoldier> soldiers;

        //---------- Constructors ------------
        public CommandInterpreter()
        {
            this.soldier = null;
            this.soldiers = new List<ISoldier>();
        }

        //------------ Methods ---------------
        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            switch (soldierType)
            {
                case "Private":
                    {
                        decimal salary = decimal.Parse(args[4]);
                        this.soldier = new Private(id, firstName, lastName, salary);
                    }
                    break;

                case "LieutenantGeneral":
                    {
                        decimal salary = decimal.Parse(args[4]);
                        ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);  
                        this.soldier = lieutenantGeneral as ISoldier;

                        //----------------- Type check -----------------
                        if (this.soldier != null)
                        {
                            //-------------- Lieutenant General recruiting Privates ----------------
                            for (int i = 5; i < args.Length; i++)
                            {
                                //----------------- Type check -----------------
                                if (this.soldiers.FirstOrDefault(s => s.Id == int.Parse(args[i])) is IPrivate @private)
                                {
                                    lieutenantGeneral.AddPrivate(@private);
                                }
                            }
                        }
                    }
                    break;

                case "Engineer":
                    {
                        decimal salary = decimal.Parse(args[4]);
                        if (!Enum.TryParse(args[5], out Corps corps))
                        {
                            throw new Exception();
                        }

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        this.soldier = engineer as ISoldier;

                        //----------------- Type check -----------------
                        if (this.soldier != null)
                        {
                            //-------------- Engineer Repairs ----------------
                            for (int i = 6; i < args.Length; i+=2)
                            {
                                IRepair repair = new Repair(args[i], int.Parse(args[i + 1]));
                                engineer.AddRepair(repair);
                            }
                        }
                    }
                    break;

                case "Commando":
                    {
                        decimal salary = decimal.Parse(args[4]);
                        if (!Enum.TryParse(args[5], out Corps corps))
                        {
                            throw new Exception();
                        }

                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        this.soldier = commando as ISoldier;

                        //----------------- Type check -----------------
                        if (this.soldier != null)
                        {
                            //-------------- Commando Missions ----------------
                            for (int i = 6; i < args.Length; i+=2)
                            {
                                if (Enum.TryParse(args[i + 1], out MissionState missionState))
                                {
                                    IMission mission = new Mission(args[i], missionState);
                                    commando.AddMission(mission);
                                }
                            }
                        }
                    }
                    break;

                case "Spy":
                    {
                        int codeNumber = int.Parse(args[4]);
                        ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                        this.soldier = spy as ISoldier;

                        //----------------- Type check -----------------
                        if (this.soldier != null)
                        {
                            this.soldiers.Add(soldier);
                        }
                    }
                    break;

                default:
                    break;
            }

            this.soldiers?.Add(soldier);
            return this.soldier.ToString();
        }
    }
}
