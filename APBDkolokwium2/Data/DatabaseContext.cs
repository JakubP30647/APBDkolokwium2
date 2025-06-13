namespace APBDkolokwium2;

using Microsoft.EntityFrameworkCore;



public class DatabaseContext: DbContext
{

    
    
    public DatabaseContext(){}
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        
       

    }
}