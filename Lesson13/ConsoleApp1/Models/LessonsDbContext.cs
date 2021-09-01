using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    public class LessonsDbContext : DbContext
    {
        public LessonsDbContext(DbContextOptions options) : base(options)
        {
        }

        public LessonsDbContext()
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Lessons;Integrated Security=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .Property(i => i.Name)
                .IsRequired();

            modelBuilder.Entity<StudentProfile>()
                .HasOne(i => i.StudentRecord)
                .WithOne(i => i.Profile)
                .HasForeignKey<StudentProfile>(i => i.StudentRecordId);

            modelBuilder.Entity<Room>()
                .HasMany(i => i.Students)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId);

            modelBuilder.Entity<Student>()
                .HasMany(i => i.Teachers)
                .WithMany(i => i.Students)
                .UsingEntity(i => i.ToTable("TeachersStudents"));

            modelBuilder.Entity<Student>()
                .HasMany(i => i.Roles)
                .WithMany(i => i.Students);

            modelBuilder.Entity<Dog>()
                .ToTable("Dogs");

            modelBuilder.Entity<Bird>()
                .ToTable("Birds");

            modelBuilder.Entity<Pipe>()
                .OwnsOne(i => i.Diameter);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }

        public virtual DbSet<Pipe> Pipes { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
    }
}