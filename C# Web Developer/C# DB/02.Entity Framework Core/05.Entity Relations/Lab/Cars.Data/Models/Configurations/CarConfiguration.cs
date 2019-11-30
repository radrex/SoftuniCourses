namespace Cars.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(c => c.LicensePlate)
                   .WithOne(lp => lp.Car)
                   .HasForeignKey<LicensePlate>(lp => lp.CarId);

            builder.HasOne(c => c.Make)
                   .WithMany(m => m.Cars)
                   .HasForeignKey(c => c.MakeId);
        }
    }
}
