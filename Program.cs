namespace Backend4;
class Program
{
    static void Main(string[] args)
    {  
        for (int i = 0; i < 34; i++)
        {
            if (i == 5)
            {
                continue; // skip this iteration
            }
            if (i == 7)
            {
                break; // terminate the loop
            }

            Console.WriteLine(i);
        }

        return;

        TagService tagService = new TagService(); // intitialze an instance of the tagservice

        // initialize the tagslist as an empty list
        List<Tag> tagsList = new List<Tag>();

        Console.Clear();
        bool running = true;

        while (running)
        {       
            Console.WriteLine("Tag manager");
            Console.WriteLine("1. Enter new tags");
            Console.WriteLine("2. Show current tags");
            Console.WriteLine("3. Save tags");
            Console.WriteLine("4. Load tags");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            int choice = 0;

            bool isInputValid = int.TryParse(Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine("Enter tags separated by comma:");
                string userInputTags = Console.ReadLine();


                tagsList = tagService.ParseTags(userInputTags);
            }
            else if (choice == 2)
            {
                TagPrinter.Print(tagsList);
            }
            else if (choice == 3)
            {
                string filePath = "taglist.txt"; // file path (folder + filename)
                // File.WriteAllLines(filePath, tagsList);
            }
            else if (choice == 4)
            {
                string filePath = "taglist.txt"; // file path (folder + filename)
                if (File.Exists(filePath))
                {
                    // string[] savedTags = File.ReadAllLines(filePath);
                    // tagsList = new List<string>(savedTags);

                    Console.WriteLine("Tags loaded from disk.");
                }
                else
                {
                    Console.WriteLine("Tags failed to load!");
                }
            }
            else if (choice == 5)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("invalid choice");
            }
        }
    }
}

