namespace APBD4;

public class Animal(int id, string firstName, AnimalCategory category, double weight, string color)
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public AnimalCategory Category { get; set; } = category;
    public double Weight { get; set; } = weight;
    public string Color { get; set; } = color;
}

public enum AnimalCategory
{
    Cat,
    Dog
}