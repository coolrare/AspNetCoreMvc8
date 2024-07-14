
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
    public  void Update(Course entity)
    {
        var existingEntity = this.All().FirstOrDefault(p => p.CourseId == entity.CourseId);
        if (existingEntity != null)
        {
            existingEntity.Title = entity.Title;
            existingEntity.Credits = entity.Credits;
            existingEntity.Description = entity.Description;
            existingEntity.DepartmentId = entity.DepartmentId;
            // 更新其他需要的屬性
        }
    }
}

public interface ICourseRepository : IRepository<Course>
{
    Course? FindOne(int id);

    Course? FindOne(string slug);

    IQueryable<Course> FindAll();
    void Update(Course course);
}