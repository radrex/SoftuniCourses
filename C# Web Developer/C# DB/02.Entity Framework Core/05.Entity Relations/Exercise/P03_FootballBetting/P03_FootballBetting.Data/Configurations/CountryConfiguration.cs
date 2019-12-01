namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(c => c.CountryId);

            //------------ PROPERTIES --------------
            builder.Property(c => c.Name)
                   .IsRequired(true);
        }
    }
}
