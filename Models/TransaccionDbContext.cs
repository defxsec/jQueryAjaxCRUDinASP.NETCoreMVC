using Microsoft.EntityFrameworkCore;

namespace jQueryAjaxCRUDinASP.NETCoreMVC.Models
{
    public class TransaccionDbContext : DbContext
    {
        public TransaccionDbContext(DbContextOptions<TransaccionDbContext> options) : base(options)
        {
                
        }
        public DbSet<TransaccionModel> Transacciones { get; set; }
    }
}
