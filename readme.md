# Kodehode - Backend Modul 1: Uke 4

## NB! KI Bruksnotat: *Følgende tekst ble genereret vha. ChatGPT 5.5 utfra commit kommentarer, commit innhold og noe ekstra prompting. Det aller meste skal være korrekt men det kan være noen ting er litt uklart.*

# Backend4 C# Beginner Curriculum

## Week 4: Object-Oriented Programming, Classes, Instances, Services, Repositories, and LINQ

# Week 4 Tema

In this week, we start moving from simple procedural code toward object-oriented architecture.

* What a class is
* What an object / instance is
* How to create an object with `new`
* How properties store data inside an object
* How multiple objects can be created from the same class
* How a constructor works
* Why constructors help create valid objects
* How to change `List<string>` into `List<Tag>`
* How to update methods when a data type changes
* How to separate responsibilities between classes
* What a model class is
* What a service class is
* What a repository class is
* How to save object data as text
* How to load text data back into objects
* How `return` exits a method
* How `continue` skips one loop iteration
* How LINQ methods like `.Any()` and `.Where()` can replace manual loops
* How lambda expressions work at a beginner level

---

# Session 1: Classes, Instances, and Models

Session 1 focuses on the idea that a program can create objects from classes. The `Tag` class becomes the first custom model in the project.

---

## Commit 1: `init project`

### Learning objective

Set up the `Backend4` project and start from an existing tag-manager console application.

### Code changes

This commit creates the main project files:

* `Backend4.csproj`
* `Program.cs`
* `TagPrinter.cs`
* `readme.md`
* `taglist.txt`
* build output files

The starting program already contains a menu:

```text
1. Enter new tags
2. Show current tags
3. Save tags
4. Load tags
5. Exit
```

The program stores tags as a `List<string>`, uses `ParseTags` to split comma-separated input, uses `TagPrinter.Print` to display tags, and uses `File.WriteAllLines` / `File.ReadAllLines` for saving and loading.

### Explanation for beginners

This commit is the starting point for Week 4.

The important thing to notice is that the app already works with tags, but each tag is only plain text:

```csharp
List<string> tagsList = new List<string>();
```

That means each tag is just a `string`, such as:

```text
code
coffee
school
```

This is simple, but limited. If we later want a tag to have more data, such as a name, color, date created, or category, a plain string is not enough.

That is why this week starts moving toward objects.

### Mini tasks

1. Run the program and test all menu options.
2. Enter tags separated by commas, for example `code, coffee, school`.
3. Find where `tagsList` is created in `Program.cs`.
4. Find the `ParseTags` method and explain what `Split(",")` does.
5. Find `TagPrinter.cs` and explain what its `Print` method does.

### Expected outcome

The learner should understand the baseline project: a console tag manager that stores tags as strings and uses methods to parse, print, save, and load data.

---

## Commit 2: `Instance example using the biuolt in Random class. Additionally we ran a test on rolls in range (comment above the loop)`

### Learning objective

Introduce the idea of using an existing class by creating an instance of it.

### Code changes

A `.gitignore` file is added.

The README is updated to include static vs instance as a learning topic.

Temporary code is added at the top of `Main`:

```csharp
Random random = new Random();

for (int i = 0; i < 10000; i++)
{
    int diceResult = random.Next(1,6);
    if (diceResult == 6)
    {
        Console.WriteLine("SIX!");
        break;
    }
}

return;
```

The existing tag-manager code is still below this, but the `return;` stops the program before it reaches the menu.

### Explanation for beginners

`Random` is a class that already exists in C#.

A class is like a blueprint. To use many classes, we create an object from the blueprint:

```csharp
Random random = new Random();
```

This creates an instance named `random`.

The code then calls a method on that instance:

```csharp
random.Next(1, 6);
```

This asks the random object to give us a number.

Important beginner note: in C#, `Random.Next(min, max)` includes the minimum value, but excludes the maximum value. That means:

```csharp
random.Next(1, 6);
```

can return `1`, `2`, `3`, `4`, or `5`, but not `6`.

This makes the commit a useful debugging and investigation example.

### Mini tasks

1. Change `random.Next(1, 6)` to `random.Next(1, 7)`.
2. Print every dice result instead of only printing when the result is 6.
3. Change the loop from `10000` rounds to `20` rounds.
4. Remove the `break` and observe what changes.
5. Explain what `new Random()` means in your own words.

### Expected outcome

The learner should understand that some C# classes need to be instantiated with `new` before their instance methods can be used.

---

## Commit 3: `using an instance of random to create random numbers.`

### Learning objective

Use an instance method repeatedly to produce random dice rolls.

### Code changes

The random example is simplified:

```csharp
Random random = new Random();

for (int i = 0; i < 10; i++)
{
    int diceResult = random.Next(1,7);
    Console.WriteLine("Roll (" + i + "): "  + diceResult);
}

return;
```

The loop now runs 10 times and prints each result.

### Explanation for beginners

This commit shows a cleaner example of object usage.

The object is created once:

```csharp
Random random = new Random();
```

Then the same object is reused many times:

```csharp
random.Next(1, 7)
```

