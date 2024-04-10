namespace APBD4;

public class Db
{
    public static List<Animal> Animals { get; set; } = new List<Animal>()
    {
        new Animal(1, "Azor", AnimalCategory.Dog, 8.5, "Brown"),
        new Animal(2, "Boo", AnimalCategory.Cat, 4.5, "Black"),
        new Animal(3, "Felix", AnimalCategory.Cat, 3.5, "Orange"),
        new Animal(4, "Cooper", AnimalCategory.Dog, 8.5, "Black"),
    };

    public static List<Visit> Visits { get; set; } = new List<Visit>()
    {
        new Visit(DateTime.Today, Animals[0], "medical examination", 50),
        new Visit(DateTime.MaxValue, Animals[0], "NFZ Consultation", 0),
    };
}