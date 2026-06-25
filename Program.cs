namespace Backend4;
class Program
{
    static void Main(string[] args)
    {  

        // Simple Linq & Lambda examples

        List<string> things = new List<string>
        {
            "coffee", "tea", "water", "laptop", "car", "coffee"
        };

        // check if we have any "tea"

        foreach (string thing in things)
        {
            if (thing == "tea")
            {
                Console.Write("we have tea");
            }
        }

        Console.WriteLine();
        // check if we have any "coffee" using linq

        Console.WriteLine(" Coffee? " + things.Any(thing => thing == "coffee") ); // returns (bool) if anything matches

        Console.WriteLine();

        var whereIsMyCoffee = things.Where(thing => thing == "coffee" || thing == "tea" || thing == "car");
        
        foreach (var item in whereIsMyCoffee)
        {
            Console.WriteLine(item);
        }
        
        //Console.WriteLine("where??? " + whereIsMyCoffee.FirstOrDefault() ); // returns matching elements


        return;

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