This is common in object-oriented programming.

We create an object, then ask it to do work by calling methods on it.

The dot operator connects an object to one of its members:

```csharp
random.Next(...)
```

means:

> Use the `Next` method belonging to the `random` object.

### Mini tasks

1. Change the loop so it rolls 20 times.
2. Change the range to simulate a coin flip with values 1 and 2.
3. Print `"High roll!"` if the result is 5 or 6.
4. Create a variable called `total` and add all dice results together.
5. Explain why `random.Next(1, 7)` is better for dice than `random.Next(1, 6)`.

### Expected outcome

The learner should be able to create an object from a built-in class and call an instance method several times.

---

## Commit 4: `using the tag model to create an instance and use it`

### Learning objective

Create the first custom model class: `Tag`.

### Code changes

A new file is added:

```csharp
class Tag
{
    public string Name { get; set; }
}
```

Temporary code creates a `Tag` instance:

```csharp
Tag tag = new Tag();
tag.Name = "Hello world!";
Console.WriteLine(tag.Name);

return;
```

Inside `ParseTags`, the code also starts experimenting with creating a `Tag` object from cleaned tag text.

### Explanation for beginners

This is the first custom class in the project.

```csharp
class Tag
{
    public string Name { get; set; }
}
```

This means:

> A `Tag` object can store a `Name`.

`Name` is a property. A property is data stored inside an object.

This line creates an object:

```csharp
Tag tag = new Tag();
```

This line changes the object’s data:

```csharp
tag.Name = "Hello world!";
```

This line reads the object’s data:

```csharp
Console.WriteLine(tag.Name);
```

The class is the blueprint. The object is the actual thing created from that blueprint.

### Mini tasks

1. Change `"Hello world!"` to another tag name.
2. Add a second property to `Tag`, such as `public string Color { get; set; }`.
3. Set `tag.Color` and print it.
4. Explain the difference between `Tag` and `tag`.
5. Create a second `Tag` object manually.

### Expected outcome

The learner should understand that a custom class can model data and that objects are created from classes with `new`.

---

## Commit 5: `example how to create multiple instances of the Tag class model`

### Learning objective

Show that one class can be used to create many separate objects.

### Code changes

A second `Tag` object is created:

```csharp
Tag tag2 = new Tag();
tag2.Name = "Good bye world!";
Console.WriteLine(tag2.Name);
```

The first `Tag` object still exists separately.

### Explanation for beginners

A class is a blueprint, and we can use the same blueprint many times.

Example:

```csharp
Tag tag = new Tag();
Tag tag2 = new Tag();
```

These are two different objects.

Changing one object does not automatically change the other.

```csharp
tag.Name = "Hello world!";
tag2.Name = "Good bye world!";
```

Now the two objects have different `Name` values.

This is one of the most important ideas in object-oriented programming.

### Mini tasks

1. Create a third `Tag` object called `tag3`.
2. Give all three tags different names.
3. Print all three names.
4. Change only `tag2.Name` and confirm that `tag.Name` does not change.
5. Explain why multiple objects from the same class can store different data.

### Expected outcome

The learner should understand that objects created from the same class are independent instances.

---

## Commit 6: `use tag model in the ParseTags method, but only add tag.Name to tagsList this time.`

### Learning objective

Start integrating the `Tag` model into the real tag parsing flow.

### Code changes

The temporary two-tag example is removed from the top of `Main`, so the normal app can run again.

Inside `ParseTags`, each cleaned string is converted into a `Tag` object:

```csharp
Tag tag = new Tag();
tag.Name = cleanedItem;
```

But the list still stores strings:

```csharp
tagsList.Add(tag.Name);
```

### Explanation for beginners

This is a transition commit.

The program is starting to use the `Tag` class, but it has not fully changed the app to store `Tag` objects yet.

The code creates a `Tag` object:

```csharp
Tag tag = new Tag();
```

Then it gives the object a name:

```csharp
tag.Name = cleanedItem;
```

But then it only stores the name:

```csharp
tagsList.Add(tag.Name);
```

So the final list is still a `List<string>`.

This is common during refactoring. Sometimes code moves from an old structure to a new structure in small steps.

### Mini tasks

1. Find the type of `tagsList`. Is it still `List<string>`?
2. Explain why `tag.Name` is a string.
3. Add a `Console.WriteLine(tag.Name)` before adding it to the list.
4. Predict what would happen if you tried `tagsList.Add(tag)` while the list is still `List<string>`.
5. Explain why this commit is only a partial migration to objects.

### Expected outcome

The learner should understand that changing an app from strings to objects often requires several related code changes.

---

## Commit 7: `Fix TagPrinter as well as methods in the Main-Programcs file to work with the Tag-Model-Class`

### Learning objective

Convert the app from `List<string>` to `List<Tag>`.

### Code changes

The main tag list changes:

```csharp
List<Tag> tagsList = new List<Tag>();
```

`ParseTags` now returns `List<Tag>` instead of `List<string>`.

The parsed tag object is added directly:

```csharp
tagsList.Add(tag);
```

`TagPrinter` is updated to print `Tag` objects:

