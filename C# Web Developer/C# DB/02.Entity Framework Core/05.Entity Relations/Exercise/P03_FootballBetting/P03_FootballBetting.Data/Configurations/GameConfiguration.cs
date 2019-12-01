namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(g => g.GameId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(g => g.AwayTeam)
                   .WithMany(at => at.AwayGames)
                   .HasForeignKey(g => g.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.HomeTeam)
                   .WithMany(ht => ht.HomeGames)
                   .HasForeignKey(g => g.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            //------------ PROPERTIES --------------
            builder.Property(g => g.AwayTeamBetRate)
                   .IsRequired(true);

            builder.Property(g => g.AwayTeamGoals)
                   .IsRequired(true);

            builder.Property(g => g.DrawBetRate)
                   .IsRequired(true);

            builder.Property(g => g.HomeTeamBetRate)
                   .IsRequired(true);

            builder.Property(g => g.HomeTeamGoals)
                   .IsRequired(true);

            builder.Property(g => g.Result)
                   .IsRequired();

            builder.Property(g => g.DateTime)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);
        }
    }
}
