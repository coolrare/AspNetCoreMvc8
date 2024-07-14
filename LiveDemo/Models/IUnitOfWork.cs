using Microsoft.EntityFrameworkCore;

public interface IUnitOfWork
{
    DbContext Context { get; set; }
    void Commit();
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    string ConnectionString { get; set; }
}
