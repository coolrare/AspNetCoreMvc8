
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
    public void Update<T>(T entity) where T : class
    {
        Context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        Context.Remove(entity);
    }

    public string ConnectionString
    {
        get { return Context.Database.GetConnectionString()!; }
        set { Context.Database.SetConnectionString(value); }
    }

    
}
