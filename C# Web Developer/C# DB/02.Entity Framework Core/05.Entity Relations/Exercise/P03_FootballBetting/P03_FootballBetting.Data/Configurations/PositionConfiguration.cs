namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(p => p.PositionId);

            //------------ PROPERTIES --------------
            builder.Property(p => p.Name)
                   .IsRequired(true);
        }
    }
}
