class TagPrinter
{
    public static void Print(Tag tag) // prints a single tag
    {
        Console.WriteLine("Tag: ");
        Console.WriteLine("#" + tag.Name);
    }
    public static void Print(List<Tag> tags)
    {
        Console.WriteLine("Tags: ");

        foreach (Tag tag in tags)
        {
            Console.WriteLine("#" + tag.Name);
        }
    }
}