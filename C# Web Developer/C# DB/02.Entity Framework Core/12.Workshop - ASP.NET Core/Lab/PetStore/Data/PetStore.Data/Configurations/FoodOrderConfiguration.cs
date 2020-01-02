namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> builder)
        {
            builder.HasKey(fo => new { fo.FoodId, fo.OrderId });

            builder.HasOne(fo => fo.Food)
                   .WithMany(f => f.Orders)
                   .HasForeignKey(fo => fo.FoodId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fo => fo.Order)
                   .WithMany(o => o.Foods)
                   .HasForeignKey(fo => fo.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
