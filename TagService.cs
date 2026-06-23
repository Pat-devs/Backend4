class TagService // a service that "serves" a model (or models)
{
    public bool TagExists(List<Tag> tags, string name)
    {
        foreach (Tag tag in tags)
        {
            if (tag.Name == name)
            {
                return true; // return terminates the method
            }
        }

        return false;
    }
    /// <summary>
    /// Parses input strings, removing any whitespaces into a list
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Tagslist</returns>
    public List<Tag> ParseTags(string input)
    {
        string[] tagsInputArray = input.Split(",");
        List<Tag> tagsList = new List<Tag>();
        
        foreach (string item in tagsInputArray)
        {

            // cleanup the tag 
            string cleanedItem = item.Trim();
            // check if tag exists
            if (TagExists(tagsList, cleanedItem))
            {
                continue; // skips this iteration
            }


            // turn the tag-text into an instance
            Tag tag = new Tag(cleanedItem); // create an instance
            
            tagsList.Add(tag); 
        }

        return tagsList;
    }
}