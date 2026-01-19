
class Program
{
    static void Main(string[] args)
    {
        string? name;
        int alter;

        Console.WriteLine($"Hallo Der herr/ Die Dame. Wie heißt du und wie alt bist du?");

        Console.WriteLine("Name: ");
        name = Console.ReadLine() ?? "Deafault Benutzer";

        if (name.ToLower().Trim() == "Ende")
        {
            return;
        }

        Console.WriteLine("Alter: ");
        alter = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Hallo {name}, du darfst {1}hinein", Funktion(alter) ? "" : "Nicht ");

        /* Im prinzip das selbe aber Länger
         * if (Funktion(alter) == true)
        {
            Console.WriteLine($"Du darfst rein {name}.");
        }
        else
        {
            Console.WriteLine($"Du bist zu Jung {name}.");
        }
        */
    }

    static bool Funktion(int alter)
    {
        return alter >= 18;

        /* Im prinzip das selbe aber Länger
        if(alter >= 18)
            return true;
        else
            return false;
        */
    }
}