using Microsoft.EntityFrameworkCore;

public interface IUnitOfWork
{
    DbContext Context { get; set; }
    void Commit();
    string ConnectionString { get; set; }
}
