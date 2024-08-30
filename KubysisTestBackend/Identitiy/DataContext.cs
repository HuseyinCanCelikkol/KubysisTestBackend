using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace KubysisTestBackend.Data
{
    public class DataContext : IdentityDbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)    
        {
               
        }
    }
}
