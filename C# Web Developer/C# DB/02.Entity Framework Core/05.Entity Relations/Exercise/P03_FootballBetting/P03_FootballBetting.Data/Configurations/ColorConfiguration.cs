namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(c => c.ColorId);

            //------------ PROPERTIES --------------
            builder.Property(c => c.Name)
                   .IsRequired(true);
        }
    }
}
