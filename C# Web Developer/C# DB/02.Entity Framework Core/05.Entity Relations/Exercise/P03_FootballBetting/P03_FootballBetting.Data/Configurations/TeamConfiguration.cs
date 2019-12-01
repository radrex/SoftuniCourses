namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(t => t.TeamId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(t => t.Town)
                   .WithMany(town => town.Teams)
                   .HasForeignKey(t => t.TownId);

            builder.HasOne(t => t.PrimaryKitColor)
                   .WithMany(pkc => pkc.PrimaryKitTeams)
                   .HasForeignKey(t => t.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
                   .WithMany(skc => skc.SecondaryKitTeams)
                   .HasForeignKey(t => t.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            //------------ PROPERTIES --------------
            builder.Property(t => t.Name)
                   .IsRequired(true);

            builder.Property(t => t.Budget)
                   .IsRequired(true);

            builder.Property(t => t.Initials)
                   .IsRequired(true);

            builder.Property(t => t.LogoUrl)
                   .IsRequired(true);
        }
    }
}
