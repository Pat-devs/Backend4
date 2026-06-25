class TagRepository
{
    // This class will manage file reading and writing
    // Idea: a constructor could help us "configure" the repository

    public TagRepository(string filePath)
    {
        Console.Write("Repository will use " + filePath + " as database.");
    }
}