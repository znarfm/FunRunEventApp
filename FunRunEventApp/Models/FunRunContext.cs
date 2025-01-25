using Microsoft.EntityFrameworkCore;

namespace FunRunEventApp.Models
{
    public class FunRunContext : DbContext
    {
        public FunRunContext(DbContextOptions<FunRunContext> options) : base(options)
        {
        }
        public DbSet<RegistrationModel> Registrations { get; set; }
    }
}
