namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(t => t.TownId);

            //------------ FOREIGN KEYS ------------
            builder.HasOne(t => t.Country)
                   .WithMany(c => c.Towns)
                   .HasForeignKey(t => t.CountryId);

            //------------ PROPERTIES --------------
            builder.Property(t => t.Name)
                   .IsRequired(true);
        }
    }
}
