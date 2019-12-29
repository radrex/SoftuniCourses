namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasMany(b => b.Pets)
                   .WithOne(p => p.Breed)
                   .HasForeignKey(p => p.BreedId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
