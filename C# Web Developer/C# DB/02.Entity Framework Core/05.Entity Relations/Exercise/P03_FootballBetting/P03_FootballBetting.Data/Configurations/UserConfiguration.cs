namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //------------ PRIMARY KEY -------------
            builder.HasKey(u => u.UserId);

            //------------ PROPERTIES --------------
            builder.Property(u => u.Name)
                   .IsRequired(true);

            builder.Property(u => u.Balance)
                   .IsRequired(true);

            builder.Property(u => u.Email)
                   .IsRequired(true);

            builder.Property(u => u.Password)
                   .IsRequired(true);

            builder.Property(u => u.Username)
                   .IsRequired(true);
        }
    }
}
