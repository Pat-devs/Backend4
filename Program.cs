using System.Reflection.Emit;

namespace Backend4;
class Program
{
    static void Main(string[] args)
    {  
        
        Random random = new Random(); // create a new intance of the Random class object

        // we suspected that there is a "modulo bias" in the .next formula
        // the code below was used to test to see if it is the case
        for (int i = 0; i < 10000; i++)
        {
            int diceResult = random.Next(1,6); // use the .next method to get the next "pseudo random" number. 
            if (diceResult == 6)
            {
                Console.WriteLine("SIX!");
                break;
            } 
            //Console.WriteLine("Roll (" + i + "): "  + diceResult); // do something with the result
        }

        return;


        // initialize the tagslist as an empty list
        List<string> tagsList = new List<string>();

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
                tagsList = ParseTags(userInputTags);
            }
            else if (choice == 2)
            {
                TagPrinter.Print(tagsList);
            }
            else if (choice == 3)
            {
                string filePath = "taglist.txt"; // file path (folder + filename)
                File.WriteAllLines(filePath, tagsList);
            }
            else if (choice == 4)
            {
                string filePath = "taglist.txt"; // file path (folder + filename)
                if (File.Exists(filePath))
                {
                    string[] savedTags = File.ReadAllLines(filePath);
                    tagsList = new List<string>(savedTags);

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

    /// <summary>
    /// Parses input strings, removing any whitespaces into a list
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Tagslist</returns>
    static List<string> ParseTags(string input)
    {
        // TODO-idea; check if tag already exists
        string[] tagsArray = input.Split(",");
        List<string> tagsList = new List<string>();
        
        foreach (string item in tagsArray)
        {
            // cleanup the tag 
            string cleanedItem = item.Trim();
            tagsList.Add(cleanedItem); 
        }

        return tagsList;
    }

}