```csharp
public static void Print(Tag tag)
{
    Console.WriteLine("#" + tag.Name);
}
```

and:

```csharp
public static void Print(List<Tag> tags)
{
    foreach (Tag tag in tags)
    {
        Console.WriteLine("#" + tag.Name);
    }
}
```

The save and load code is temporarily commented out because file saving/loading needs to be adjusted for objects.

### Explanation for beginners

This is a major refactor.

Before this commit, the app mostly worked with text:

```csharp
List<string>
```

Now it works with tag objects:

```csharp
List<Tag>
```

That means each item in the list is no longer just text. Each item is a `Tag` object with a `Name` property.

Because the data type changed, every method that works with tags must also be updated.

This is why `TagPrinter` changes from printing strings to printing `tag.Name`.

### Mini tasks

1. Find every place where `List<Tag>` appears.
2. Explain why `Console.WriteLine(tag)` is not as useful as `Console.WriteLine(tag.Name)`.
3. Add another property to `Tag`, such as `Description`, and try printing it.
4. Explain why file saving was temporarily commented out.
5. Write a short sentence explaining what refactoring means.

### Expected outcome

The learner should understand that when a data model changes, related methods and lists must be updated to use the new type correctly.

---

# Session 2: Constructors and Cleaner Object Creation

Session 2 focuses on constructors: special methods that run when an object is created.

---

## Commit 8: `constructor intro (example without a constructor)`

### Learning objective

Prepare for constructors by showing the old way of creating an object and setting its data afterward.

### Code changes

Temporary code is added at the top of `Main`:

```csharp
Tag tag = new Tag();
tag.Name = "some data";
Console.WriteLine(tag.Name);

return;
```

The `return;` means the main tag-manager menu does not run during this example.

### Explanation for beginners

This commit shows object creation in two steps:

1. Create the object.
2. Fill in its data.

```csharp
Tag tag = new Tag();
tag.Name = "some data";
```

This works, but it has a weakness.

For a short moment, the object exists without a meaningful name.

Constructors help solve that problem by allowing us to pass important data when the object is created.

### Mini tasks

1. Change `"some data"` to another tag name.
2. Add a second `Tag` and set its `Name` manually.
3. Remove `tag.Name = "some data";` and see what prints.
4. Explain why an object with no name might be a problem.
5. Predict what syntax might look like if we could pass the name directly into `new Tag(...)`.

### Expected outcome

The learner should understand why setting properties after object creation works, but can be less safe than constructor-based object creation.

---

## Commit 9: `Using a constructor  (just a setup)`

### Learning objective

Introduce constructor methods and constructor overloads.

### Code changes

The `Tag` class now contains two constructors:

```csharp
public Tag()
{
}

public Tag(string abcd)
{
    Console.WriteLine("Constructor received the following: " + abcd);
}
```

The program creates tags both ways:

```csharp
Tag tag2 = new Tag();
tag2.Name = "hello there";

Tag tag3 = new Tag("even more data");
Tag tag4 = new Tag("whats up");
```

### Explanation for beginners

A constructor is a special method that runs when an object is created.

This constructor takes no arguments:

```csharp
public Tag()
{
}
```

This constructor takes a string argument:

```csharp
public Tag(string abcd)
{
    Console.WriteLine("Constructor received the following: " + abcd);
}
```

Having multiple constructors is called constructor overloading.

Important beginner note: in this commit, the constructor receives text and prints it, but it does not yet store it in `Name`.

That means this line:

```csharp
Tag tag3 = new Tag("even more data");
```

runs the constructor, but `tag3.Name` is not automatically set yet.

### Mini tasks

1. Change the constructor parameter name from `abcd` to `tagText`.
2. Add `Name = abcd;` inside the constructor.
3. Create a tag with `new Tag("practice")` and print its name.
4. Explain the difference between `new Tag()` and `new Tag("text")`.
5. Explain what constructor overloading means.

### Expected outcome

The learner should understand that constructors run when objects are created and can receive external data.

---

## Commit 10: `constructor example II`

### Learning objective

Use a constructor to create a fully initialized `Tag` object.

### Code changes

The constructor is cleaned up:

```csharp
public Tag(string tagText)
{
    Name = tagText;
}
```

The parameterless constructor is removed.

The temporary example becomes:

```csharp
Tag tag = new Tag("some data");
Console.WriteLine(tag.Name);
```

`ParseTags` is also simplified:

```csharp
Tag tag = new Tag(cleanedItem);
```

### Explanation for beginners

This is the stronger version of the constructor idea.

Now when we create a tag, we must give it a name immediately:

```csharp
Tag tag = new Tag("some data");
```

The constructor receives the text:

```csharp
public Tag(string tagText)
```

Then stores it in the object:

```csharp
Name = tagText;
```

This means a `Tag` object is born with the data it needs.

That is usually better than creating an empty object and filling it in later.

### Mini tasks

1. Create three tags using `new Tag("...")`.
2. Try `new Tag()` and observe the error.
3. Explain why `new Tag()` no longer works.
4. Add a second property to `Tag` and think about whether it should also be set in the constructor.
5. Change `ParseTags` so it trims the text before passing it to the constructor.

