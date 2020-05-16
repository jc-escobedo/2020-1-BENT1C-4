using Microsoft.EntityFrameworkCore;
using Grupo4.InstitutoEducativo.Models;

namespace UsandoEntityFramework.Database
{
    public class UsandoEFDbContext : DbContext
    {
        public UsandoEFDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Grupo4.InstitutoEducativo.Models.Profesor> Profesor { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.Materia> Materia { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.Carrera> Carrera { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.CarreraMateria> CarreraMateria { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.ProfesorMateria> ProfesorMateria { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.Alumno> Alumno { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.MateriaCursada> MateriaCursada { get; set; }
        public DbSet<Grupo4.InstitutoEducativo.Models.MateriaCursadaAlumno> MateriaCursadaAlumno { get; set; }
    }
}