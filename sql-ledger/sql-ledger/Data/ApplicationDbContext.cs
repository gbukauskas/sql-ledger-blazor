using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sql_ledger.Data.Model;

namespace sql_ledger.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Acc_trans> AccTransactions { get; set; }
        public DbSet<AcsRole> AcsRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ap> Aps { get; set; }
        public DbSet<Ar> Ars { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<ArchiveData> ArchiveDatas { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("public_id")
                .StartsAt(10000)
                .IncrementsBy(1);

            Acc_trans.Configure(builder);
            AcsRole.Configure(builder);
            Address.Configure(builder);
            Ap.Configure(builder);
            Ar.Configure(builder);
            Archive.Configure(builder);
            ArchiveData.Configure(builder);
            Assembly.Configure(builder);
            AuditTrail.Configure(builder);
        }
    }
}
