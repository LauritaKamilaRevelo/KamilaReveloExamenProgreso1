using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KamilaReveloExamenProgreso1.Models;

    public class KamilaReveloExamenProgreso1Context : DbContext
    {
        public KamilaReveloExamenProgreso1Context (DbContextOptions<KamilaReveloExamenProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<KamilaReveloExamenProgreso1.Models.KRmodelo1> KRmodelo1 { get; set; } = default!;
    }
