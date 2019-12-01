namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(p => p.PlayerId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(p => p.Position)
                   .WithMany(pos => pos.Players)
                   .HasForeignKey(p => p.PositionId);

            builder.HasOne(p => p.Team)
                   .WithMany(t => t.Players)
                   .HasForeignKey(p => p.TeamId);

            //------------ PROPERTIES --------------
            builder.Property(p => p.Name)
                   .IsRequired(true);

            builder.Property(p => p.IsInjured)
                   .IsRequired(true);

            builder.Property(p => p.SquadNumber)
                   .IsRequired(true);
        }
    }
}
