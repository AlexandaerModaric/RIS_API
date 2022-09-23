using Microsoft.EntityFrameworkCore;
using Ris2022.Data.Models;

namespace RIS_API.Data
{
    public class RISDbContext:DbContext
    {
        public RISDbContext()
        { }
        public RISDbContext(DbContextOptions<RISDbContext> options) : base(options)
        { }

        public DbSet<Patient> Patients { set; get; }
        public DbSet<HL7Message> HL7Messages { set; get; }
        public DbSet<Modality> Modalities { set; get; }
        public DbSet<Modalitytype> Modalitytypes { set; get; }
        public DbSet<Proceduretype> Proceduretypes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modalitytype>().HasData(
                new Modalitytype
                {
                    Id=1,
                    Name = "CR",
                },
                new Modalitytype
                {
                    Id=2,
                    Name = "DR",
                }
                );
            modelBuilder.Entity<Proceduretype>().HasData(
                new Proceduretype
                {
                    Id = 1,
                    Name = "Shoulder",
                },
                new Modalitytype
                {
                    Id = 2,
                    Name = "Head",
                }
                );
            modelBuilder.Entity<Modality>().HasData(
                new Modality
                {
                    Id = 1,
                    Name = "CR_Modality",
                    AeTitle = "CRModAE",
                    IpAddress = "127.0.0.1",
                    Port = 104,
                    Modalitytypeid =1,
                    Description = "CR Modality"
                },
                new Modality
                {
                    Id = 2,
                    Name = "MR_Modality",
                    AeTitle = "MRModAE",
                    IpAddress = "127.0.0.1",
                    Port = 104,
                    Modalitytypeid = 1,
                    Description = "MR Modality"
                }
                );
        }
    }
}
