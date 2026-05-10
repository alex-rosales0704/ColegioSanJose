using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Models;

namespace ColegioSanJose.Data
{
    public class ColegioSanJoseContext : DbContext
    {
        public ColegioSanJoseContext (DbContextOptions<ColegioSanJoseContext> options)
            : base(options)
        {
        }

        public DbSet<ColegioSanJose.Models.Alumno> Alumno { get; set; } = default!;
        public DbSet<ColegioSanJose.Models.Materia> Materia { get; set; } = default!;
        public DbSet<ColegioSanJose.Models.Expediente> Expediente { get; set; } = default!;
    }
}
