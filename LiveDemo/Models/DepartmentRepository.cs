
public class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
{
    public override IQueryable<Department> All()
    {
        return base.All();
    }

    public Department? FindOne(int id)
    {
        return this.All().FirstOrDefault(p => p.DepartmentId == id);
    }

    public IQueryable<Department> FindAll()
    {
        return this.All();
    }
}

public interface IDepartmentRepository : IRepository<Department>
{
    Department? FindOne(int id);

    IQueryable<Department> FindAll();
}