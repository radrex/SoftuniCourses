namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> builder)
        {
            builder.HasKey(to => new { to.ToyId, to.OrderId });

            builder.HasOne(to => to.Toy)
                   .WithMany(t => t.Orders)
                   .HasForeignKey(to => to.ToyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(to => to.Order)
                   .WithMany(o => o.Toys)
                   .HasForeignKey(to => to.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