### Expected outcome

The learner should understand how constructors can enforce required data when objects are created.

---

## Commit 11: `update readme, add architecture comment`

### Learning objective

Refocus the project on the full tag-manager app and introduce architecture vocabulary.

### Code changes

The temporary constructor demo is removed from the top of `Main`, so the normal menu can run again.

Some old comments are cleaned up.

The README is updated with architecture concepts:

* Model
* Service
* Repository
* Program.cs as the entry point

### Explanation for beginners

A bigger application becomes easier to understand when each class has a clear job.

This commit introduces four important architecture words.

A **model** represents data.

In this project:

```csharp
class Tag
```

is the model.

A **service** contains business logic. For example, parsing tags or checking whether a tag already exists.

A **repository** saves and loads data. In this project, that means reading from and writing to text files.

`Program.cs` is the entry point. It starts the program, shows the menu, and connects the other pieces.

### Mini tasks

1. Identify the model class in the project.
2. Explain what kind of code should belong in a service class.
3. Explain what kind of code should belong in a repository class.
4. Find the menu code in `Program.cs`.
5. Write one sentence describing the responsibility of `Program.cs`.

### Expected outcome

The learner should understand the high-level architecture direction of the project before more classes are extracted.

---

# Session 3: Services, Duplicate Checks, and Loop Control

Session 3 moves tag parsing logic into a service and introduces duplicate checking with `return` and `continue`.

---

## Commit 12: `Move ParseTags method to its own TagService class. And make the method an instance method instead of a static method. Create TagExits method under TagService.`

### Learning objective

Move business logic out of `Program.cs` and into a service class.

### Code changes

A new class is created:

```csharp
class TagService
{
    public bool TagExists(List<Tag> tags, string name)
    {
        foreach (Tag tag in tags)
        {
            if (tag.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    public List<Tag> ParseTags(string input)
    {
        // parsing logic
    }
}
```

`Program.cs` creates a service instance:

```csharp
TagService tagService = new TagService();
```

Then it calls:

```csharp
tagsList = tagService.ParseTags(userInputTags);
```

The old static `ParseTags` method is removed from `Program.cs`.

### Explanation for beginners

This commit introduces a service class.

A service class contains logic that belongs to the application but is not just data.

`TagService` knows how to work with tags.

This line creates the service object:

```csharp
TagService tagService = new TagService();
```

This line calls a method on the object:

```csharp
tagService.ParseTags(userInputTags);
```

This is an instance method call.

The method belongs to the `tagService` object.

The `TagExists` method also introduces an important use of `return`:

```csharp
return true;
```

When `return` runs, the method stops immediately and sends a value back to the caller.

### Mini tasks

1. Find `TagService.cs` and identify both methods.
2. Explain why `ParseTags` no longer belongs directly in `Program.cs`.
3. Add a `Console.WriteLine` inside `TagExists` to see when it runs.
4. Explain what `return true;` does inside the loop.
5. Rename `name` to `tagName` in `TagExists`.

### Expected outcome

The learner should understand why service classes are useful and how instance methods are called from another class.

---

## Commit 13: `temporary code to show "continue" (in a loop)`

### Learning objective

Introduce `continue` and use it to skip duplicate tags.

### Code changes

Temporary teaching code is added at the top of `Main`:

```csharp
for (int i = 0; i < 34; i++)
{
    if (i == 5)
    {
        continue;
    }
    if (i == 7)
    {
        break;
    }

    Console.WriteLine(i);
}

return;
```

Inside `TagService.ParseTags`, duplicate checking is added:

```csharp
if (TagExists(tagsList, cleanedItem))
{
    Console.WriteLine("Skipped " + cleanedItem + " because it already exists!");
    continue;
}
```

### Explanation for beginners

`continue` and `break` both affect loops, but they do different things.

`break` stops the whole loop.

`continue` skips only the current loop round and moves to the next iteration.

In the temporary loop:

```csharp
if (i == 5)
{
    continue;
}
```

means:

> When `i` is 5, skip the rest of this loop iteration.

In `ParseTags`, `continue` is used for duplicates.

If the tag already exists, the code skips creating and adding a new `Tag` object.

### Mini tasks

1. Run the temporary loop and write down which numbers print.
2. Change the `continue` value from `5` to `3`.
3. Change the `break` value from `7` to `10`.
4. Enter duplicate tags such as `code, code, school` and explain what should happen.
5. Explain the difference between `continue` and `break`.

### Expected outcome

The learner should understand that `continue` skips one loop iteration and can be used to avoid duplicate work.

---

## Commit 14: `use TagExists during ParseTags calls`

### Learning objective

Remove the temporary loop example and return to the real tag-manager flow.

### Code changes

The temporary `for` loop with `continue`, `break`, and `return` is removed from `Main`.

The app now starts normally again:

```csharp
TagService tagService = new TagService();
List<Tag> tagsList = new List<Tag>();
```

The duplicate-checking logic in `ParseTags` remains.

### Explanation for beginners

Temporary teaching examples are useful, but they should not stay in the final application if they stop the real program from running.

