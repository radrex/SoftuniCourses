namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(b => b.BetId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bets)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Game)
                   .WithMany(g => g.Bets)
                   .HasForeignKey(b => b.GameId);

            //------------ PROPERTIES --------------
            builder.Property(b => b.Amount)
                   .IsRequired(true);

            builder.Property(b => b.Prediction)
                   .IsRequired(true);

            builder.Property(b => b.DateTime)
                   .HasColumnType("DATETIME2")
                   .IsRequired(true);
        }
    }
}
