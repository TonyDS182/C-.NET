using CRUD_Practica.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Practica.Data
{
    public class ApplicationDbcontext: DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
        {
            
        }

        //Agregar los modelos aquí (Cada modelo corresponde a una tabla en la BD)
        public DbSet<Contacto> contacto { get; set; }
    }
}
