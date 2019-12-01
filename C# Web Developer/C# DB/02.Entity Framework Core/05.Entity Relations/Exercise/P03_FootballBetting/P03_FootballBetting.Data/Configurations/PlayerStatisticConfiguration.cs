namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(ps => new { ps.PlayerId, ps.GameId });

            //------------ FOREIGN KEYS ------------
            builder.HasOne(ps => ps.Player)
                   .WithMany(p => p.PlayerStatistics)
                   .HasForeignKey(ps => ps.PlayerId);

            builder.HasOne(ps => ps.Game)
                   .WithMany(g => g.PlayerStatistics)
                   .HasForeignKey(ps => ps.GameId);

            //------------ PROPERTIES --------------
            builder.Property(ps => ps.Assists)
                   .IsRequired(true);

            builder.Property(ps => ps.MinutesPlayed)
                   .IsRequired(true);

            builder.Property(ps => ps.ScoredGoals)
                   .IsRequired(true);
        }
    }
}
