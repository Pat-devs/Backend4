# Backend uke 4

We contine with the same TagPrinter project from week 3.

## Concepts for this week:
 - Object oriented programming
 - Static vs instance of a class
 - Architecture


### Architecture
 - Model: 
   - A class that represents "data" (how we want to "model" our data): Example in our case: Tag
 - Service: 
   - A class that does "business logic": TagService (may for example: filter data, load data, parse data from somewhere)
 - Repository: 
   - A class that saves and loads data. (example: SQL database, any other database, filesystem storage)
 - Program.cs
   - Entry point, startup