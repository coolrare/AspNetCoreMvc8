
```cs
public class Item
{
	name, 
	desc
}
```

```cs
public ActionResult Create(List<Item> selectedCourses)
{
}

```


WRONG

```txt
selectedCourses[0][name]=AAA&selectedCourses[0][desc]=DescA
&& selectedCourses[1][name]=BBB&selectedCourses[1][desc]=DescB
```

CORRECT

```txt
selectedCourses[0].name=AAA&selectedCourses[0].desc=DescA&
selectedCourses[1].name=BBB&selectedCourses[1].desc=DescB
```

## �е��ڳo�� �M�׵��c
```txt
LiveDemo/
�u�w�w ActionFilters/
�x   �|�w�w �p��C�ӭ�������ڰ���ɶ�Attribute.cs
�u�w�w Controllers/
�x   �u�w�w HomeController.cs
�x   �u�w�w LectureController.cs
�x   �|�w�w AccountController.cs
�u�w�w Models/
�x   �u�w�w Course.cs
�x   �u�w�w Department.cs
�x   �u�w�w Enrollment.cs
�x   �u�w�w Person.cs
�x   �|�w�w CourseCreate.cs
�x   �u�w�w OfficeAssignment.cs
�x   �u�w�w CourseMetadata.cs
�x   �u�w�w DepartmentMetadata.cs
�x   �u�w�w ICourseRepository.cs
�x   �u�w�w IDepartmentRepository.cs
�x   �u�w�w IRepository.cs
�x   �u�w�w IUnitOfWork.cs
�x   �|�w�w EFRepository.cs
�x   �|�w�w EFUnitOfWork.cs
�u�w�w Services/
�x   �u�w�w MyService.cs
�u�w�w Utils/
�x   �|�w�w StringExt.cs
�u�w�wValidationAttributes/
�x   �|�w�w CheckCourseTitleAttribute.cs
�u�w�w Views/
�x   �u�w�w Home/
�x   �x   �u�w�w Index.cshtml
�x   �x   �|�w�w Privacy.cshtml
�x   �u�w�w course/
�x   �x   �u�w�w Index.cshtml
�x   �x   �u�w�w Create.cshtml
�x   �x   �u�w�w Edit.cshtml
�x   �x   �u�w�w Delete.cshtml
�x   �x   �|�w�w Details.cshtml
�x   �u�w�w Lecture/
�x   �x   �u�w�w Index.cshtml
�x   �x   �u�w�w Create.cshtml
�x   �x   �u�w�w Edit.cshtml
�x   �x   �u�w�w Delete.cshtml
�x   �x   �|�w�w Details.cshtml
�x   �|�w�w Shared/
�x       �u�w�w _Layout.cshtml
�x       �|�w�w _ValidationScriptsPartial.cshtml
�u�w�w wwwroot/
�x   �u�w�w css/
�x   �x   �|�w�w site.css
�x   �u�w�w js/
�x   �x   �|�w�w site.js
�x   �|�w�w lib/
�x       �u�w�w bootstrap/
�x       �|�w�w jquery/
�u�w�w appsettings.json
�u�w�w Program.cs
�u�w�w LiveDemo.csproj
�|�w�w README.md
```