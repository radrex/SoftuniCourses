namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Core.Factories;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        //-------------- Fields ---------------
        //private GunRepository<IGun> gunRepository;
        //private GunFactory gunFactory;
        //private INeighbourhood neighbourhood;


        private GunRepository<IGun> gunRepository;
        private GunFactory gunFactory;
        private GangNeighbourhood neighbourhood;


        private IPlayer mainPlayer;
        private Dictionary<string, IPlayer> players;

        private Queue<IGun> gunQueue;

        //----------- Constructors ------------
        //GunRepository<IGun> gunRepository, GunFactory gunFactory, INeighbourhood neighbourhood
        public Controller()
        {
            this.gunRepository = new GunRepository<IGun>();
            this.gunFactory = new GunFactory();
            this.neighbourhood = new GangNeighbourhood();

            this.mainPlayer = new MainPlayer();
            this.players = new Dictionary<string, IPlayer>();

            this.gunQueue = new Queue<IGun>();
        }

        //------------- Methods ---------------
        public string AddGun(string type, string name)
        {
            IGun gun = this.gunFactory.CreateGun(type, name);
            if (gun == null)
            {
                return $"Invalid gun type!";
            }

            this.gunRepository.Add(gun);
            this.gunQueue.Enqueue(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            IGun firstGun; 

            if (name == "Vercetti")
            {
                if (this.gunQueue.Count != 0)
                {
                    firstGun = this.gunQueue.Dequeue();
                }
                else
                {
                    return $"There are no guns in the queue!";
                }

                this.mainPlayer.GunRepository.Add(firstGun);
                return $"Successfully added {firstGun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!this.players.ContainsKey(name))
            {
                return $"Civil player with that name doesn't exists!";
            }

            if (this.gunQueue.Count != 0)
            {
                firstGun = this.gunQueue.Dequeue();
            }
            else
            {
                return $"There are no guns in the queue!";
            }

            this.players[name].GunRepository.Add(firstGun);
            return $"Successfully added {firstGun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            if (!this.players.ContainsKey(name))
            {
                this.players.Add(name, civilPlayer);
                return $"Successfully added civil player: {name}!";
            }

            this.players.Add(name, civilPlayer);
            return $"Civil player already exists";
        }

        public string Fight()
        {
            StringBuilder sb = new StringBuilder();

            int mainPlayerHPBeforeFight = this.mainPlayer.LifePoints;
            int civilPlayersSummedHPBeforeFight = this.players.Values.Sum(p => p.LifePoints);

            this.neighbourhood.Action(this.mainPlayer, this.players.Values.ToList()); // FIGHT

            int mainPlayerHPAfterFight = this.mainPlayer.LifePoints;
            int civilPlayersSummedHPAfterFight = this.players.Values.Sum(p => p.LifePoints);

            if (mainPlayerHPBeforeFight == mainPlayerHPAfterFight && civilPlayersSummedHPBeforeFight == civilPlayersSummedHPAfterFight)
            {
                sb.AppendLine($"Everything is okay!");
            }

            int deadCivs = this.players.Values.Count(p => !p.IsAlive);
            int aliveCivs = this.players.Values.Count(p => p.IsAlive);

            if (civilPlayersSummedHPBeforeFight != civilPlayersSummedHPAfterFight)
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayerHPAfterFight}!");
                sb.AppendLine($"Tommy has killed: {deadCivs} players!");
                sb.AppendLine($"Left Civil Players: {aliveCivs}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
