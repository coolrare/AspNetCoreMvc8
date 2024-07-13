
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
