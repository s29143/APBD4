namespace APBD4;

public class Animal
{
    public Animal(int id, string firstName, AnimalCategory category, double weight, string color)
    {
        Id = id;
        FirstName = firstName;
        Category = category;
        Weight = weight;
        Color = color;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public AnimalCategory Category { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }
}

public enum AnimalCategory
{
    Cat,
    Dog
}