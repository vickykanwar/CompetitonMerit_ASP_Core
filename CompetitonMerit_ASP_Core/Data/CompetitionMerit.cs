using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompetitonMerit_ASP_Core.Model;

namespace CompetitonMerit_ASP_Core.Data
{
    public class CompetitionMerit : DbContext
    {
        public CompetitionMerit (DbContextOptions<CompetitionMerit> options)
            : base(options)
        {
        }

        public DbSet<CompetitonMerit_ASP_Core.Model.Subject> Subject { get; set; }

        public DbSet<CompetitonMerit_ASP_Core.Model.Student_participate> Student_participate { get; set; }

        public DbSet<CompetitonMerit_ASP_Core.Model.School> School { get; set; }

        public DbSet<CompetitonMerit_ASP_Core.Model.Meritlist> Meritlist { get; set; }
    }
}