The previous commit had:

```csharp
return;
```

near the top of `Main`.

That meant the menu code never ran.

This commit removes the temporary example so the app can continue running normally.

The concept introduced earlier still matters: `TagExists` and `continue` are now part of the real parsing logic.

### Mini tasks

1. Run the app and confirm the menu appears again.
2. Enter duplicate tags and check whether duplicates are skipped.
3. Explain why the earlier `return;` stopped the menu.
4. Add a clearer message when a duplicate tag is skipped.
5. Explain why temporary teaching code should be removed or commented out after use.

### Expected outcome

The learner should understand how to move from a temporary isolated example back into the real application.

---

# Session 4: Saving, Loading, and Repository Architecture

Session 4 focuses on saving object data to text files and then moving file logic into a repository class.

---

## Commit 15: `fix filesaving logic (covert tagsList to list of strings)`

### Learning objective

Understand why object lists must be converted before saving to a text file.

### Code changes

The save option is repaired.

Instead of trying to save `List<Tag>` directly, the code creates a `List<string>`:

```csharp
List<string> lines = new List<string>();

foreach (Tag tag in tagsList)
{
    lines.Add(tag.Name);
}

File.WriteAllLines(filePath, lines);
```

### Explanation for beginners

A text file stores text.

But the app now stores tags as objects:

```csharp
List<Tag>
```

A `Tag` object is not the same as a string.

So before saving, the app extracts the part that should become text:

```csharp
tag.Name
```

This process is a simple form of serialization.

Serialization means converting program data into a format that can be stored or sent somewhere else.

Here, each `Tag` object becomes one line of text.

### Mini tasks

1. Add two tags and save them.
2. Open the text file and check what was written.
3. Explain why `tag.Name` is saved instead of the whole `tag` object.
4. Add a message after saving, such as `"Tags saved."`.
5. Write pseudocode for saving a list of objects to a text file.

### Expected outcome

The learner should understand how to convert object data into strings before writing to a file.

---

## Commit 16: `fix fileloading logic (convert lines of strings into object instances of the Tag-model`

### Learning objective

Convert saved text lines back into `Tag` objects when loading from disk.

### Code changes

The load option is repaired.

The program reads text lines:

```csharp
string[] savedTags = File.ReadAllLines(filePath);
```

Then each line becomes a `Tag` object:

```csharp
foreach (string line in savedTags)
{
    Tag tag = new Tag(line);
    tagsList.Add(tag);
}
```

### Explanation for beginners

Saving converted objects into text.

Loading does the opposite.

The file contains strings, but the application wants `Tag` objects.

So each line is used to construct a new `Tag`:

```csharp
new Tag(line)
```

This is a simple form of deserialization.

Deserialization means converting stored data back into program objects.

### Mini tasks

1. Save a few tags, restart the program, and load them.
2. Add a `Console.WriteLine(line)` inside the load loop.
3. Explain why `new Tag(line)` is needed.
4. Clear the list before loading and observe the difference.
5. Explain serialization and deserialization using this project as an example.

### Expected outcome

The learner should understand how text file data can be converted back into model objects.

---

## Commit 17: `create empty TagRepostory`

### Learning objective

Introduce the repository class as the place where file saving and loading should live.

### Code changes

A new file is created:

```csharp
class TagRepository
{
    // This class will manage file reading and writing
    // Idea: a constructor could help us "configure" the repository

    public TagRepository(string filePath)
    {
        Console.Write("Repository will use " + filePath + " as database.");
    }
}
```

`Program.cs` creates a repository instance:

```csharp
TagRepository tagRepository = new TagRepository("tagslist.txt");
```

Temporary code and `return;` are added so students can focus on the new class.

Teacher note: the commit message says `TagRepostory`, but the class itself is named `TagRepository`.

### Explanation for beginners

A repository is a class responsible for saving and loading data.

The app already had file code in `Program.cs`, but that makes `Program.cs` do too many jobs.

The goal is to move file responsibility into a separate class.

This line creates the repository:

```csharp
TagRepository tagRepository = new TagRepository("tagslist.txt");
```

The file path is passed into the constructor.

That means the repository can be configured with the file it should use.

### Mini tasks

1. Find `TagRepository.cs`.
2. Explain what responsibility this class should have.
3. Change the file name from `"tagslist.txt"` to another name.
4. Remove the temporary `return;` and check how the app behaves.
5. Explain why saving/loading should not stay directly in `Program.cs` forever.

### Expected outcome

The learner should understand the purpose of a repository class and why it helps separate file logic from menu logic.

---

## Commit 18: `TagRepository: implement Save method`

### Learning objective

Move save logic into the repository class.

### Code changes

`TagRepository` now stores the file path in a private field:

```csharp
private string _filePath;
```

The constructor saves the path:

```csharp
_filePath = filePath;
```

A `Save` method is added:

```csharp
public void Save(List<Tag> tagsList)
{
    List<string> lines = new List<string>();

    foreach (Tag tag in tagsList)
    {
        lines.Add(tag.Name);
    }

    File.WriteAllLines(_filePath, lines);
}
```

