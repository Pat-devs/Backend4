namespace Backend4;
class Program
{
    static void Main(string[] args)
    {  
        TagRepository tagRepository = new TagRepository("tagslist.txt");


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
            //Console.WriteLine("6. Search for a tag"); // todo :)
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
                tagRepository.Save(tagsList);
            }
            else if (choice == 4)
            {
                tagsList = tagRepository.Load();
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

