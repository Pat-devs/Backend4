class Tag
{
    public string Name { get; set; }

    public Tag() 
    {
        
    }
    public Tag(string abcd) // a constructor method
    {
        Console.WriteLine("Constructor received the following: " + abcd);
    }
    
}