`Program.cs` now calls:

```csharp
tagRepository.Save(tagsList);
```

### Explanation for beginners

This is a strong architecture step.

Before this commit, `Program.cs` knew all the details of saving tags.

Now `Program.cs` only says:

```csharp
tagRepository.Save(tagsList);
```

The repository handles the details.

The private field:

```csharp
private string _filePath;
```

stores data inside the repository object.

`private` means other classes should not access that field directly.

The repository knows where to save because the file path was passed into the constructor.

### Mini tasks

1. Add a message at the end of `Save`, such as `"Tags saved."`.
2. Explain what `_filePath` stores.
3. Explain why `_filePath` is private.
4. Move any remaining save-related code out of `Program.cs`.
5. Draw a simple diagram: `Program -> TagRepository -> text file`.

### Expected outcome

The learner should understand how a repository method can hide file-saving details from the main program.

---

## Commit 19: `TagRepository: implement Load method`

### Learning objective

Move load logic into the repository class.

### Code changes

`Program.cs` replaces the old load block with:

```csharp
tagsList = tagRepository.Load();
```

`TagRepository` gets a new method:

```csharp
public List<Tag> Load()
{
    List<Tag> tags = new List<Tag>();

    if (File.Exists(_filePath))
    {
        string[] savedTags = File.ReadAllLines(_filePath);

        foreach (string line in savedTags)
        {
            Tag tag = new Tag(line);
            tags.Add(tag);
        }

        Console.WriteLine("Tags loaded from disk.");
        return tags;
    }
    else
    {
        Console.WriteLine("Tags failed to load!");
        return tags;
    }
}
```

### Explanation for beginners

This commit completes the basic repository pattern.

Now `TagRepository` has both:

```csharp
Save(...)
Load()
```

`Load` returns a list:

```csharp
public List<Tag> Load()
```

That means the method gives back a `List<Tag>` to whoever called it.

In `Program.cs`, the returned list replaces the current list:

```csharp
tagsList = tagRepository.Load();
```

The method also handles the case where the file does not exist.

If the file is missing, it returns an empty list instead of crashing.

### Mini tasks

1. Delete or rename the text file and try loading.
2. Explain why `Load` returns an empty list if the file does not exist.
3. Add a message that prints how many tags were loaded.
4. Explain what `return tags;` does.
5. Draw the flow: text file -> TagRepository.Load -> List<Tag> -> Program.

### Expected outcome

The learner should understand how a method can load data, convert it into objects, and return a list to the main program.

---

# Session 5: LINQ, Lambdas, and Cleanup

Session 5 introduces LINQ as a shorter way to query collections, then cleans up temporary examples.

---

## Commit 20: `Replace TagExists loop with a lambda query`

### Learning objective

Replace a manual search loop with LINQ `.Any()` and a lambda expression.

### Code changes

The old loop-based version of `TagExists` is commented out.

The method now uses:

```csharp
bool doesItExist = tags.Any(tag => tag.Name == name);

Console.WriteLine("Does " + name + " already exist? " + doesItExist);

return doesItExist;
```

### Explanation for beginners

Before this commit, checking for an existing tag used a manual loop:

```csharp
foreach (Tag tag in tags)
{
    if (tag.Name == name)
    {
        return true;
    }
}

return false;
```

LINQ can express the same idea more directly:

```csharp
tags.Any(tag => tag.Name == name)
```

This means:

> Does any tag in the list have a name equal to `name`?

The part:

```csharp
tag => tag.Name == name
```

is a lambda expression.

For beginners, you can read it as:

> For each tag, check whether `tag.Name == name`.

`.Any(...)` returns a Boolean: `true` or `false`.

### Mini tasks

1. Rewrite `TagExists` using the old `foreach` loop again.
2. Change it back to `.Any(...)`.
3. Explain what `tag => tag.Name == name` means.
4. Add `.ToLower()` to make duplicate checking case-insensitive.
5. Remove the debug `Console.WriteLine` after you understand the result.

### Expected outcome

The learner should understand that LINQ methods can replace common collection loops and that lambdas describe a condition for each item.

---

## Commit 21: `linq examples`

### Learning objective

Practice LINQ separately from the tag project by using a simple list of strings.

### Code changes

Temporary code is added at the top of `Main`:

```csharp
List<string> things = new List<string>
{
    "coffee", "tea", "water", "laptop", "car", "coffee"
};
```

The code first checks for tea using a manual loop:

```csharp
foreach (string thing in things)
{
    if (thing == "tea")
    {
        Console.Write("we have tea");
    }
}
```

Then it checks for coffee with LINQ:

```csharp
things.Any(thing => thing == "coffee")
```

It also uses `.Where(...)`:

```csharp
var whereIsMyCoffee = things.Where(thing => thing == "coffee" || thing == "tea" || thing == "car");
```

A `return;` stops the normal tag app from running while the LINQ example is active.

### Explanation for beginners

This commit isolates LINQ so it can be studied without the larger tag app.

`.Any(...)` answers a yes/no question:

```csharp
things.Any(thing => thing == "coffee")
```

This returns `true` if at least one item matches.

