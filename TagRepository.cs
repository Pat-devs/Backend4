class TagRepository
{
    // This class will manage file reading and writing
    // Idea: a constructor could help us "configure" the repository
    private string _filePath; 
    public TagRepository(string filePath)
    {
        Console.Write("Repository will use " + filePath + " as database.");
        _filePath = filePath;
    }

    public void Save(List<Tag> tagsList)
    {
        //string filePath = "taglist.txt"; // file path (folder + filename)
                
        // convert list of tags to list of strings (to make it useful outside of C#)
        List<string> lines = new List<string>();

        foreach (Tag tag in tagsList)
        {
            lines.Add(tag.Name);
        }

        File.WriteAllLines(_filePath, lines);
    }

    public List<Tag> Load()
    {
        // create an empty list of tags
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
}