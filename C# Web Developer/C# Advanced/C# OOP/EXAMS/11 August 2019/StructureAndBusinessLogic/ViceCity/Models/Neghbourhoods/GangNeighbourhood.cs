namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            IPlayer aliveCivilPlayer = civilPlayers.FirstOrDefault(cp => cp.IsAlive);
            IGun loadedGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);

            while (aliveCivilPlayer != null && loadedGun != null)
            {
                int shots = loadedGun.Fire();
                aliveCivilPlayer.TakeLifePoints(shots);

                aliveCivilPlayer = civilPlayers.FirstOrDefault(cp => cp.IsAlive);
                loadedGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);
            }

            List<IPlayer> alivePlayers = civilPlayers.Where(p => p.IsAlive).ToList();
            foreach (IPlayer player in alivePlayers)
            {
                loadedGun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire);
                while (mainPlayer.IsAlive && loadedGun != null)
                {
                    int shots = loadedGun.Fire();
                    mainPlayer.TakeLifePoints(shots);
                }
            }
        }
    }
}
