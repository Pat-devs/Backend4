class TagPrinter
{
    public static void Print(string tag) // prints a single tag
    {
        Console.WriteLine("Tag: ");
        Console.WriteLine("#" + tag);
    }
    public static void Print(List<string> tags)
    {
        Console.WriteLine("Tags: ");

        foreach (string tag in tags)
        {
            Console.WriteLine("#" + tag);
        }
    }
}