`.Where(...)` filters a collection:

```csharp
things.Where(thing => thing == "coffee")
```

This returns the matching items.

`var` lets C# infer the type.

That means the programmer does not have to write the full type manually.

### Mini tasks

1. Add more items to the `things` list.
2. Use `.Any()` to check for `"water"`.
3. Use `.Where()` to find only `"coffee"`.
4. Replace one LINQ query with a `foreach` loop.
5. Explain the difference between `.Any()` and `.Where()`.

### Expected outcome

The learner should understand basic LINQ queries and how they compare to manual loops.

---

## Commit 22: `remove linq examples unrelated to the tag-project.`

### Learning objective

Clean up temporary learning code and return focus to the main application.

### Code changes

The temporary LINQ example is removed from `Main`.

The program again starts with the real app setup:

```csharp
TagRepository tagRepository = new TagRepository("tagslist.txt");
TagService tagService = new TagService();
List<Tag> tagsList = new List<Tag>();
```

The tag-manager menu becomes the main flow again.

### Explanation for beginners

Temporary examples are useful for learning a concept in isolation.

But once the concept has been introduced, the project should return to its main structure.

This commit removes unrelated LINQ demo code so the repository stays focused on the tag project.

This is also part of professional programming: remove code that helped you learn or test something, but does not belong in the final app.

### Mini tasks

1. Confirm the tag-manager menu runs again.
2. Find where LINQ is still used in the real project.
3. Explain why the standalone `things` list was removed.
4. Add one useful comment above the `.Any(...)` call in `TagService`.
5. Write one sentence explaining why cleanup commits matter.

### Expected outcome

The learner should understand that learning examples can be temporary and that cleanup improves project readability.

---

# Week 4 Review

After Week 4, students should be able to answer:

1. What is a class?
2. What is an object or instance?
3. What does `new` do?
4. What is a property?
5. What is the difference between `Tag` and `tag`?
6. How can one class create many different objects?
7. What is a constructor?
8. Why is `new Tag("code")` safer than creating an empty tag and setting `Name` later?
9. What is the difference between `List<string>` and `List<Tag>`?
10. Why did `TagPrinter` need to change when the app changed to `List<Tag>`?
11. What is a model class?
12. What is a service class?
13. What is a repository class?
14. What does `return` do?
15. What does `continue` do?
16. How can duplicate tags be skipped?
17. Why must `Tag` objects be converted to strings before saving to a text file?
18. Why must loaded strings be converted back into `Tag` objects?
19. What does `.Any(...)` do?
20. What does `.Where(...)` do?
21. What is a lambda expression?
22. Why should temporary learning examples be removed after use?

---

# Week 4 Practice Project

## Tag Manager with Models, Services, and Repository

Build or improve a console tag-manager app that:

1. Stores tags as `Tag` objects, not plain strings.
2. Uses a `Tag` model class with a `Name` property.
3. Uses a constructor so every tag gets a name when it is created.
4. Uses a `TagPrinter` class to print one tag or a list of tags.
5. Uses a `TagService` class to parse user input.
6. Uses `TagService.TagExists` to avoid duplicate tags.
7. Uses `continue` to skip duplicate tags while parsing.
8. Uses a `TagRepository` class to save and load tags.
9. Converts `List<Tag>` into text lines when saving.
10. Converts text lines back into `Tag` objects when loading.
11. Uses a menu loop in `Program.cs`.

Example menu:

```text
Tag manager
1. Enter new tags
2. Show current tags
3. Save tags
4. Load tags
5. Exit

Choose an option:
```

Example input:

```text
Enter tags separated by comma:
code, school, code, coffee
```

Expected result:

```text
#code
#school
#coffee
```

The duplicate `code` should only be added once.

### Concepts practiced

* Classes
* Objects / instances
* Properties
* Constructors
* Lists of objects
* `foreach`
* `return`
* `continue`
* File saving
* File loading
* Service classes
* Repository classes
* LINQ `.Any()`
* Lambda expressions

---

# Suggested Final Project Structure

```text
Backend4/
├── Program.cs
├── Tag.cs
├── TagPrinter.cs
├── TagService.cs
├── TagRepository.cs
├── tagslist.txt
└── Backend4.csproj
```

## Responsibility of each file

### `Program.cs`

Responsible for:

* Starting the app
* Showing the menu
* Reading menu choices
* Calling the correct service/repository/printer methods

### `Tag.cs`

Responsible for:

* Describing what a tag is
* Storing tag data
* Making sure a tag gets a name through the constructor

### `TagPrinter.cs`

Responsible for:

* Printing one tag
* Printing a list of tags

### `TagService.cs`

Responsible for:

* Parsing comma-separated input
* Cleaning whitespace
* Checking for duplicates
* Creating `Tag` objects from user input

### `TagRepository.cs`

Responsible for:

* Saving tags to disk
* Loading tags from disk
* Converting between `Tag` objects and text lines

---

# Teacher Notes

## Suggested Session Split

### Session 1: Instances and the `Tag` model

Recommended commit flow:

