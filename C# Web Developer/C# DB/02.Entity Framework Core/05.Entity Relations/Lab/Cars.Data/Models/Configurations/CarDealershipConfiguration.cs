namespace Cars.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarDealershipConfiguration : IEntityTypeConfiguration<CarDealership>
    {
        public void Configure(EntityTypeBuilder<CarDealership> builder)
        {
            builder.HasKey(cd => new { cd.CarId, cd.DealershipId });

            builder.ToTable("CarsDealerships");

            builder.HasOne(cd => cd.Car)
                   .WithMany(c => c.CarsDealerships)
                   .HasForeignKey(cd => cd.CarId);

            builder.HasOne(cd => cd.Dealership)
                   .WithMany(d => d.CarsDealerships)
                   .HasForeignKey(cd => cd.DealershipId);
        }
    }
}
