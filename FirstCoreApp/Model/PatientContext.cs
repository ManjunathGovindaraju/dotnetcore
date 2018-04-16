using System;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreApp.Model
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
           : base(options)
        {
        }

        public DbSet<PatientItem> PatientItems { get; set; }
    }
}