1. `init project`
2. Random instance example
3. Cleaner random dice-roll example
4. First `Tag` model
5. Multiple `Tag` instances
6. Partial use of `Tag` in `ParseTags`
7. Full switch to `List<Tag>` and updated `TagPrinter`

Teaching approach:

* Start with `Random` because it is a familiar built-in class.
* Then show that students can create their own class too.
* Emphasize that `Tag` is the class and `tag` is a variable holding one object.
* Draw the class as a blueprint and each instance as a separate box with its own `Name`.

---

### Session 2: Constructors

Recommended commit flow:

1. Manual object setup without constructor
2. Constructor setup with parameterless and parameterized constructors
3. Constructor that actually stores data in `Name`
4. README architecture cleanup

Teaching approach:

* Ask why an empty `Tag` might be dangerous.
* Show how constructors make object creation more reliable.
* Compare `new Tag()` with `new Tag("code")`.
* Point out that receiving data in a constructor is not enough; the constructor must also store it.

---

### Session 3: Services and duplicate checks

Recommended commit flow:

1. Move `ParseTags` into `TagService`
2. Add `TagExists`
3. Temporary `continue` example
4. Remove temporary loop and keep duplicate-checking behavior

Teaching approach:

* Explain that `Program.cs` should not contain every detail.
* Use `TagService` as an example of business logic.
* Compare `return`, `break`, and `continue`.
* Test duplicate input like `code, code, coffee`.

---

### Session 4: File persistence and repositories

Recommended commit flow:

1. Fix save logic by converting `Tag` objects to strings
2. Fix load logic by converting strings back to `Tag` objects
3. Create `TagRepository`
4. Move save logic into `TagRepository.Save`
5. Move load logic into `TagRepository.Load`

Teaching approach:

* Explain that files store text, not C# objects.
* Introduce serialization and deserialization informally.
* Explain repository as a class that hides storage details.
* Draw the data flow between the menu, repository, and file.

---

### Session 5: LINQ and cleanup

Recommended commit flow:

1. Replace loop-based `TagExists` with `.Any(...)`
2. Temporary standalone LINQ examples
3. Remove unrelated LINQ examples

Teaching approach:

* First show the manual loop.
* Then show the LINQ version.
* Translate `tag => tag.Name == name` into plain English.
* Emphasize that cleanup commits are part of real development.

---

# Common Mistakes to Watch For

## Confusing class names and variable names

Problem:

```csharp
Tag Tag = new Tag();
```

Better:

```csharp
Tag tag = new Tag("code");
```

Use uppercase for class names and lowercase/camelCase for variable names.

---

## Creating an object but forgetting to set its data

Problem:

```csharp
Tag tag = new Tag();
Console.WriteLine(tag.Name);
```

The name may be empty or `null`.

Better:

```csharp
Tag tag = new Tag("code");
Console.WriteLine(tag.Name);
```

---

## Forgetting to update all methods after changing a list type

Problem:

```csharp
List<Tag> tags = new List<Tag>();
TagPrinter.Print(List<string> tags)
```

The printer expects strings, but the app now has `Tag` objects.

Better:

```csharp
public static void Print(List<Tag> tags)
{
    foreach (Tag tag in tags)
    {
        Console.WriteLine("#" + tag.Name);
    }
}
```

---

## Trying to save objects directly as text lines

Problem:

```csharp
File.WriteAllLines(filePath, tagsList);
```

This does not work properly when `tagsList` is a `List<Tag>`.

Better:

```csharp
List<string> lines = new List<string>();

foreach (Tag tag in tagsList)
{
    lines.Add(tag.Name);
}

File.WriteAllLines(filePath, lines);
```

---

## Loading strings but forgetting to create objects

Problem:

```csharp
string[] lines = File.ReadAllLines(filePath);
// But the app needs List<Tag>, not string[]
```

Better:

```csharp
List<Tag> tags = new List<Tag>();

foreach (string line in lines)
{
    tags.Add(new Tag(line));
}
```

---

## Using `break` when `continue` is needed

Problem:

```csharp
if (TagExists(tagsList, cleanedItem))
{
    break;
}
```

This stops the whole loop.

Better:

```csharp
if (TagExists(tagsList, cleanedItem))
{
    continue;
}
```

This skips only the duplicate item.

---

## Forgetting that `.Any()` returns a Boolean

Example:

```csharp
bool exists = tags.Any(tag => tag.Name == name);
```

`exists` is either `true` or `false`.

Use `.Any()` when the question is:

> Does at least one matching item exist?

---

## Leaving temporary example code in `Main`

Problem:

```csharp
// temporary example
return;

// real app below never runs
```

Temporary examples are useful while teaching, but they can stop the actual app from running.

Remove them or comment them out when returning to the real project.

---

# Final Expected Outcome

By the end of this repository, the learner should be able to explain and build a small object-oriented console app where:

* Data is represented with a model class.
* Objects are created with constructors.
* Lists can store objects, not only strings.
* Printing, parsing, and persistence are separated into different classes.
* File storage converts objects to text and text back into objects.
* Duplicate detection can be written with either a loop or LINQ.
* Temporary examples are used for learning and then removed to keep the project focused.
