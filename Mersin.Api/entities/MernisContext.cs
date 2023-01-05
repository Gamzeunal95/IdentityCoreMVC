using Microsoft.EntityFrameworkCore;

namespace Mersin.Api.entities;

public partial class MernisContext : DbContext
{
    public MernisContext()
    {
    }

    public MernisContext(DbContextOptions<MernisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citizen> Citizens { get; set; }
    public virtual DbSet<User> Users { get; set; }  // Ekleme yapıldı.
    public virtual DbSet<Role> Roles { get; set; } // Ekleme yapıldı.
    public virtual DbSet<UserRole> UserRoles { get; set; } // Ekleme yapıldı.


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=11.0.17.100;Port=5432;Database=Mernis;User Id=postgres;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citizen>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("citizen_pkey");

            entity.ToTable("citizen");

            entity.HasIndex(e => e.IdRegistrationCity, "citizen_id_registration_city_idx");

            entity.HasIndex(e => e.Last, "citizen_last_idx");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AddressCity).HasColumnName("address_city");
            entity.Property(e => e.AddressDistrict).HasColumnName("address_district");
            entity.Property(e => e.AddressNeighborhood).HasColumnName("address_neighborhood");
            entity.Property(e => e.BirthCity).HasColumnName("birth_city");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DoorOrEntranceNumber).HasColumnName("door_or_entrance_number");
            entity.Property(e => e.FatherFirst).HasColumnName("father_first");
            entity.Property(e => e.First).HasColumnName("first");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.IdRegistrationCity).HasColumnName("id_registration_city");
            entity.Property(e => e.IdRegistrationDistrict).HasColumnName("id_registration_district");
            entity.Property(e => e.Last).HasColumnName("last");
            entity.Property(e => e.Misc).HasColumnName("misc");
            entity.Property(e => e.MotherFirst).HasColumnName("mother_first");
            entity.Property(e => e.NationalIdentifier).HasColumnName("national_identifier");
            entity.Property(e => e.StreetAddress).HasColumnName("street_address");
        });



        modelBuilder.Entity<UserRole>()
                    .HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<UserRole>()
                    .HasOne(p => p.User)
                    .WithMany(p => p.UserRoles);
        modelBuilder.Entity<UserRole>()
                    .HasOne(p => p.Role)
                    .WithMany(p => p.UserRoles);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
