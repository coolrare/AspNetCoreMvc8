
public class CourseRepository : EFRepository<Course>, ICourseRepository
{
    public override IQueryable<Course> All()
    {
        return base.All().Where(p => p.IsDeleted == false);
    }

    public Course? FindOne(int id)
    {
        return this.All().FirstOrDefault(p => p.CourseId == id);
    }

    public Course? FindOne(string slug)
    {
        return this.All().FirstOrDefault(p => p.Slug == slug);
    }

    public IQueryable<Course> FindAll()
    {
        return this.All();
    }

    public override void Delete(Course entity)
    {
        entity.IsDeleted = true;
    }
}

public interface ICourseRepository : IRepository<Course>
{
    Course? FindOne(int id);

    Course? FindOne(string slug);

    IQueryable<Course> FindAll();
}