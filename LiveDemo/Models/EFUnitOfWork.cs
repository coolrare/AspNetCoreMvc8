
public class EFUnitOfWork : IUnitOfWork
{
    public DbContext Context { get; set; }

    public EFUnitOfWork(ContosoUniversityContext context)
    {
        Context = context;
    }

    public void Commit()
    {
        Context.SaveChanges();
    }

    public string ConnectionString
    {
        get { return Context.Database.GetConnectionString()!; }
        set { Context.Database.SetConnectionString(value); }
    }
}
