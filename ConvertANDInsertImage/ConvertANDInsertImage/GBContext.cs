using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertANDInsertImage
{
    public class GBContext : DbContext
    {
        // "Data Source=192.192.192.228\MFI;Initial Catalog=GB_eRecruitment_OfficerEngineer_24_December_2022_Recovered;User Id=sqladmin;Password=Gr@meenadminP@ss;"
        public GBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"server=192.192.192.228\MFI;database=GB_eRecruitment_OfficerEngineer_24_December_2022_Recovered;User Id=sqladmin;Password=Gr@meenadminP@ss;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //modelBuilder.Entity<SELECTECandidate>(entity =>
            //{ entity.HasNoKey();
            //    entity.ToTable("SELECTECandidate");
            //});
        }
        public DbSet<SELECTECandidate> sELECTECandidates { get; set; }
    }
}
