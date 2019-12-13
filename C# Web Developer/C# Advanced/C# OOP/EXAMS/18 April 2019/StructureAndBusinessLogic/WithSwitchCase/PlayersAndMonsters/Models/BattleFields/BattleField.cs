namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                this.ModifyBeginner(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.ModifyBeginner(enemyPlayer);
            }

            this.AddHealthBonus(attackPlayer);
            this.AddHealthBonus(enemyPlayer);


            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
            }
        }

        private void ModifyBeginner(IPlayer player)
        {
            player.Health += 40;
            //player.CardRepository.Cards.Select(c => c.DamagePoints += 30);
            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }

        private void AddHealthBonus(IPlayer player)
        {
            player.Health += player.CardRepository.Cards.Sum(c => c.HealthPoints);
        }
    }
}
