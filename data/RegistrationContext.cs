using System;
using labo02.Configuration;
using labo02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace labo02.data
{
    public class RegistrationContext : DbContext
    {
        public DbSet<VaccinType> VaccinTypes { get; set; }
        public DbSet<VaccinationRegistration> VaccininationRegistration { get; set; }
        public DbSet<VaccinationLocation> VaccinationLocation { get; set; }

        private DBSettings _settings;
        private readonly ILogger<RegistrationContext> _logger;

        public RegistrationContext(
            DbContextOptions<RegistrationContext> options,
            IOptions<DBSettings> settings,
            ILogger<RegistrationContext> logger
            )
        : base(options)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_settings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<VaccinationLocation>().HasData(new VaccinationLocation()
            {
                VaccinationLocationId = Guid.NewGuid(),
                Name = "Kortrijk Expo"
            });
 
            modelBuilder.Entity<VaccinationLocation>().HasData(new VaccinationLocation()
            {
                VaccinationLocationId = Guid.NewGuid(),
                Name = "Gent Expo"
            });
 
            modelBuilder.Entity<VaccinType>().HasData(new VaccinType()
            {
                VaccinTypeId = Guid.NewGuid(),
                Name = "Pfizer"
            });
 
            modelBuilder.Entity<VaccinType>().HasData(new VaccinType()
            {
                VaccinTypeId = Guid.NewGuid(),
                Name = "Spoetnik"
            });
        }
    }
}
