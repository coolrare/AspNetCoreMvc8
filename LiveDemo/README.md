
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

## 請給我這個 專案結構
```txt
LiveDemo/
├── ActionFilters/
│   └── 計算每個頁面的實際執行時間Attribute.cs
├── Controllers/
│   ├── HomeController.cs
│   ├── LectureController.cs
│   └── AccountController.cs
├── Models/
│   ├── Course.cs
│   ├── Department.cs
│   ├── Enrollment.cs
│   ├── Person.cs
│   └── CourseCreate.cs
│   ├── OfficeAssignment.cs
│   ├── CourseMetadata.cs
│   ├── DepartmentMetadata.cs
│   ├── ICourseRepository.cs
│   ├── IDepartmentRepository.cs
│   ├── IRepository.cs
│   ├── IUnitOfWork.cs
│   └── EFRepository.cs
│   └── EFUnitOfWork.cs
├── Services/
│   ├── MyService.cs
├── Utils/
│   └── StringExt.cs
├──ValidationAttributes/
│   └── CheckCourseTitleAttribute.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── course/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   └── Details.cshtml
│   ├── Lecture/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   └── Details.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/
│       ├── bootstrap/
│       └── jquery/
├── appsettings.json
├── Program.cs
├── LiveDemo.csproj
└── README.md
```