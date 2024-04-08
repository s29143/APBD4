namespace APBD4;

public class Db
{
    public static List<Animal> Animals { get; set; } = new List<Animal>()
    {
        new Animal(1, "Azor", AnimalCategory.Dog, 8.5, "Brown"),
        new Animal(2, "Azor", AnimalCategory.Cat, 4.5, "Black"),
        new Animal(3, "Azor", AnimalCategory.Cat, 3.5, "Orange"),
        new Animal(4, "Azor", AnimalCategory.Dog, 8.5, "Black"),
    };
}