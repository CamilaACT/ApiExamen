using ApiExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(

            DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Tarea> Tareas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    ID=1,
                    Nombre="Camila",
                    Estado="Por hacer",
                    Tareas="Acabar la API"

                });
        }



    }


    

    }
