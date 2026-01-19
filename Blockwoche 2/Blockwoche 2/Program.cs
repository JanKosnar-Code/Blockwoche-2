
class Program
{
    static void Main(string[] args)
    {
        string? name;
        int alter;

        Console.WriteLine($"Hallo Der herr/ Die Dame. Wie heißt du und wie alt bist du?");

        Console.WriteLine("Name: ");
        name = Console.ReadLine();

        if (name == "Ende")
        {
            return;
        }

        Console.WriteLine("Alter: ");
        alter = Convert.ToInt32(Console.ReadLine());

        Funktion(alter);

        if (Funktion(alter) == true)
        {
            Console.WriteLine("Du darfst rein.");
        }
        else
        {
            Console.WriteLine("Du bist zu Jung");
        }
    }

    static bool Funktion(int alter)
    {
        if (alter >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}