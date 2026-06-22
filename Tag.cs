class Tag
{
    public string Name { get; set; }

    public Tag(string tagText) // a constructor method allows us to pass in external "data" during instantiation (Construction / startup)
    {
        Name = tagText;
    }
    
}