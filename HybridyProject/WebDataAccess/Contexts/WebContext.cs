namespace WebDataAccess.Contexts
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        public virtual DbSet<MyClass> MyClasses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
    }
}
